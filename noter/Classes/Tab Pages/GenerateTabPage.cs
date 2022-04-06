using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace noter.Classes.Tab_Pages
{
    

    public class GenerateTabPage
    {
        //dir
        static string path = System.IO.Path.GetDirectoryName(
       System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);

        public static void TabPage(string type, TabControl tab, string path)
        {
            TabPage tabPage = new TabPage();
            tabPage.Size = tab.Size;

            if (type == "file")
            {
                RichTextBox textBox = CreateRichTextBox();

                tabPage.Controls.Add(textBox);
                textBox.Dock = DockStyle.Fill;

                textBox.Text = File.ReadAllText(path);
            }
            if (type == "configuration")
            {
                Label lblConfiguration = CreateLabel("Configuration",13,FontStyle.Regular, "Segoe UI Semibold");
                Label lblDictionary = CreateLabel("- Dictionary", 8, FontStyle.Regular, "Segoe UI");
                Label lblFonts = CreateLabel("- Fonts", 8, FontStyle.Regular, "Segoe UI");
                Label lblPermissions = CreateLabel("- Permissions", 8, FontStyle.Regular, "Segoe UI");
                Label lblStyling = CreateLabel("- Styling", 8, FontStyle.Regular, "Segoe UI");
                Label lblCustomControls = CreateLabel("- Custom Controls", 8, FontStyle.Regular, "Segoe UI");                

                PictureBox pbSettings = CreateImage(path + @"\symbols\64px\_anvil.png");

                tabPage.Controls.Add(lblConfiguration);
                tabPage.Controls.Add(lblDictionary);
                tabPage.Controls.Add(lblFonts);
                tabPage.Controls.Add(lblPermissions);
                tabPage.Controls.Add(lblStyling);
                tabPage.Controls.Add(lblCustomControls);                

                tabPage.Controls.Add(pbSettings);

                pbSettings.Location = new Point((tabPage.Width - 100 ) / 2 - lblConfiguration.Width, 5);
                lblConfiguration.Location = new Point((tabPage.Width - 100 ) / 2 - lblConfiguration.Width, 70);

                lblDictionary.Location = new Point((tabPage.Width - 100) / 2 - lblConfiguration.Width, 100);
                lblFonts.Location = new Point((tabPage.Width - 100) / 2 - lblConfiguration.Width, 115);
                lblPermissions.Location = new Point((tabPage.Width - 100) / 2 - lblConfiguration.Width, 130);
                lblStyling.Location = new Point((tabPage.Width - 100) / 2 - lblConfiguration.Width, 145);
                lblCustomControls.Location = new Point((tabPage.Width - 100) / 2 - lblConfiguration.Width, 160);
            }

            tab.Controls.Add(tabPage);
        }

        public static RichTextBox CreateRichTextBox()
        {
            RichTextBox tb = new RichTextBox();
            tb.BorderStyle = BorderStyle.None;
            tb.BackColor = SystemColors.Control;
            tb.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            return tb;
        }

        public static PictureBox CreateImage(string imageLocation)
        {
            PictureBox pictureBox = new PictureBox();

            pictureBox.Image = Image.FromFile(imageLocation);
            pictureBox.BorderStyle = BorderStyle.None;

            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;            

            return pictureBox;
        }

        public static Label CreateLabel(string text, int size, FontStyle fontStyle, string fontType)
        {
            Label label = new Label();
            label.Text = text;
            label.Font = new Font(fontType, size, fontStyle);
            label.Width = TextRenderer.MeasureText(label.Text, label.Font).Width;
            label.Height = TextRenderer.MeasureText(label.Text, label.Font).Height;
            label.ForeColor = ColorTranslator.FromHtml("#191919");

            return label;
        }

    }
}
