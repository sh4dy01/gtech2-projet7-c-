﻿#pragma warning disable CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
namespace cs.project07.pokemon.game.states.gui.managers
{
    internal class ButtonManager
    {
        public Dictionary<string, Button>? Buttons;
        
        public ButtonManager()
        {
            Buttons = new Dictionary<string, Button>();
        }

        public Action<ConsoleKey> HandleKeyEvent { get; set; }

        public void Update()
        {
            if (Buttons?.Count == 0) return;
            foreach (Button button in Buttons.Values)
                button.Update();
        }

        public void Render()
        {
            if (Buttons?.Count == 0) return;
            foreach (Button button in Buttons.Values)
                button.Render();
        }
    }
}