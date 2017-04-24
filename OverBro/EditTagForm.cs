using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverBro {
    public partial class EditTagForm : Form {
        public EditTagForm(string battleTag, string region) {
            InitializeComponent();

            textBox1.Text = MainForm.replaceLast(battleTag, "-", "#");
            if (battleTag == "none") textBox1.Text = "";
        
            switch (region) {
                case "KR": comboBox1.SelectedIndex = 0; break;
                case "EU": comboBox1.SelectedIndex = 1; break;
                case "US": comboBox1.SelectedIndex = 2; break;
                default: comboBox1.SelectedIndex = 0; break;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.No;
            Close();
        }
    }
}
