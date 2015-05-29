using System;
using System.Collections.Generic;
using System.Linq;
using Sinch.Callback.Model;
using Sinch.Callback.Request.Internal;

namespace Sinch.Callback.Response.Internal
{
    internal class IceSvamletBuilder : CallerSvamletBuilder, IIceSvamletBuilder
    {
        private readonly IDictionary<string, Menu<IIceSvamletBuilder>> _menus = new Dictionary<string, Menu<IIceSvamletBuilder>>();
        private readonly IDictionary<string, NumberInputMenu> _numberInputMenus = new Dictionary<string, NumberInputMenu>();

        private static readonly TypeMapper Mapper = new TypeMapper();

        internal IceSvamletBuilder(Locale locale) : base(locale)
        {
        }

        public IIceSvamletBuilder SetCookie(string name, string value)
        {
            InternalSetCookie(name, value);
            return this;
        }

        public IIceSvamletBuilder Say(string text)
        {
            InternalSay(text);
            return this;
        }

        public IIceSvamletBuilder Play(string file)
        {
            InternalPlay(file);
            return this;
        }

        public IIceSvamletBuilder SaySsml(string ssml)
        {
            InternalPlaySsml(ssml);
            return this;
        }

        public ISvamletResponse RunMenu(string menuId)
        {
            if(!_menus.ContainsKey(menuId) && !_numberInputMenus.ContainsKey(menuId))
                throw new BuilderException("Menu '" + menuId + "' is not defined");

            SetAction(new SvamletAction
            {
                Name = "runmenu",
                Locale = Locale.Code,
                MainMenu = menuId,
                Menus = _menus.Select(m =>
                {
                    var menu = new MenuModel
                    {
                        Id = m.Key,
                        MainPrompt = m.Value.Prompt,
                        RepeatPrompt = m.Value.RepeatPrompt,
                        Repeats = m.Value.Repeats
                    };

                    var options = m.Value.GotoMenuOptions.Select(mo => new MenuOptionModel()
                    {
                        Action = "menu(" + mo.Value.Item1 + ")",
                        AddToContext = mo.Value.Item2 != null ? mo.Value.Item2.Select(c => new KeyValueModel { Key = c.Key, Value = c.Value }).ToArray() : null,
                        Digit = Mapper.AsString(mo.Key)
                    }).Union(m.Value.ReturnOptions.Select(ro => new MenuOptionModel()
                    {
                        Action = "return(" + ro.Value + ")",
                        Digit = Mapper.AsString(ro.Key),
                    }));

                    menu.Options = options.ToArray();

                    return menu;

                }).Union(_numberInputMenus.Select(i =>
                {
                    var menu = new MenuModel
                    {
                        Id = i.Key,
                        MainPrompt = i.Value.Prompt,
                        RepeatPrompt = i.Value.RepeatPrompt,
                        Repeats = i.Value.Repeats,
                        MaxDigits = i.Value.MaxDigits
                    };

                    return menu;
                })).ToArray()
            });

            return Build();
        }

        public IMenu<IIceSvamletBuilder> BeginMenuDefinition(string menuId, string prompt, string repeatPrompt = null, int repeats = 3)
        {
            CheckMenuId(menuId);

            var menu = new Menu<IIceSvamletBuilder>(this, prompt, repeatPrompt, repeats);
            _menus[menuId] = menu;
            return menu;
        }

        private void CheckMenuId(string menuId)
        {
            if(string.IsNullOrEmpty(menuId))
                throw new BuilderException("Menu ID cannot be empty");

            if (menuId.Length > 64)
                throw new BuilderException("Menu ID cannot be longer than 64 chars");

            if (_numberInputMenus.ContainsKey(menuId) || _menus.ContainsKey(menuId))
                throw new BuilderException("Menu '" + menuId + "' already defined");
        }

        public IIceSvamletBuilder AddNumberInputMenu(string menuId, string prompt, int maxDigits, string repeatPrompt = null,
            int repeats = 3)
        {
            CheckMenuId(menuId);

            var menu = new NumberInputMenu(prompt, repeatPrompt, repeats, maxDigits);
            _numberInputMenus[menuId] = menu;
            return this;
        }

        public IIceSvamletBuilder EndMenu()
        {
            return this;
        }
    }
}