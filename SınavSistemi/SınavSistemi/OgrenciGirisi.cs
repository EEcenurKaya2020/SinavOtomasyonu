﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SınavSistemi
{
    public partial class OgrenciGirisi : Form
    {
        public OgrenciGirisi()
        {
            InitializeComponent();
        }

        private void OgrenciGirisi_Load(object sender, EventArgs e)
        {

        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            /*Ayarlar a = new Ayarlar();
            a.ShowDialog();
            this.Hide();*/
        }

        private void guna2Button1_Click_2(object sender, EventArgs e)
        {
            this.Hide();
            SinavOl so = new SinavOl();
            so.ShowDialog();
            
        }
    }
}
