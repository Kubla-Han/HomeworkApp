using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HomeworkApp
{
    public partial class FrmPupilMain : Form
    {
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=SchoolHomeworkDb;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;";

        public FrmPupilMain()
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
                        SELECT h.Id, s.Name AS Subject, h.Title, h.Task, h.DueDate, 
                               CASE WHEN hc.IsDone = 1 THEN 'Да' ELSE 'Нет' END AS Выполнено,
                               ISNULL(hc.Mark, '-') AS Оценка
                        FROM Homework h
                        LEFT JOIN Subjects s ON h.SubjectId = s.Id
                        LEFT JOIN HomeworkCompletion hc ON h.Id = hc.HomeworkId AND hc.PupilId = @pupilId
                        WHERE h.ClassId = (SELECT ClassId FROM Users WHERE Id = @pupilId)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@pupilId", CurrentUser.UserId);
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

        private void btnMarkDone_Click(object sender, EventArgs e)
        {
            if (dgvHomework.CurrentRow == null) return;

            int hwId = Convert.ToInt32(dgvHomework.CurrentRow.Cells["Id"].Value);

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        IF EXISTS (SELECT 1 FROM HomeworkCompletion WHERE HomeworkId = @hwId AND PupilId = @pupilId)
                            UPDATE HomeworkCompletion SET IsDone = 1, SubmittedAt = GETDATE() WHERE HomeworkId = @hwId AND PupilId = @pupilId
                        ELSE
                            INSERT INTO HomeworkCompletion (HomeworkId, PupilId, IsDone, SubmittedAt) VALUES (@hwId, @pupilId, 1, GETDATE())";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@hwId", hwId);
                        cmd.Parameters.AddWithValue("@pupilId", CurrentUser.UserId);
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

        private void FrmPupilMain_Load(object sender, EventArgs e)
        {

        }
    }
}