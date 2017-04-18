using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverBro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PrivateFontCollection pfc = new PrivateFontCollection();
            int fontLength = Properties.Resources.ow_font.Length;
            byte[] fontdata = Properties.Resources.ow_font;
            IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            pfc.AddMemoryFont(data, fontLength);
            Marshal.FreeCoTaskMem(data);

            label1.Font = new Font(pfc.Families[0], 25F, FontStyle.Underline);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
