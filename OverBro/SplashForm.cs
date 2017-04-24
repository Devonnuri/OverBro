﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OverBro {
    public partial class SplashForm : Form {
        bool isAscend = true;
        float opacity = 0;
        Timer timer = new Timer();

        public SplashForm() {
            InitializeComponent();

            Opacity = 1;
            timer.Interval = 10;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e) {
            if(isAscend) {
                opacity += 0.01f;
                if (opacity >= 1) isAscend = false;
            } else {
                opacity -= 0.01f;
                if (opacity <= 0)
                {
                    timer.Stop();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }

            Opacity = opacity;
        }
    }
}
