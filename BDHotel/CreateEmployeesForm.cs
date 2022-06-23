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
    public partial class CreateEmployeesForm : Form
    {
        public CreateEmployeesForm()
        {
            InitializeComponent();
            using (SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-DEKVKMF\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security=True"))
            {
                Con.Open();
                string query = "SELECT" +
                                "[Код сотрудника] = E.[ID]," +
                                "[Полное имя] = E.[Name] + ' ' + E.[Surname]," +
                                "[Отчество] = [Patronymic]," +
                                "[Дата рождения] = IAE.[Born]," +
                                "[Должность] = P.[Post] " +
                                "FROM [Employees] AS E " +
                                "JOIN [EmployeeInformation] AS EI ON E.ID = EI.EmployeesID " +
                                "JOIN [InformationAboutEmployees] AS IAE ON EI.InformationAboutEmployeesID = IAE.ID " +
                                "JOIN[Posts] AS P ON IAE.PostsID = P.ID "+
                                "ORDER BY E.[ID] ASC";
                SqlCommand command = new SqlCommand(query, Con);
                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                Con.Close();
                if (dt.Rows.Count != 0)
                {
                    Grid_EmployeesCreate.Visible = true;
                    Grid_EmployeesCreate.DataSource = dt;
                    Grid_EmployeesCreate.Update();
                    Grid_EmployeesCreate.Columns[0].Width = 80; // Код
                    Grid_EmployeesCreate.Columns[1].Width = 173; // ФИ
                    Grid_EmployeesCreate.Columns[2].Width = 150; // Очество
                    Grid_EmployeesCreate.Columns[3].Width = 100; // ДР
                    Grid_EmployeesCreate.Columns[4].Width = 170; // Должность
                }
                else
                {
                    Grid_EmployeesCreate.Visible = false;
                }
            }
        }

        private void CreateEmployeesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form = (Form1)Application.OpenForms[0];
            form.Show();
        }

        public void CreateEmployees(string a)
        {
            using (SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-DEKVKMF\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security=True"))
            {
                Con.Open();
                string query = $"UPDATE [Employees] " +
                               $"SET {a} " +
                               $"WHERE[ID] = {txt_ID.Text}";
                SqlCommand command = new SqlCommand(query, Con);
                command.ExecuteNonQuery();
                Con.Close();
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_ID.Text))
            {
                MessageBox.Show("Введите Код сотрудника");
            }
            else
            {
                if (string.IsNullOrEmpty(txt_LName.Text))
                {
                    MessageBox.Show("Заполните фамилию!\nЕсли не хотите изменять фамилию, то введите в строку '-'");
                }
                else
                {
                    if (string.IsNullOrEmpty(txt_FName.Text))
                    {
                        MessageBox.Show("Заполните имя!\nЕсли не хотите изменять отчество, то введите в строку '-'");
                    }
                    else
                    {
                        if ((txt_LName.Text != "-") && (txt_FName.Text != "-") && (txt_MName.Text != "-"))
                        {
                            CreateEmployees($"[Name] = '{txt_FName.Text}',[Surname] = '{txt_LName.Text}' ,[Patronymic] = '{txt_MName.Text}'");
                        }
                        else if ((txt_FName.Text == "-")&&(txt_LName.Text != "-") && (txt_MName.Text != "-"))
                        {
                            CreateEmployees($"[Surname] = '{txt_LName.Text}' ,[Patronymic] = '{txt_MName.Text}'");
                        }
                        else if ((txt_LName.Text == "-")&& (txt_FName.Text != "-")&& (txt_MName.Text != "-"))
                        {
                            CreateEmployees($"[Name] = '{txt_FName.Text}',[Patronymic] = '{txt_MName.Text}'");
                        }
                        else if ((txt_LName.Text != "-") && (txt_FName.Text != "-") && (txt_MName.Text == "-"))
                        {
                            CreateEmployees($"[Name] = '{txt_FName.Text}',[Surname] = '{txt_LName.Text}'");
                        }
                        else if ((txt_LName.Text == "-") && (txt_FName.Text == "-") && (txt_MName.Text != "-"))
                        {
                            CreateEmployees($"[Patronymic] = '{txt_MName.Text}'");
                        }
                        else if ((txt_LName.Text != "-") && (txt_FName.Text == "-") && (txt_MName.Text == "-"))
                        {
                            CreateEmployees($"[Surname] = '{txt_LName.Text}'");
                        }
                        else if ((txt_LName.Text == "-") && (txt_FName.Text != "-") && (txt_MName.Text == "-"))
                        {
                            CreateEmployees($"[Name] = '{txt_FName.Text}'");
                        }
                    }
                }
            }
            
        }
    }
}
