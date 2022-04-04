using System;
using System.Drawing;
using System.Windows.Forms;

namespace noter.Classes.Functions
{
    public class BoldOnHover
    {
        public void OnMouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.Font = new Font(label.Font.Name, label.Font.Size, FontStyle.Bold);            
        }

        public void OnMouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.Font = new Font(label.Font.Name, label.Font.Size, FontStyle.Regular);
        }
    }
}
