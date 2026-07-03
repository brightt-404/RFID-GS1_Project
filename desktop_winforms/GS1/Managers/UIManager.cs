using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GS1.Managers
{
    internal sealed class UIManager
    {
        private static readonly Color ActiveBack = Color.DeepSkyBlue;
        private static readonly Color ActiveFore = Color.White;
        private static readonly Color InactiveBack = Color.FromArgb(28, 78, 138);
        private static readonly Color InactiveFore = Color.FromArgb(200, 215, 235);

        private readonly List<Button> _navButtons;

        public UIManager(params Button[] navButtons)
        {
            _navButtons = navButtons?.Where(b => b != null).ToList() ?? new List<Button>();
        }

        public void SetActiveButton(Button activeButton)
        {
            foreach (Button btn in _navButtons)
            {
                bool active = ReferenceEquals(btn, activeButton);
                btn.BackColor = active ? ActiveBack : InactiveBack;
                btn.ForeColor = active ? ActiveFore : InactiveFore;
            }
        }
    }
}
