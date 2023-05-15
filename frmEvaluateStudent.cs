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
    public partial class frmEvaluateStudent : Form
    {
        Student Evaluatingstudent = new Student();
        private object cboActivities;

        public frmEvaluateStudent(Student student)
        {
            InitializeComponent();
            Evaluatingstudent = student;
        }

        private void frmEvaluateStudent_Load(object sender, EventArgs e)
        {
            this.Text = Evaluatingstudent.FirstName +" "+ Evaluatingstudent.LastName;
            cboActivity.DataSource = ActivitiesRepository.GetActivities();

            this.txtEvaluationDate.Text = DateTime.Now.ToString();

        }

        private void cboActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentActivity = cboActivity.SelectedItem as Activity;
            txtActivityDescription.Text = currentActivity.Description;
            txtMinForGrade.Text = currentActivity.MinPointsForGrade + "/" +
           currentActivity.MaxPoints;
            txtMinForSignature.Text = currentActivity.MinPointsForSignature + "/" +
           currentActivity.MaxPoints;
            numPoints.Minimum = 0;
            numPoints.Maximum = currentActivity.MaxPoints;


            var evaluation = EvaluationRepository.GetEvaluation(Evaluatingstudent, currentActivity);

            if(evaluation != null)
            {
                txtTeacher.Text = evaluation.Evaluator.ToString();

                txtEvaluationDate.Text = evaluation.EvaluationDate.ToString();

                numPoints.Value = evaluation.Points;
            }
            else
            {
                txtTeacher.Text = FrmLogin.LoggedTeacher.ToString();
                txtEvaluationDate.Text = "";
                numPoints.Value = 0;
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
