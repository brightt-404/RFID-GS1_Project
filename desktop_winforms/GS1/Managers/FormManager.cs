using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS1.Managers
{
    internal class FormManager
    {
        private Panel panelMain;
        private Form currentForm;

        public FormManager(Panel panel)
        {
            panelMain = panel;
        }

        public void OpenForm(Form childForm)
        {
            if (currentForm != null)
                currentForm.Close();

            currentForm = childForm;
            childForm.TopLevel = false;
            childForm.ShowInTaskbar = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            panelMain.Controls.Clear();
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }
    }
}
