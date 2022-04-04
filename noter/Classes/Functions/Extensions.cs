using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace noter.Classes.Functions
{
    public static class Extensions
    {
        static string path = System.IO.Path.GetDirectoryName(
       System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6);

        public static IEnumerable<Control> GetAllChildren(this Control root)
        {
            var stack = new Stack<Control>();
            stack.Push(root);

            while (stack.Any())
            {
                var next = stack.Pop();
                foreach (Control child in next.Controls)
                    stack.Push(child);
                yield return next;
            }
        }

        public static void SetDatagridStyle (DataGridView dataGrid)
        {
            dataGrid.BackgroundColor = SystemColors.ControlLight;
            dataGrid.BorderStyle = BorderStyle.None;
            dataGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGrid.DefaultCellStyle.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular);
            dataGrid.DefaultCellStyle.ForeColor = ColorTranslator.FromHtml("#191919");
            dataGrid.DefaultCellStyle.SelectionForeColor = ColorTranslator.FromHtml("#191919");
            dataGrid.RowHeadersVisible = false;
            dataGrid.ColumnHeadersVisible = false;
            dataGrid.DefaultCellStyle.BackColor = SystemColors.ControlLight;
            dataGrid.AllowUserToResizeRows = false;

            dataGrid.ColumnHeadersHeight = 23;
            dataGrid.GridColor = SystemColors.ControlLight;
            dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGrid.DefaultCellStyle.SelectionBackColor = SystemColors.ControlLight;
            dataGrid.AllowUserToAddRows = false;
        }

        public static DataGridView GenerateDataGrid(Panel panel, string subDir)
        {
            DataGridView dgvDir = new DataGridView();
            SetDatagridStyle(dgvDir);

            DataGridViewImageColumn clImage = new DataGridViewImageColumn();
            DataGridViewTextBoxColumn clFile = new DataGridViewTextBoxColumn();

            dgvDir.Columns.Add(clImage);
            dgvDir.Columns.Add(clFile);

            dgvDir.CellMouseEnter += dgvDir_CellMouseEnter;
            dgvDir.CellMouseLeave += dgvDir_CellMouseLeave;

            foreach (var file in GetAllFilesInDirectory(path + @"\content"))
            {
                CreateRow(dgvDir, file.ToString());
                if (file == subDir)
                {
                    foreach(var subFile in GetAllFilesInDirectory(subDir))
                    {
                        CreateRow(dgvDir, subFile.ToString());
                    }
                }              
            }

            panel.Controls.Add(dgvDir);

            dgvDir.Size = new Size(dgvDir.Columns[1].Width + 20, 341);
            dgvDir.Location = new Point(20, 120);

            return dgvDir;
        }

        private static void CreateRow(DataGridView dgvDir, string file)
        {
            string fileExt = System.IO.Path.GetExtension(file);

            var image = Image.FromFile(path + @"\symbols\16px\" + Classes.Functions.JSONHandler.LookupDictionary(fileExt, path) + ".png");

            dgvDir.Rows.Add(image, file.Split('\\').Last().Split('.')[0]);
        }

        private static void dgvDir_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgvDir = (DataGridView)sender;
                dgvDir.Rows[e.RowIndex].Cells[1].Style.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold);
            }
            catch (Exception ex)
            { }
        }
        private static void dgvDir_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgvDir = (DataGridView)sender;
                dgvDir.Rows[e.RowIndex].Cells[1].Style.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular);
            }
            catch (Exception ex)
            { }
        }

        public static List<string> GetAllFilesInDirectory(string dir)
        {
            string[] folders = System.IO.Directory.GetDirectories(dir, "*", System.IO.SearchOption.TopDirectoryOnly);
            string[] files = System.IO.Directory.GetFiles(dir, "*", System.IO.SearchOption.TopDirectoryOnly);
            
            return folders.ToList<string>().Join(files.ToList<string>()).ToList<string>();
        }
        public static List<T> Join<T>(this List<T> first, List<T> second)
        {
            if (first == null)
            {
                return second;
            }
            if (second == null)
            {
                return first;
            }

            return first.Concat(second).ToList();
        }
    }
}
