using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace OverBro {
    public partial class MainForm : Form {
        public string configPath = @"overbro.cfg";
        public string battleTag = "";
        public string region = "";
        public string path = "";
        private Font yoonblackfit20, yoonblackfit16, yoonblackfit10;

        public MainForm() {
            InitializeComponent();

            registerFont(ref yoonblackfit20, Properties.Resources.yoonblackfit, 20F);
            registerFont(ref yoonblackfit16, Properties.Resources.yoonblackfit, 16F);
            registerFont(ref yoonblackfit10, Properties.Resources.yoonblackfit, 10F);

            label1.Font = yoonblackfit20;
            label2.Font = yoonblackfit16;
            linkLabel1.Font = yoonblackfit16;
            checkedListBox1.Font = yoonblackfit10;

            checkedListBox1.Items.Add("경쟁전 - 근접공격 결정타");
            checkedListBox1.Items.Add("경쟁전 - 근접공격 결정타 평균");
            checkedListBox1.Items.Add("경쟁전 - 단독 처치");
            checkedListBox1.Items.Add("경쟁전 - 단독 처치 평균");
            checkedListBox1.Items.Add("경쟁전 - 임무 기여 처치");
            checkedListBox1.Items.Add("경쟁전 - 임무 기여 처치 평균");

            if (!File.Exists(configPath))
            {
                File.WriteAllLines(configPath, new string[] {
                    "battletag:none",
                    "path:"+Environment.CurrentDirectory,
                    "region:KR"
                }, System.Text.Encoding.UTF8);
            }
            
            string[] lines = File.ReadAllLines(configPath);
            foreach (string line in lines)
            {
                string[] splited = line.Split(new char[] { ':' }, 2);
                if (splited[0] == "battletag") {
                    battleTag = splited[1];
                } else if (splited[0] == "path") {
                    path = splited[1];
                } else if (splited[0] == "region") {
                    region = splited[1];
                }
            }

            setLabelText();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            EditTagForm form = new EditTagForm(battleTag, region);

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (Regex.IsMatch(form.textBox1.Text, @"[^#\-\n]+[#-]+[0-9]+"))
                {
                    battleTag = form.textBox1.Text;
                    switch (form.comboBox1.SelectedIndex)
                    {
                        case 0: region = "KR"; break;
                        case 1: region = "EU"; break;
                        case 2: region = "US"; break;
                        default: region = "KR"; break;
                    }

                    writeConfig(battleTag, region, path);
                    setLabelText();
                } else
                {
                    MessageBox.Show("올바른 배틀태그 형식이 아닙니다.", "오버브로", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            EditTagForm form = new EditTagForm(battleTag, region);

            if(form.ShowDialog() == DialogResult.OK) {
                if(Regex.IsMatch(form.textBox1.Text, @"[^#\-\n]+[#-]+[0-9]+")) {
                    battleTag = form.textBox1.Text;
                    switch (form.comboBox1.SelectedIndex)
                    {
                        case 0: region = "KR"; break;
                        case 1: region = "EU"; break;
                        case 2: region = "US"; break;
                        default: region = "KR"; break;
                    }

                    writeConfig(battleTag, region, path);
                    setLabelText();
                } else {
                    MessageBox.Show("올바른 배틀태그 형식이 아닙니다.", "오버브로", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void writeConfig(string battleTag, string region, string path) {
            File.WriteAllLines(configPath, new string[] {
                    "battletag:"+battleTag,
                    "path:"+path,
                    "region:"+region
                }, System.Text.Encoding.UTF8);
        }

        private void setLabelText() {
            if (battleTag != "none") {
                linkLabel1.Text = "(" + region + ") " + replaceLast(battleTag, "-", "#");
            } else {
                linkLabel1.Text = "클릭시 설정";
            }
        }

        public static string replaceLast(string Source, string Find, string Replace) {
            int place = Source.LastIndexOf(Find);

            if (place == -1)
                return Source;

            string result = Source.Remove(place, Find.Length).Insert(place, Replace);
            return result;
        }

        private void registerFont(ref Font font, byte[] res, float size) {
            PrivateFontCollection pfc = new PrivateFontCollection();
            int fontLength = res.Length;
            byte[] fontdata = res;
            IntPtr data = Marshal.AllocCoTaskMem(fontLength);
            Marshal.Copy(fontdata, 0, data, fontLength);
            pfc.AddMemoryFont(data, fontLength);
            Marshal.FreeCoTaskMem(data);

            font = new Font(pfc.Families[0], size);
        }
    }
}
