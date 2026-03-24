using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HomeworkApp
{
    public partial class FrmTeacherMain : Form
    {
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=SchoolHomeworkDb;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False";

        public FrmTeacherMain()
        {
            InitializeComponent();
            LoadHomework();
        }

        private void LoadHomework()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT h.Id, s.Name AS Subject, c.Name AS Class, h.Title, h.Task, h.DueDate
                        FROM Homework h
                        LEFT JOIN Subjects s ON h.SubjectId = s.Id
                        LEFT JOIN Classes c ON h.ClassId = c.Id
                        WHERE h.TeacherId = @teacherId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@teacherId", CurrentUser.UserId);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvHomework.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new FrmHomeworkViewEdit { IsEdit = false }.ShowDialog();
            LoadHomework();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvHomework.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvHomework.CurrentRow.Cells["Id"].Value);
            new FrmHomeworkViewEdit { IsEdit = true, HomeworkId = id }.ShowDialog();
            LoadHomework();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvHomework.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvHomework.CurrentRow.Cells["Id"].Value);
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM Homework WHERE Id = @id AND TeacherId = @teacherId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@teacherId", CurrentUser.UserId);
                        cmd.ExecuteNonQuery();
                    }
                }
                LoadHomework();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            CurrentUser.Clear();
            new FrmLogin().Show();
            this.Close();
        }

        private void FrmTeacherMain_Load(object sender, EventArgs e)
        {

        }
    }
}