using Evaluation_Manager.Models;
using Evaluation_Manager.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Evaluation_Manager
{
    public partial class FrmStudents : Form
    {
        public FrmStudents()
        {
            InitializeComponent();
        }

        private void FrmStudents_Load(object sender, EventArgs e)
        {
            dgvStudents.DataSource = null;
            dgvStudents.DataSource = StudentRepository.GetStudents();
            dgvStudents.Columns["Id"].DisplayIndex = 0;
            dgvStudents.Columns["FirstName"].DisplayIndex = 1;
            dgvStudents.Columns["LastName"].DisplayIndex = 2;
            dgvStudents.Columns["Grade"].DisplayIndex = 3;


        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void btnEvaluateStudent_Click(object sender, EventArgs e)
        {
            Student student = new Student();

            if(dgvStudents.CurrentRow.Visible != null)
            {
                student = dgvStudents.CurrentRow.DataBoundItem as Student;
            }

            frmEvaluateStudent frmEvaluateStudent = new frmEvaluateStudent(student);

            frmEvaluateStudent.ShowDialog();


        }
    }
}
