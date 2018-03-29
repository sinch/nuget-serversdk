using System;
using System.Collections.Generic;
using System.Linq;
using Sinch.ServerSdk.Calling.Models;
using Sinch.ServerSdk.Models;

namespace Sinch.ServerSdk.IvrMenus
{
    internal class MenuBuilder : IMenuBuilder
    {
        private readonly IDictionary<string, Menu> _menus = new Dictionary<string, Menu>();

        private readonly IDictionary<string, NumberInputMenu> _numberInputMenus =
            new Dictionary<string, NumberInputMenu>();

        private TypeMapper Mapper { get; } = new TypeMapper();


        public IMenu BeginMenuDefinition(string menuId, Prompt prompt, TimeSpan? timeout)
        {
            CheckMenuId(menuId);

            var menu = new Menu(this, prompt, null, 3, timeout);
            _menus[menuId] = menu;
            return menu;
        }

        private void CheckMenuId(string menuId)
        {
            if (string.IsNullOrEmpty(menuId))
                throw new BuilderException("Menu ID cannot be empty");

            if (menuId.Length > 64)
                throw new BuilderException("Menu ID cannot be longer than 64 chars");

            if (_numberInputMenus.ContainsKey(menuId) || _menus.ContainsKey(menuId))
                throw new BuilderException("Menu '" + menuId + "' already defined");
        }

        public IMenuBuilder AddNumberInputMenu(string menuId, Prompt prompt, int maxDigits, Prompt repeatPrompt = null,
            int repeats = 3, TimeSpan? timeout = null)
        {
            CheckMenuId(menuId);

            var menu = new NumberInputMenu(prompt, repeatPrompt, repeats, maxDigits, timeout);
            _numberInputMenus[menuId] = menu;

            return this;
        }

        public MenuModel[] Build()
        {
            return _menus.Select(m =>
            {
                var menu = new MenuModel
                {
                    Id = m.Key,
                    MainPrompt = m.Value.Prompt.Specification,
                    RepeatPrompt = m.Value.RepeatPrompt.Specification,
                    Repeats = m.Value.Repeats,
                    TimeoutMills = (int) m.Value.Timeout.TotalMilliseconds
                };

                var options = m.Value.GotoMenuOptions.Select(mo => new MenuOptionModel()
                {
                    Action = "menu(" + mo.Value.Item1 + ")",
                    AddToContext =
                        mo.Value.Item2 != null
                            ? mo.Value.Item2.Select(c => new KeyValueModel {Key = c.Key, Value = c.Value}).ToArray()
                            : null,
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
                    MainPrompt = i.Value.Prompt.Specification,
                    RepeatPrompt = i.Value.RepeatPrompt.Specification,
                    Repeats = i.Value.Repeats,
                    MaxDigits = i.Value.MaxDigits,
                    TimeoutMills = (int) i.Value.Timeout.TotalMilliseconds
                };

                return menu;
            })).ToArray();
        }
    }
}
        
