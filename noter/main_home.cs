using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace noter
{
    public partial class main_home : Form
    {
        //override
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        //dir
        static string path = System.IO.Path.GetDirectoryName(
       System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);

        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;

        }
        public main_home()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void main_home_Load(object sender, EventArgs e)
        {
            (new Core.DropShadow()).ApplyShadows(this);
            Classes.Init.BuildStructure.BuildDirectories();
            var BoldOnHover = new Classes.Functions.BoldOnHover();

            lblTitle.ForeColor = ColorTranslator.FromHtml("#191919");
            pbSettings.Image = Image.FromFile(path + @"\symbols\16px\_settings.png");
            pbSearchAll.Image = Image.FromFile(path + @"\symbols\16px\_spyglass.png");
            lblSettings.ForeColor = ColorTranslator.FromHtml("#191919");
            lblSearchAll.ForeColor = ColorTranslator.FromHtml("#191919");

            foreach (var label in Classes.Functions.Extensions.GetAllChildren(this).OfType<Label>())
            {
                label.MouseEnter += new EventHandler(BoldOnHover.OnMouseEnter);
                label.MouseLeave += new EventHandler(BoldOnHover.OnMouseLeave);
            }

            foreach(var file in Classes.Functions.Extensions.GetAllFilesInDirectory(path + @"\content"))
            {
                dgvDir.Rows.Add(Image.FromFile(path + @"\symbols\8px\_rightarrow.png"), Image.FromFile(path + @"\symbols\8px\_rightarrow.png"), file.Split('\\').Last());
            }

        }
    }
}
