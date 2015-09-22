﻿using System;
using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.Calling.Callbacks.Response.Internal
{
    internal class ManageCallSvamletBuilder : CallerSvamletBuilder<IManageCallSvamletBuilder>, IManageCallSvamletBuilder
    {
        internal ManageCallSvamletBuilder(Locale locale) : base(locale)
        {
        }

        public IManageCallSvamletBuilder SetCookie(string name, string value)
        {
            InternalSetCookie(name,value);
            return this;
        }

        public IManageCallSvamletBuilder EnableBargeHangup()
        {
            Barge = true;
            return this;
        }

        public IManageCallSvamletBuilder SaySsml(string ssml)
        {
            InternalPlaySsml(ssml);
            return this;
        }

        public IManageCallSvamletBuilder Say(string text)
        {
            InternalSay(text);
            return this;
        }

        public IManageCallSvamletBuilder Play(string file)
        {
            InternalPlay(file);
            return this;
        }

        public IMenu<IManageCallSvamletBuilder> BeginMenuDefinition(string menuId, Prompt prompt, TimeSpan? timeout)
        {
            return InternalBeginMenuDefinition(this, menuId, prompt, timeout);
        }

        public IManageCallSvamletBuilder AddNumberInputMenu(string menuId, Prompt prompt, int maxDigits, Prompt repeatPrompt = null,
            int repeats = 3, TimeSpan? timeout = null)
        {
            base.InternalAddNumberInputMenu(menuId, prompt, maxDigits, prompt, repeats, timeout);
            return this;
        }
    }
}