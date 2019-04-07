using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using GetJobsv3.Models;

namespace GetJobsv3.Controllers
{
    public class ApplyController : Controller
    {
        GetJobsModel db = new GetJobsModel();

        #region display job posts
        // GET: Apply
        public ActionResult DisplayJobPosts()
        {
            var posts = GetAllActivePost();
            if(posts != null)
            {
                return View(posts);
            }
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        IEnumerable<Job> GetJobList()
        {
            return db.Jobs.ToList<Job>();
        }
        public List<Job> GetAllActivePost()
        {
            //get db info from GetJobModel for job posting
            List<JobPosting> jpList = db.JobPostings.ToList();
            //get db info from GetJobModel for job via the IEnumerable method
            IEnumerable<Job> jList = GetJobList();
            //create a list to store only the active job posts
            List<Job> activeJobList = new List<Job>();
            foreach(var jp in jpList)
            {
                //if job posting is active 
                if(jp.IsActive)
                {
                    foreach(var j in jList)
                    {
                        //job posting's job id matches job's job id
                        if(jp.JobID == j.jobID)
                        {
                            //add it to the active list
                            activeJobList.Add(j);
                        }
                    }
                }
            }
            return activeJobList;

        }
        #endregion



    }
}