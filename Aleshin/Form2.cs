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
    public partial class Form2 : Form
    {
        string image, faculty, fio, group, id;
        public Form2()
        {
            InitializeComponent();
            DB();
        }
        private MySqlConnection DB()
        {
            string connect = "Data Source = localhost ;Database=aleshin; port = 3306 ;User id = root ; password = Alexeybaranov00. ";

            MySqlConnection connection = new MySqlConnection(connect);
            return connection;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello");
        }
        private bool check_student()
        {
            MySqlConnection connection = DB();
            connection.Open();
            String surname = textBox1.Text;
            string group_ = textBox2.Text;
            string faculty_ = textBox3.Text;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            String query = string.Format("select id, name  , surname , patronymic , image from students  where students.surname = '{0}'  ", surname);
            MySqlCommand command = new MySqlCommand(query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            List<string> students = new List<string>();
            while (reader.Read()) {
                students.Add(reader[0].ToString());
                image = reader[4].ToString();
                id = reader[0].ToString();
                fio = reader[1].ToString() +" "+  reader[2].ToString() + " " + reader[3].ToString();
                    }
            reader.Close();
            if (students.Count() == 0)
            {
                connection.Close();
                return false;
            }
            else
            {
                String query_1 = string.Format("select group_student , faculty from student_info where student_info.id = {0} ;" ,id);
                MySqlCommand command_1 = new MySqlCommand(query_1, connection);
                MySqlDataReader reader_1 = command_1.ExecuteReader();
                while (reader_1.Read())
                {
                    group = reader_1[0].ToString();
                    faculty = reader_1[1].ToString();
                }
                connection.Close();
                reader_1.Close();
                return true;
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            bool value = check_student();
            if (value)
            {
                Form3 f3 = new Form3();
                f3.student(image,fio,  faculty,  group) ;
                f3.Show();
            }
            else
            {
                MessageBox.Show("Not find student!");
            }
        }
    }
}
