using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using statements that are requiored to connect to EF(Entity FrameWork) DB
using COMP229_F2017_Lesson5.Models;
using System.Web.ModelBinding;

namespace COMP229_F2017_Lesson5
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /* If loading the Page for the first time 
             * Populate the Student grid view
             */
            if (!IsPostBack)
            {
                // Get the Student Data
                this.GetStudents();
            }
        }
        /// <summary>
        /// This method gets the Students data from the DB
        /// </summary>
        private void GetStudents()
        {
            // Connect  to Entity FrameWork
            using (ControlsoContext db = new ControlsoContext())
            {
                //Query the Students Table using EF and LINQ
                var Students = (from allStudents in db.Students
                                select allStudents);
                // bind the result to the Student GridView
                StudentGridView.DataSource = Students.ToList();
                StudentGridView.DataBind();
            }
        }
    }
}