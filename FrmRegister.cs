using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HomeworkApp
{
    public partial class FrmRegister : Form
    {
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=SchoolHomeworkDb;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;";

        public FrmRegister()
        {
            InitializeComponent();
            cmbRole.Items.Add("pupil");
            cmbRole.Items.Add("teacher");
            LoadClasses();
        }
        private void LoadClasses()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT Id, Name FROM Classes ORDER BY Name";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbClass.DataSource = dt;
                    cmbClass.DisplayMember = "Name";
                    cmbClass.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить классы: " + ex.Message);
            }
        }
        private void FrmRegister_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string q = "SELECT Id, Name FROM Classes ORDER BY Name";
                SqlDataAdapter da = new SqlDataAdapter(q, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbClass.DataSource = dt;
                cmbClass.DisplayMember = "Name";
                cmbClass.ValueMember = "Id";
            }
        }
        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isPupil = cmbRole.SelectedItem?.ToString() == "pupil";

            lblClass.Visible = isPupil;
            cmbClass.Visible = isPupil;

            // Если не ученик — сбрасываем выбор
            if (!isPupil)
            {
                cmbClass.SelectedIndex = -1;
            }
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string role = cmbRole.SelectedItem as string;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Заполните все поля.");
                return;
            }
            int? classId = null;
            if (role == "pupil")
            {
                if (cmbClass.SelectedValue == null)
                {
                    MessageBox.Show("Ученик должен быть привязан к классу.");
                    return;
                }
                classId = Convert.ToInt32(cmbClass.SelectedValue);
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO Users (Login, Password, FullName, Role, ClassId) VALUES (@login, @password, @fullName, @role, @classId)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@login", login);
                        cmd.Parameters.AddWithValue("@password", password);
                        cmd.Parameters.AddWithValue("@fullName", fullName);
                        cmd.Parameters.AddWithValue("@role", role);
                        cmd.Parameters.AddWithValue("@classId", (object)classId ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Регистрация успешна.");
                new FrmLogin().Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new FrmLogin().Show();
            this.Hide();
        }

        private void FrmRegister_Load_1(object sender, EventArgs e)
        {

        }
    }
}