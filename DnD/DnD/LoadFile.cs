using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DnD
{
    public class LoadFile 
    {
        public void loadDndFile(TextBox textBox, string[] readLines)
        {
            textBox.Text = readLines.ToString();
        }
        
    }
}
