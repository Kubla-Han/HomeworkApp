using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HomeworkApp
{
    public partial class FrmLogin : Form
    {
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=SchoolHomeworkDb;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;";

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Id, Role FROM Users WHERE Login = @login AND Password = @password";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@login", login);
                        cmd.Parameters.AddWithValue("@password", password);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                CurrentUser.UserId = reader.GetInt32(0);
                                CurrentUser.Role = reader.GetString(1);
                                if (CurrentUser.Role == "pupil")
                                {
                                    new FrmPupilMain().Show();
                                    this.Hide();
                                }
                                else if (CurrentUser.Role == "teacher")
                                {
                                    new FrmTeacherMain().Show();
                                    this.Hide();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Неверный логин или пароль.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FrmRegister().Show();
            this.Hide();
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}