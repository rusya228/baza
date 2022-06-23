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
    public partial class DeleteEmployeesForm : Form
    {
        public DeleteEmployeesForm()
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
                    Grid_EmployeesDelete.Visible = true;
                    Grid_EmployeesDelete.DataSource = dt;
                    Grid_EmployeesDelete.Update();
                    Grid_EmployeesDelete.Columns[0].Width = 80; // Код
                    Grid_EmployeesDelete.Columns[1].Width = 173; // ФИ
                    Grid_EmployeesDelete.Columns[2].Width = 150; // О
                    Grid_EmployeesDelete.Columns[3].Width = 100; // ДР
                    Grid_EmployeesDelete.Columns[4].Width = 170; // Должность
                }
                else
                {
                    Grid_EmployeesDelete.Visible = false;
                }
            }
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_Delete.Text))
            {
                MessageBox.Show("Заполните код сотрудника!");
            }
            else
            {
                if (int.TryParse(txt_Delete.Text, out var a))
                {
                    using (SqlConnection Con = new SqlConnection(@"Data Source=DESKTOP-DEKVKMF\SQLEXPRESS;Initial Catalog=Hotel;Integrated Security=True"))
                    {
                        Con.Open();
                        string query = "DELETE FROM [Employees] WHERE [ID] = "+txt_Delete.Text+" "+
                                       "DELETE FROM [InformationAboutEmployees] WHERE [ID] = " + txt_Delete.Text + "";
                        SqlCommand command = new SqlCommand(query, Con);
                        command.ExecuteNonQuery();
                        Con.Close();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Введите верный код сотрудника!");
                }
            }
        }

        private void DeleteEmployeesForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 form = (Form1)Application.OpenForms[0];
            form.Show();
        }
    }
}
