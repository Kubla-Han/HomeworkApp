using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HomeworkApp
{
    public partial class FrmHomeworkViewEdit : Form
    {
        private string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=SchoolHomeworkDb;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=False;";
        public bool IsEdit { get; set; }
        public int HomeworkId { get; set; }

        public FrmHomeworkViewEdit()
        {
            InitializeComponent();
            LoadCombos();
        }

        private void LoadCombos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Subjects
                    string qSubjects = "SELECT Id, Name FROM Subjects";
                    SqlDataAdapter daSubjects = new SqlDataAdapter(qSubjects, conn);
                    DataTable dtSubjects = new DataTable();
                    daSubjects.Fill(dtSubjects);
                    cmbSubject.DataSource = dtSubjects;
                    cmbSubject.DisplayMember = "Name";
                    cmbSubject.ValueMember = "Id";

                    // Classes
                    string qClasses = "SELECT Id, Name FROM Classes";
                    SqlDataAdapter daClasses = new SqlDataAdapter(qClasses, conn);
                    DataTable dtClasses = new DataTable();
                    daClasses.Fill(dtClasses);
                    cmbClass.DataSource = dtClasses;
                    cmbClass.DisplayMember = "Name";
                    cmbClass.ValueMember = "Id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void LoadData()
        {
            if (!IsEdit) return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT SubjectId, ClassId, Title, Task, DueDate FROM Homework WHERE Id = @id";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", HomeworkId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                cmbSubject.SelectedValue = reader["SubjectId"];
                                cmbClass.SelectedValue = reader["ClassId"];
                                txtTitle.Text = reader["Title"].ToString();
                                rtbTask.Text = reader["Task"].ToString();
                                dtpDueDate.Value = reader.GetDateTime(4);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            int? subjectId = cmbSubject.SelectedValue as int?;
            int? classId = cmbClass.SelectedValue as int?;
            string title = txtTitle.Text.Trim();
            string task = rtbTask.Text.Trim();
            DateTime dueDate = dtpDueDate.Value;

            if (cmbClass.SelectedValue == null)
            {
                MessageBox.Show("Выберите класс, для которого задаётся задание!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(task))
            {
                MessageBox.Show("Заполните текст задания.");
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query;
                    if (IsEdit)
                    {
                        query = @"
                            UPDATE Homework SET SubjectId = @subjectId, ClassId = @classId, Title = @title, Task = @task, DueDate = @dueDate
                            WHERE Id = @id AND TeacherId = @teacherId";
                    }
                    else
                    {
                        query = @"
                            INSERT INTO Homework (SubjectId, ClassId, Title, Task, DueDate, TeacherId)
                            VALUES (@subjectId, @classId, @title, @task, @dueDate, @teacherId)";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@subjectId", (object)subjectId ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@classId", (object)classId ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@title", title);
                        cmd.Parameters.AddWithValue("@task", task);
                        cmd.Parameters.AddWithValue("@dueDate", dueDate);
                        cmd.Parameters.AddWithValue("@teacherId", CurrentUser.UserId);
                        if (IsEdit) cmd.Parameters.AddWithValue("@id", HomeworkId);

                        cmd.ExecuteNonQuery();
                    }
                }
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FrmHomeworkViewEdit_Load(object sender, EventArgs e)
        {
            if (IsEdit) LoadData();
        }
    }
}