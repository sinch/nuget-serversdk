using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Sinch.ServerSdk.Calling.Models;
using System.Reflection;

namespace Sinch.ServerSdk.Calling.Callbacks.Request.Internal
{
    internal class CallbackEventReader : ICallbackEventReader
    {
        private static readonly JsonSerializer JsonDeserializar = new JsonSerializer();
        private static readonly IDictionary<string, Type> ResultImplementationMap = new Dictionary<string, Type>()
        {
            {"ice", typeof (IceEvent)},
            {"dice", typeof (DiceEvent)},
            {"pie", typeof (PieEvent)},
            {"ace", typeof (AceEvent)},
            {"notify", typeof(NotificationEvent)}
        };

        private static readonly IDictionary<Tuple<Type, string>, string> NameMappings =
            new Dictionary<Tuple<Type, string>, string>();

        public ICallbackEvent ReadJson(string json)
        {
            using (var sreader = new StringReader(json))
            using (var jreader = new JsonTextReader(sreader))
            {
                var evt = JsonDeserializar.Deserialize<CallbackEventModel>(jreader);
                return ReadModel(evt);
            }
        }

        private static object ReadModelProperty(object modelPropertyData, Type targetPropertyType)
        {
            if (modelPropertyData == null)
                return null;

            var sourceType = modelPropertyData.GetType();

            if (targetPropertyType.IsAssignableFrom(sourceType))
                return modelPropertyData;

            var converterFunction = TypeMapper.Singleton.GetType().GetMethods().FirstOrDefault(m => m.ReturnType == typeof(bool) && m.GetParameters().Length == 2 && m.GetParameters()[0].ParameterType == sourceType && m.GetParameters()[1].ParameterType == targetPropertyType.MakeByRefType() && m.GetParameters()[1].IsOut);

            if (converterFunction != null)
            {
                object result = null;

                var args = new object[] {modelPropertyData, result};

                if((bool) converterFunction.Invoke(TypeMapper.Singleton, args))
                    return args[1];
            }

            return null;
        }

        public ICallbackEvent ReadModel(CallbackEventModel model)
        {
            if (model == null)
                return null;

            Type resultType;

            if(!ResultImplementationMap.TryGetValue(model.Event, out resultType))
                resultType = typeof(CallingCallbackEvent);

            var resultImplementation = resultType.GetConstructor(new Type[0]);

            if (resultImplementation == null)
                return null;

            var result = resultImplementation.Invoke(null);

            foreach (var resultProperty in resultType.GetProperties())
            {
                var sourcePropertyName = GetSourceName(resultType, resultProperty.Name);

                var sourceProperty = model.GetType().GetProperty(sourcePropertyName);

                if (sourceProperty == null)
                    continue;

                var converted = ReadModelProperty(sourceProperty.GetValue(model), resultProperty.PropertyType);

                try
                {
                    resultProperty.SetValue(result, converted);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine("Conversion failed for property '" + resultProperty.Name + "' - " + ex);
                }
                
            }

            return result as ICallbackEvent;
        }

        private static string GetSourceName(Type targetType, string targetName)
        {
            var key = new Tuple<Type, string>(targetType, targetName);
            string sourceName;

            if (!NameMappings.TryGetValue(key, out sourceName))
                sourceName = targetName;

            return sourceName;
        }
    }
}