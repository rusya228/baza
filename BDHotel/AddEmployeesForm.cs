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

namespace BDHotel
{
    public partial class AddEmployeesForm : Form
    {
        public int idmax;
        
        public AddEmployeesForm()
        {
            InitializeComponent();
            using (SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-DEKVKMF\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security=True"))
            {
                Con.Open();
                string query = "SELECT [ID] = P.ID,[Post] = P.[Post] FROM [Posts] AS P";
                SqlCommand command = new SqlCommand(query, Con);
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                CB_Post.DataSource = dt;
                CB_Post.ValueMember = "ID";
                CB_Post.DisplayMember = "Post";
                Con.Close();
            }
            using (SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-DEKVKMF\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security=True"))
            {
                Con.Open();
                string query = "SELECT [ID] = MAX([ID]+1) FROM [Employees]";
                SqlCommand command = new SqlCommand(query, Con);
                idmax = int.Parse(command.ExecuteScalar().ToString());
                Con.Close();
            }
        }

        private void bt_Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_LName.Text))
            {
                MessageBox.Show("Заполните фамилию!");
            }
            else
            {
                if (string.IsNullOrEmpty(txt_FName.Text))
                {
                    MessageBox.Show("Заполните имя!");
                }
                else
                {
                    if (string.IsNullOrEmpty(txt_PaspNum.Text))
                    {
                        MessageBox.Show("Введите верный номер паспорта!");
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(txt_PaspSer.Text))
                        {
                            MessageBox.Show("Введите верную серию паспорта!");
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(txt_Tel.Text))
                            {
                                MessageBox.Show("Заполните номер телефона!");
                            }
                            else
                            {
                                if (dateTimePicker.Value > DateTime.Now)
                                {
                                    MessageBox.Show("Введите реальную дату рождения!");
                                }
                                else
                                {
                                    using (SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-DEKVKMF\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security=True"))
                                    {
                                        Con.Open();
                                        string query = "INSERT INTO [Employees] ([ID],[Name],[Surname],[Patronymic]) VALUES ("+ idmax + ",'" + txt_FName.Text + "','" + txt_LName.Text + "','" + txt_MName.Text + "')" +
                                                       "INSERT INTO[InformationAboutEmployees]([ID],[Born],[Tel],[PasspSerries],[PasspNumber],[PostsID]) VALUES(" + idmax + ", '" + dateTimePicker.Value + "', '" + txt_Tel.Text + "', '" + txt_PaspSer.Text + "', '" + txt_PaspNum.Text + "', "+ CB_Post.SelectedValue +")" +
                                                       "INSERT INTO[EmployeeInformation] ([ID],[InformationAboutEmployeesID],[EmployeesID]) VALUES(" + idmax + ", " + idmax + ", " + idmax + ")";
                                        SqlCommand command = new SqlCommand(query, Con);
                                        command.ExecuteNonQuery();
                                        Con.Close();
                                        this.Close();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void AddEmployeesForm_Close(object sender, FormClosedEventArgs e)
        {
            Form1 form = (Form1)Application.OpenForms[0];
            form.Show();
        }

       
    }
}
