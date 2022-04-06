using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        static string curPath = path + @"\content";

        //pos
        int pnlOrig;
        int pbOrig;

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
            this.DoubleBuffered = true;
        }

        private void main_home_Load(object sender, EventArgs e)
        {
            (new Core.DropShadow()).ApplyShadows(this);
            Classes.Init.BuildStructure.BuildDirectories();
            var BoldOnHover = new Classes.Functions.BoldOnHover();

            Classes.Init.ConfigureDefaults.LoadMain(pbSettings, pbSearchAll, pbExpand, lblTitle, lblSettings, lblSearchAll, pnlSide, path);

            pnlOrig = pnlSide.Width;
            pbOrig = pbExpand.Location.X;

            foreach (var label in Classes.Functions.Extensions.GetAllChildren(this).OfType<Label>())
            {
                label.MouseEnter += new EventHandler(BoldOnHover.OnMouseEnter);
                label.MouseLeave += new EventHandler(BoldOnHover.OnMouseLeave);
            }

            DataGridView dgvDir = Classes.Functions.Extensions.GenerateDataGrid(pnlSide,"");
            dgvDir.CellDoubleClick += dgvDir_CellDoubleClick;
            dgvDir.ContextMenuStrip = cmMenuItems;

            tbMain.SendToBack();
        }
        public void dgvDir_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgvDir = (DataGridView)sender;
                curPath = dgvDir.CurrentCell.Tag.ToString().Split('?').Last() + @"\" + dgvDir.CurrentCell.Value.ToString();
                string notDir = "";
                notDir = dgvDir.CurrentCell.Tag.ToString().Split('?')[0];

                if (notDir == "Directory") { 
                FileAttributes attr = System.IO.File.GetAttributes(curPath);

                if (attr.ToString() == "Directory")
                {
                    bool collapse = false;

                    if (((Classes.Controls.TextAndImageCell)dgvDir.Rows[dgvDir.CurrentRow.Index + 1].Cells[0]).Indent > ((Classes.Controls.TextAndImageCell)dgvDir.Rows[dgvDir.CurrentRow.Index].Cells[0]).Indent)
                    {
                        collapse = true;
                    }

                    Classes.Functions.Extensions.AppendNewDirData(dgvDir, curPath, dgvDir.CurrentCell.Value.ToString(), collapse);
                }
            }
                if(notDir.ToString() == ".txt")
                    Classes.Tab_Pages.GenerateTabPage.TabPage("file", tbMain, curPath+notDir);
            }
            catch (Exception ex)
            { }
        }

        private void pbExpand_MouseEnter(object sender, EventArgs e)
        {
            pbExpand.Image = Image.FromFile(path + @"\symbols\16px\_expand_col.png");
        }

        private void pbExpand_MouseLeave(object sender, EventArgs e)
        {
            pbExpand.Image = Image.FromFile(path + @"\symbols\16px\_expand.png");
        }

        private void pbExpand_Click(object sender, EventArgs e)
        {
            if (pbOrig != pbExpand.Location.X)
            {
                pbExpand.Location = new Point(pbOrig, pbExpand.Location.Y);
                pnlSide.Size = new Size(pnlOrig, pnlSide.Height);
            }
            else
            {
                foreach (Control control in pnlSide.Controls)
                    if (control is DataGridView)
                    {
                        pbExpand.Visible = false;
                        DataGridView dgvDir = (DataGridView)control;
                        for (int z = pnlSide.Width; z < dgvDir.Columns[0].Width + 45; z += 20)
                        {
                            pnlSide.Size = new Size(pnlSide.Width += 20, pnlSide.Height);
                            System.Threading.Thread.Sleep(1);
                            int x = pbExpand.Location.X;
                            pbExpand.Location = new Point(x += 20, pbExpand.Location.Y);
                        }
                        pbExpand.Visible = true;
                    }
            }
        }

        private void lblSettings_Click(object sender, EventArgs e)
        {
            Classes.Tab_Pages.GenerateTabPage.TabPage("configuration", tbMain, "");            
        }

        private void pbBack_MouseEnter(object sender, EventArgs e)
        {
            pbBack.Image = Image.FromFile(path + @"\symbols\16px\_leftarrowcolour.png");
        }

        private void pbBack_MouseLeave(object sender, EventArgs e)
        {
            pbBack.Image = Image.FromFile(path + @"\symbols\16px\_leftarrow.png");
        }

        private void pbForward_MouseEnter(object sender, EventArgs e)
        {
            pbForward.Image = Image.FromFile(path + @"\symbols\16px\_rightarrowcolour.png");
        }

        private void pbForward_MouseLeave(object sender, EventArgs e)
        {
            pbForward.Image = Image.FromFile(path + @"\symbols\16px\_rightarrow.png");
        }

        private void pbClose_MouseEnter(object sender, EventArgs e)
        {
            pbClose.Image = Image.FromFile(path + @"\symbols\16px\_closecolour.png");
        }

        private void pbClose_MouseLeave(object sender, EventArgs e)
        {
            pbClose.Image = Image.FromFile(path + @"\symbols\16px\_close.png");
        }

        private void pbMinimise_MouseEnter(object sender, EventArgs e)
        {
            pbMinimise.Image = Image.FromFile(path + @"\symbols\16px\_minimisecolour.png");
        }

        private void pbMinimise_MouseLeave(object sender, EventArgs e)
        {
            pbMinimise.Image = Image.FromFile(path + @"\symbols\16px\_minimise.png");
        }

        private void pbMinimise_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvTabs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
