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
            dataGrid.ReadOnly = true;

            dataGrid.ColumnHeadersHeight = 23;
            dataGrid.GridColor = SystemColors.ControlLight;
            dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

             dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGrid.DefaultCellStyle.SelectionBackColor = SystemColors.ControlLight;
            dataGrid.AllowUserToAddRows = false;
            dataGrid.ScrollBars = ScrollBars.None;
            
        }

        public static DataGridView GenerateDataGrid(Panel panel, string subDir)
        {
            DataGridView dgvDir = new DataGridView();
            SetDatagridStyle(dgvDir);

            Classes.Controls.TextAndImageColumn clImage = new Classes.Controls.TextAndImageColumn();

            dgvDir.Columns.Add(clImage);

            dgvDir.CellMouseEnter += dgvDir_CellMouseEnter;
            dgvDir.CellMouseLeave += dgvDir_CellMouseLeave;

            List<string> backDirs = new List<string>();

                foreach (var file in GetAllFilesInDirectory(path + @"\content"))
                {
                    CreateRow(dgvDir, file.ToString(), 0, 0, 0);
                }

            panel.Controls.Add(dgvDir);

            dgvDir.Size = new Size(550, 500);

            dgvDir.Location = new Point(panel.Location.X+35, 120);

            return dgvDir;
        }

        public static void AppendNewDirData(DataGridView dataGridView, string directory, string CurCel, bool collapse)
        {
            var backDirs = SplitDirectories(directory);
            int padding = backDirs.Count * 20;
            bool breakLoop = false;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (breakLoop)
                    break;

                if (GetDirectoryOfItem(row, dataGridView, CurCel) == directory)
                {
                    int rowInd = row.Index + 1;

                    if (collapse == false)
                    {
                        foreach (var file in GetAllFilesInDirectory(directory))
                        {
                            CreateRow(dataGridView, file.ToString(), 1, rowInd, padding);
                            rowInd++;
                        }

                        if (rowInd != row.Index + 1)
                        {
                            break;
                        }
                    }
                    else
                    {
                        for (int r = rowInd; r < dataGridView.Rows.Count; r++)
                        {
                            if (((Classes.Controls.TextAndImageCell)dataGridView.Rows[r].Cells[0]).Indent > ((Classes.Controls.TextAndImageCell)row.Cells[0]).Indent)
                            {
                                dataGridView.Rows.RemoveAt(r);
                                r--;
                            }
                            else
                            {
                                breakLoop = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        public static string GetDirectoryOfItem(DataGridViewRow row, DataGridView dataGridView, string selectedDir)
        {
            string directory = "";
            string dirBuilder = "";

            if(row.Cells[0].Style.Padding.Left==0)
            {
                directory = path + @"\content\"+row.Cells[1].Value;
            }
            else
            {
                string parentFolder="";

                for(int y = row.Index; y >= 0; y--)
                {
                    string tagVal = dataGridView.Rows[y].Cells[0].Tag.ToString();

                    if(parentFolder!="")
                    {
                        parentFolder = parentFolder.Split('\\').Last();
                    }

                    if ( tagVal.Remove(tagVal.LastIndexOf('?')) == "Directory" && dataGridView.Rows[y].Cells[0].Value == selectedDir)
                    {
                        dirBuilder = dataGridView.Rows[y].Cells[0].Value.ToString() + @"\" + dirBuilder;
                        parentFolder = dataGridView.Rows[y].Cells[0].Tag.ToString().Split('?').Last();
                    }
                    else if (dataGridView.Rows[y].Cells[0].Value.ToString() == parentFolder)
                    {
                        dirBuilder = dataGridView.Rows[y].Cells[0].Value.ToString() + @"\" + dirBuilder;
                        parentFolder = dataGridView.Rows[y].Cells[0].Tag.ToString().Split('?').Last();
                    }
                }
            }

            if (dirBuilder != "")
                directory = path + @"\content\" + dirBuilder.Remove(dirBuilder.Length - 1, 1);

            return directory;
        }

        public static List<string> SplitDirectories(string directory)
        {
            List<string> backDirs = new List<string>();

            string dir = directory;
            int numberOfDirs = GetEverythingAfterValue(directory, "content").Split('\\').Length - 1;

            for (int i = 0; i < numberOfDirs; i++)
            {
                dir = dir.Remove(dir.LastIndexOf('\\'));

                    backDirs.Add(dir);
            }

            backDirs.Add(directory);

            return
                backDirs;
        }

        public static string GetEverythingAfterValue(string value, string search)
        {
            return value.Substring(value.LastIndexOf(search) + search.Length);
        }

        private static List<string> ConvertDelimitedList (string delimiter, string value)
        {
            return value.Split(char.Parse(delimiter)).ToList();            
        }

        private static void CreateRow(DataGridView dgvDir, string file, int type, int pos, int padding)
        {
            string fileExt = System.IO.Path.GetExtension(file);

            Image image = Image.FromFile(path + @"\symbols\16px\" + Classes.Functions.JSONHandler.LookupDictionary(fileExt.ToLower(), path) + ".png");

            string fileName = file.Split('\\').Last().Split('.')[0];

            var parentDir = file.Remove(file.LastIndexOf('\\'));

            if (fileExt=="")
            {
                fileExt = "Directory";
            }

            if (type == 1)
            {
                if (pos != 0)
                {
                    dgvDir.Rows.Insert(pos);                                   

                    ((Classes.Controls.TextAndImageCell)dgvDir.Rows[pos].Cells[0]).Image = image;
                    ((Classes.Controls.TextAndImageCell)dgvDir.Rows[pos].Cells[0]).Value = fileName;
                    ((Classes.Controls.TextAndImageCell)dgvDir.Rows[pos].Cells[0]).Indent = padding;


                    dgvDir.Rows[pos].Cells[0].Style.Padding = new Padding(padding+15, 0, 0, 0);
                    dgvDir.Rows[pos].Cells[0].Tag = fileExt+"?"+ parentDir;
                }
                else
                {
                    dgvDir.Rows.Add();
                    ((Classes.Controls.TextAndImageCell)dgvDir.Rows[dgvDir.RowCount - 1].Cells[0]).Image = image;
                    ((Classes.Controls.TextAndImageCell)dgvDir.Rows[dgvDir.RowCount - 1].Cells[0]).Value = fileName;

                    dgvDir.Rows[dgvDir.RowCount - 1].Cells[0].Tag = fileExt + "?" + parentDir; ;
                }
            }
            else
            {
                dgvDir.Rows.Add();
                ((Classes.Controls.TextAndImageCell)dgvDir.Rows[dgvDir.RowCount - 1].Cells[0]).Image = image;
                ((Classes.Controls.TextAndImageCell)dgvDir.Rows[dgvDir.RowCount - 1].Cells[0]).Value = fileName;
                dgvDir.Rows[dgvDir.RowCount - 1].Cells[0].Tag = fileExt + "?" + parentDir; ;
            }                          
        }

            private static void dgvDir_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgvDir = (DataGridView)sender;
                dgvDir.Rows[e.RowIndex].Cells[0].Style.Font = new Font("Segoe UI", 8.25f, FontStyle.Bold);
            }
            catch (Exception ex)
            { }
        }
        private static void dgvDir_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgvDir = (DataGridView)sender;
                dgvDir.Rows[e.RowIndex].Cells[0].Style.Font = new Font("Segoe UI", 8.25f, FontStyle.Regular);
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
