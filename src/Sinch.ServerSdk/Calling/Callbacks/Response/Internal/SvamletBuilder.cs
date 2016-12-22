using System;
using System.Collections.Generic;
using System.Linq;
using Sinch.ServerSdk.Calling.Models;
using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.Calling.Callbacks.Response.Internal
{
    internal class SvamletBuilder
    {
        protected Locale Locale { get; private set; }
        
        private readonly List<SvamletInstructionModel> _instructions = new List<SvamletInstructionModel>();
        private SvamletActionModel _actionModel;
        private readonly List<string> _promptSpecifications = new List<string>();

        protected bool Barge { get; set; }

        protected SvamletBuilder(Locale locale)
        {
            Locale = locale;
        }

        protected void SetAction(SvamletActionModel actionModel)
        {
            _actionModel = actionModel;
        }

        protected void AddInstruction(SvamletInstructionModel instructionModel)
        {
            _instructions.Add(instructionModel);
        }

        protected void InternalSetCookie(string name, string value)
        {
            AddInstruction(new SvamletInstructionModel
            {
                Name = "setcookie",
                Key = name,
                Value = value
            });
        }

        protected void InternalSay(string text)
        {
            if (string.IsNullOrEmpty(text))
                throw new BuilderException("Cannot specify empty TTS strings");

            if (_promptSpecifications.Count > 64)
                throw new BuilderException("Cannot specify more than 64 TTS strings or file parts");

            if (text.Length > 200)
                throw new BuilderException("TTS texts can not be more than 200 characters per prompt");

            if (_promptSpecifications.Where(x => x.StartsWith("#tts")).Sum(x => x.Length - 6) > 1000)
                throw new BuilderException("TTS can not be more than a total of 1000 characters");

            text = text.Replace("#tts[", string.Empty).Replace("]", string.Empty);

            _promptSpecifications.Add("#tts[" + text + "]");
        }

        protected void InternalPlay(string file)
        {
            if (string.IsNullOrEmpty(file))
                throw new BuilderException("Cannot specify empty file names");

            if (_promptSpecifications.Count > 64)
                throw new BuilderException("Cannot specify more than 64 TTS strings or file parts");

            if (file.Length > 128)
                throw new BuilderException("File names can not be longer than 128 characters");

            if(file.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                _promptSpecifications.Add("#href[" + file + "]");
            else
                _promptSpecifications.Add(file);
        }

        protected void InternalPlaySsml(string ssml)
        {
            if (string.IsNullOrEmpty(ssml))
                throw new BuilderException("Cannot specify empty SSML");

            if (_promptSpecifications.Count > 128)
                throw new BuilderException("Cannot specify more than 128 characters as SSML");

            _promptSpecifications.Add("#ssml[" + ssml + "]");
        }

        public ISvamletResponse Hangup()
        {
            return Hangup(HangupCause.Normal);
        }

        public ISvamletResponse Hangup(HangupCause cause)
        {
            SetAction(new SvamletActionModel { Name = "hangup", Barge = Barge, HangupCause = (int) cause });
            return Build();
        }

        public ISvamletResponse Continue()
        {
            SetAction(new SvamletActionModel { Name = "continue" });
            return Build();
        }

        protected virtual T Build<T>() where T : SvamletResponse, new()
        {
            if (_promptSpecifications.Any())
            {
                AddInstruction(new SvamletInstructionModel
                {
                    Name = "playfiles",
                    Ids = _promptSpecifications.ToArray(),
                    Locale = Locale.Code
                });

                _promptSpecifications.Clear();
            }

            return new T()
            {
                Model = new SvamletModel()
                {
                    Action = _actionModel,
                    Instructions = _instructions.ToArray()
                }
            };
        }

        public virtual ISvamletResponse Build()
        {
            return Build<SvamletResponse>();
        }
    }
}