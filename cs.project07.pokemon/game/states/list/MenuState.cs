﻿using System.Diagnostics.CodeAnalysis;
using cs.project07.pokemon.game.states.gui;
using cs.project07.pokemon.game.states.gui.managers;
using System.Numerics;

namespace cs.project07.pokemon.game.states.list
{
    internal class MenuState : State
    {
        private ButtonManager _buttonManager;
        private Dictionary<string, Button> _buttons;

        public MenuState(Game game) : base(game)
        {
            Init();
        }

        protected override void Init()
        {
            Name = "Main Menu";
            InitButtons();
        }

        protected void InitButtons()
        {
            _buttonManager = new ButtonManager();

            _buttons = _buttonManager.Buttons;

            _buttons["PLAY"] = new Button(this, "Play")
            {
                Selected = true,
                Action = () =>
                {
                    Game.StatesList?.Push(new GameState(Parent));
                }
            };
            _buttons["CREDITS"] = new Button(this, "Credits")
            {
                Action = () =>
                {

                }
            };
            _buttons["QUIT"] = new Button(this, "Quit")
            {
                Offsets = new Vector2(0, 10),
                Action = () =>
                {
                    Game.StatesList?.Pop();
                }
            };

            for (int i = 0; i < _buttons.Count; i++)
            {
                _buttons.ElementAt(i).Value.Offsets += new Vector2(3, 1 + i);
            }

            _buttonManager.HandleKeyEvent = (pressedKey) =>
            {
                switch (pressedKey)
                {
                    case ConsoleKey.UpArrow:
                        Button.SelectPrevious(_buttons);
                        break;
                    case ConsoleKey.DownArrow:
                        Button.SelectNext(_buttons);
                        break;
                    case ConsoleKey.Enter:
                        Button.ExecuteAction(_buttons);
                        break;
                }
            };
        }

        public override void HandleKeyEvent(ConsoleKey pressedKey)
        {
            HandleKeyEventButtons(pressedKey);
        }   

        private void HandleKeyEventButtons(ConsoleKey pressedKey)
        {
            _buttonManager.HandleKeyEvent(pressedKey);
        }

        public override void Update()
        {
            base.Update();

            // Update state childs
            // ------ Buttons
            _buttonManager?.Update();
        }

        public override void Render()
        {
            base.Render();

            // Render state childs
            // ------ Buttons
            _buttonManager?.Render();
        }
    }
}