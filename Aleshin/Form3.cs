using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aleshin
{
    public partial class Form3 : Form
    {
        string image , faculty , fio , group;
        public Form3()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(image);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Show();
            textBox1.Text = fio;
            textBox2.Text = faculty;
            textBox3.Text = group;    
        }
        public void student(string image ,string fio , string faculty , string group) 
        {
            this.image = image;
            this.fio = fio;
            this.faculty = faculty;
            this.group = group;
        }
        
    }
}
