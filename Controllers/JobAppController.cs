using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GetJobsv3.Models;
using System.Net;

namespace GetJobsv3.Controllers
{
    public class JobAppController : Controller
    {
        Applicant a = new Applicant();
        List<Employer> empList = new List<Employer>();
        //create list to hold all the active postings
        List<JobPosting> jpList = new List<JobPosting>();
        //instantiate MidTier to access its methods 
        MidTier mt = new MidTier();

        //dbContext created by Entity Framework
        private GetJobsModel db = new GetJobsModel();
      
        // GET: JobApp
        public ActionResult ViewAllJobPostings()
        {
            var posts = GetAllPosts();
            if(posts != null)
            {
                return View(posts);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

        }
        public List<Job> GetAllPosts()
        {
            List<JobPosting> jpList = db.JobPostings.ToList();
            IEnumerable<Job> jList = GetJobs();
            List<Job> activePosts = new List<Job>();
            foreach(var jp in jpList)
            {
                foreach(var j in jList)
                {
                    if(jp.IsActive)
                    {
                        activePosts.Add(j);
                    }

                }
            }
            return activePosts;
        }
        IEnumerable<Job> GetJobs()
        {
          return db.Jobs.ToList<Job>();  
        }


        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job =  db.Jobs.Find(id);
            if(job == null)
            {
                return HttpNotFound();
            }         
            return View(job);
        }

        public ActionResult Apply()
        {          
            Applicant a = new Applicant();                    
            return View(a);
        }
       

        public void insertApp()
        {


            int archive = 0;
            int emailed = 0;
            //call db to insert applicant
            int insertEmp = 0, insertEdu = 0;
            int insertApp = mt.insertApplicant(a.JobPostingID , a.FirstName , a.MiddleName , a.LastName , a.Street , a.City , a.StateName , a.Zip , a.Phone1 , a.Phone2 , a.Email , a.BestWay2contact , a.LinkedIn , a.ResumeName , a.ResumePath , a.ASign , a.SubmittedDate , archive , emailed);
            if(insertApp < 0)
            {
                return;

            }
            #region work history pages
            int emnohis = 0; int emcur = 0; int emcont = 0;
            string emcom = ""; string emjti = ""; string emcit = ""; string emsta = ""; string emph = ""; string emfn = ""; string emln = ""; string emdut = ""; string emleav = ""; string startS = ""; string endS = "";
            DateTime? emstar; DateTime? emend;
            if(a.EmpList != null && a.EmpList.Count() > 0)
            {
                foreach(Employer em in a.EmpList)
                {
                    if(em.NoWorkHis == true)
                    {
                        break;
                    }
                    if(em.NoWorkHis == false)
                    {
                        if(String.IsNullOrEmpty(em.Company))
                        {
                            emcom = DBNull.Value.ToString();
                        }
                        else { emcom = em.Company; }
                        if(String.IsNullOrEmpty(em.JobTitle))
                        {
                            emjti = DBNull.Value.ToString();
                        }
                        else { emjti = em.JobTitle; }

                        emstar = em.StartDate;
                        emend = em.EndDate;
                        if(String.IsNullOrEmpty(em.City))
                        {
                            emcit = DBNull.Value.ToString();
                        }
                        else { emcit = em.City; }

                        if(String.IsNullOrEmpty(em.StateName))
                        {
                            emsta = DBNull.Value.ToString();
                        }
                        else { emsta = em.StateName; }

                        if(String.IsNullOrEmpty(em.Phone))
                        {
                            emph = DBNull.Value.ToString();
                        }
                        else { emph = em.Phone; }

                        if(String.IsNullOrEmpty(em.SuperFName))
                        {
                            emfn = DBNull.Value.ToString();
                        }
                        else { emfn = em.SuperFName; }

                        if(String.IsNullOrEmpty(em.SuperLName))
                        {
                            emln = DBNull.Value.ToString();
                        }
                        else { emln = em.SuperLName; }

                        if(String.IsNullOrEmpty(em.JobDuties))
                        {
                            emdut = DBNull.Value.ToString();
                        }
                        else
                        {
                            emdut = em.JobDuties;
                        }
                        if(String.IsNullOrEmpty(em.ReasonLeave))
                        {
                            emleav = DBNull.Value.ToString();
                        }
                        else
                        {
                            emleav = em.ReasonLeave;
                        }
                        if(em.CurrentJob == true)
                        {
                            emcur = 1;
                        }
                        if(em.ContactEmp == true)
                        {
                            emcont = 1;
                        }
                        if(String.IsNullOrEmpty(em.StartSal))
                        {
                            startS = DBNull.Value.ToString();
                        }
                        else { startS = em.StartSal; }
                        if(String.IsNullOrEmpty(em.EndSal))
                        {
                            endS = DBNull.Value.ToString();
                        }
                        else { endS = em.EndSal; }
                        //End work history
                        //call db to insert each employer
                        insertEmp = mt.insertEmployer(insertApp , emnohis , emcom , emjti , emstar , emend , emcur , emcit , emsta , emph , emfn , emln , emdut , emcont , emleav , startS , endS);
                        if(insertEmp < 0)
                        {
                            return;
                        }

                    }
                    #region education
                    //education page
                    string edname = "", edcity = "", edsta = "", edzip = "", eddeg = "";
                    DateTime? edstar, edend;
                    int edgrad = 0;
                    foreach(Education ed in a.EduList)
                    {
                        if(!String.IsNullOrEmpty(ed.SchoolName))
                        {
                            edname = ed.SchoolName;
                            edcity = ed.City;
                            edsta = ed.StateName;
                            edzip = ed.Zip;
                            edstar = ed.StartDate;
                            edend = ed.EndDate;
                            if(ed.Graduate == true)
                            {
                                edgrad = 1;
                            }
                            eddeg = ed.Degree;
                            //call db insert each education
                            insertEdu = mt.insertEducation(insertApp , edname , edcity , edsta , edzip , edstar , edend , edgrad , eddeg);
                            if(insertEdu < 0)
                            {
                                return;
                            }
                        }

                    }
                    #endregion
                    if(insertApp > 0)
                    {

                    }
                    else
                    {

                    }


                }

            }
            #endregion

        }
    }
}