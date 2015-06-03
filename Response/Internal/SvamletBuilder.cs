using System;
using System.Collections.Generic;
using System.Linq;
using Sinch.Callback.Model;

namespace Sinch.Callback.Response.Internal
{
    internal class SvamletBuilder
    {
        protected Locale Locale { get; private set; }
        
        private readonly List<SvamletInstruction> _instructions = new List<SvamletInstruction>();
        private SvamletAction _action;
        private readonly List<string> _promptSpecifications = new List<string>();

        protected bool Barge { get; set; }

        protected SvamletBuilder(Locale locale)
        {
            Locale = locale;
        }

        protected void SetAction(SvamletAction action)
        {
            _action = action;
        }

        protected void AddInstruction(SvamletInstruction instruction)
        {
            _instructions.Add(instruction);
        }

        protected void InternalSetCookie(string name, string value)
        {
            AddInstruction(new SvamletInstruction
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

            if(file.StartsWith("http", StringComparison.InvariantCultureIgnoreCase))
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
            SetAction(new SvamletAction { Name = "hangup", Barge = Barge });
            return Build();
        }

        public ISvamletResponse Hangup(int hangupCause)
        {
            SetAction(new SvamletAction { Name = "hangup", Barge = Barge, HangupCause = hangupCause });
            return Build();
        }

        public ISvamletResponse Continue()
        {
            SetAction(new SvamletAction { Name = "continue" });
            return Build();
        }

        protected virtual T Build<T>() where T : SvamletResponse, new()
        {
            if (_promptSpecifications.Any())
            {
                AddInstruction(new SvamletInstruction
                {
                    Name = "playfiles",
                    Ids = _promptSpecifications.ToArray(),
                    Locale = Locale.Code
                });

                _promptSpecifications.Clear();
            }

            return new T()
            {
                Model = new Svamlet()
                {
                    Action = _action,
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