using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace BDHotel
{
    public partial class Form1 : Form
    {
        public string comboText1;
        public string comboText2;
        public static int idmax;

        public void GetEmployees(string a, string b, string c, string d)
        {
            using (SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-DEKVKMF\SQLEXPRESS;Initial Catalog=ОПБД;Integrated Security=True"))
            {
                Con.Open();
                string query = $"SELECT {d} " +
                                "C.ID, " +
                                "[Фамилия] = C.[LastName], " +
                                "[Имя] = C.[FirstName], " +
                                "[Отчество] = [Patronymic], " +
                                "[Пол] = G.[Name], " +
                                "[Телефона] = C.[Phone], " +
                                "[Email] = C.[Email], " +
                                "[Дата рождения] = C.[Birthday], " +
                                "[Дата регестрации] = CS.[StartTime] " +
                                "FROM [Gender] AS G " +
                                "JOIN [Client] AS C ON C.GenderCode = G.Code " +
                                "JOIN [ClientService] AS CS ON CS.ClientID = C.ID " +
                                "JOIN [Service] AS S ON CS.ServiceID = S.ID  " +
                                $"{c} " +
                                $"{a}";
                //$"ORDER BY E.[{a}] {b}";
                SqlCommand command = new SqlCommand(query, Con);
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                Con.Close();
                if (dt.Rows.Count != 0)
                {
                    Grid_Employees.Visible = true;
                    Grid_Employees.DataSource = dt;
                    Grid_Employees.Update();
                    Grid_Employees.Columns[0].Width = 50; 
                    Grid_Employees.Columns[1].Width = 150; 
                    Grid_Employees.Columns[2].Width = 150; 
                    Grid_Employees.Columns[3].Width = 150; 
                    Grid_Employees.Columns[4].Width = 100; 
                    Grid_Employees.Columns[5].Width = 150; 
                    Grid_Employees.Columns[6].Width = 170; 
                    Grid_Employees.Columns[7].Width = 150;
                    Grid_Employees.Columns[8].Width = 170;
                }
                else
                {
                    Grid_Employees.Visible = false;
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
            SetRoundedShape(bt_Add, 30);
            SetRoundedShape(button1, 30);
            SetRoundedShape(button2, 30);
            SetRoundedShape(button3, 30);
            SetRoundedShape(button4, 30);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            GetEmployees("","","","");
            
            //using (SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-DEKVKMF\SQLEXPRESS;Initial Catalog=ОПБД;Integrated Security=True"))
            //{
            //    Con.Open();
            //    string query = "SELECT [ID] = P.ID,[Post] = P.[Post] FROM [Posts] AS P";
            //    SqlCommand command = new SqlCommand(query, Con);
            //    SqlDataReader reader = command.ExecuteReader();
            //    DataTable dt = new DataTable();
            //    dt.Load(reader);
            //    CB_Post.DataSource = dt;
            //    CB_Post.ValueMember = "ID";
            //    CB_Post.DisplayMember = "Post";
            //    Con.Close();
            //}
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            AddEmployeesForm form = new AddEmployeesForm();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteEmployeesForm form = new DeleteEmployeesForm();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateEmployeesForm form = new CreateEmployeesForm();
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            GetEmployees("", "","", "");
        }

        public static void SetRoundedShape(Control control, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddLine(radius, 0, control.Width - radius, 0);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddLine(control.Width, radius, control.Width, control.Height - radius);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddLine(control.Width - radius, control.Height, radius, control.Height);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            path.AddLine(0, control.Height - radius, 0, radius);
            path.AddArc(0, 0, radius, radius, 180, 90);
            control.Region = new Region(path);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text == "All")
            {
                comboText1 = "";
                GetEmployees("", "", "", comboText2);
            }
            else if (comboBox1.Text == "Мужской")
            {
                comboText1 = "WHERE G.Name = 'Мужской'";
                GetEmployees("", "", "WHERE G.Name = 'Мужской'", comboText2);
            }
            else if (comboBox1.Text == "Женский")
            {
                comboText1 = "WHERE G.Name = 'Женский'";
                GetEmployees("", "", "WHERE G.Name = 'Женский'", comboText2);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "All")
            {
                comboText2 = "";
                GetEmployees("", "", comboText1, "");
            }
            else if (comboBox2.Text == "10")
            {
                comboText2 = "TOP (10)";
                GetEmployees("", "", comboText1, "TOP (10)");
            }
            else if (comboBox2.Text == "50")
            {
                comboText2 = "TOP (50)";
                GetEmployees("", "", comboText1, "TOP (50)");
            }
            else if (comboBox2.Text == "100")
            {
                comboText2 = "TOP (100)";
                GetEmployees("", "", comboText1, "TOP (100)");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GetEmployees($"AND (C.LastName Like '{textBox1.Text}%' OR C.[FirstName] like '{textBox1.Text}%' OR C.[Patronymic] like '{textBox1.Text}%') AND (C.Phone like '%{textBox2.Text}%') AND (C.Email like '%{textBox3.Text}%')", "", comboText1, comboText2);
        }
    }
}
