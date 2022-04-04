using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace noter.Classes.Init
{
    public static class ConfigureDefaults
    {
        public static void LoadMain(PictureBox settings, PictureBox search, PictureBox expand, Label title, Label settingsLbl, Label searchLbl, Panel pnlSide, string path )
        {
            settings.Image = Image.FromFile(path + @"\symbols\16px\_settings.png");
            search.Image = Image.FromFile(path + @"\symbols\16px\_spyglass.png");
            expand.Image = Image.FromFile(path + @"\symbols\16px\_expand.png");

            title.ForeColor = ColorTranslator.FromHtml("#191919");
            settingsLbl.ForeColor = ColorTranslator.FromHtml("#191919");
            searchLbl.ForeColor = ColorTranslator.FromHtml("#191919");
        }
    }
}
