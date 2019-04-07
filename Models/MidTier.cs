using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace GetJobsv3.Models
{
    public class MidTier
    {   //sql command object  
        SqlCommand scmd = new SqlCommand();
        //sql connection
        SqlConnection sconn = new SqlConnection();

        //constructor
        public MidTier()
        {
            //database connection string
            sconn.ConnectionString = "Data Source=DARTHMAL\\DARTHMALEXPRESS;Initial Catalog=GetJobsv3;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        }
        //method to call database and get the active job posts
        //returns datareader that is called in the ApplicantController
        public SqlDataReader GetJobPosts()
        {
            try
            {
                sconn.Open();
                scmd.Connection = sconn;
                scmd.CommandType = CommandType.StoredProcedure;
                scmd.CommandText = "getJobPosting_sp";
                scmd.Parameters.Clear();
                return scmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch(SqlException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public SqlDataReader ActiveJobPostings()
        {
            try
            {
                sconn.Close();
                sconn.Open(); //open the connection
                scmd.Connection = sconn; //set the command connection property to the connection
                scmd.CommandType = CommandType.StoredProcedure; //specify the command type as Stored Procedure
                scmd.CommandText = "ActiveListings_sp"; //the name of the stored procedure
                scmd.Parameters.Clear(); //clear out any existing parameters

                return scmd.ExecuteReader(CommandBehavior.CloseConnection); //execute the command, and close connection when done
            }
            catch(SqlException) //catch any SQL exceptions that get thrown
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public SqlDataReader PostByID(int postID)
        {
            try
            {
                sconn.Close();
                sconn.Open(); //open the connection
                scmd.Connection = sconn; //set the command connection property to the connection
                scmd.Parameters.Clear(); //clear out any existing parameters
                scmd.CommandType = CommandType.StoredProcedure; //specify the command type as Stored Procedure
                scmd.CommandText = "PostByID_sp"; //the name of the stored procedure          
                scmd.Parameters.Add("@PostID" , SqlDbType.Int).Value = postID;
                return scmd.ExecuteReader(CommandBehavior.CloseConnection); //execute the command, and close connection when done
            }
            catch(SqlException) //catch any SQL exceptions that get thrown
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public SqlDataReader getStates()
        {
            try
            {
                sconn.Close();
                sconn.Open(); //open the connection
                scmd.Connection = sconn; //set the command connection property to the connection
                scmd.CommandType = CommandType.StoredProcedure; //specify the command type as Stored Procedure
                scmd.CommandText = "GetStates_sp"; //the name of the stored procedure
                scmd.Parameters.Clear(); //clear out any existing parameters

                return scmd.ExecuteReader(CommandBehavior.CloseConnection); //execute the command, and close connection when done
            }
            catch(SqlException) //catch any SQL exceptions that get thrown
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public SqlDataReader getResumeReq(string jobTitle)
        {
            try
            {
                sconn.Close();
                sconn.Open(); //open the connection

                scmd.Connection = sconn; //set the command connection property to the connection
                scmd.CommandType = CommandType.StoredProcedure; //specify the command type as Stored Procedure
                scmd.CommandText = "getResumeReq_sp"; //the name of the stored procedure
                scmd.Parameters.Clear(); //clear out any existing parameters
                scmd.Parameters.Add("@JobTitle" , SqlDbType.VarChar , 100).Value = jobTitle;

                return scmd.ExecuteReader(CommandBehavior.CloseConnection); //execute the command, and close connection when done

            }
            catch(SqlException) //catch any sql exceptions that get thrown
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }

        }

        public SqlDataReader getBranches()
        {
            try
            {
                sconn.Close();
                sconn.Open(); //open the connection
                scmd.Connection = sconn; //set the command connection property to the connection
                scmd.Parameters.Clear();
                scmd.CommandType = CommandType.StoredProcedure; //specify stored procedure
                scmd.CommandText = "GetBranches_sp";
                return scmd.ExecuteReader(CommandBehavior.CloseConnection); //execute the command, and close connection when done

            }
            catch(SqlException)
            {
                throw;

            }
            catch(Exception)
            {
                throw;
            }
        }

        public int insertApplicant(int jpID , string afname , string amname , string alname , string astreet , string acity , string astate , string azip , string aph1 , string aph2 , string aemail , string abest , string alink , string aresna , string aresp , string asign , DateTime? asub , int archive , int emailed)
        {
            try
            {
                sconn.Close();
                sconn.Open(); //open the sql connection
                scmd.Connection = sconn; //set the sql command connection to the sql connection
                scmd.CommandType = CommandType.StoredProcedure; //set the command type to stored procedure
                scmd.CommandText = "InsertApplicant_ip"; //enter the name of the stored procedure
                scmd.Parameters.Clear(); //clear the parameters list
                                         //set up the parameters to be used (default mode is be input parameters)
                scmd.Parameters.Add("@jobPostingID" , SqlDbType.Int).Value = jpID;
                scmd.Parameters.Add("@firstName" , SqlDbType.VarChar , 25).Value = afname;
                scmd.Parameters.Add("@middleName" , SqlDbType.VarChar , 25).Value = amname;
                scmd.Parameters.Add("@lastName" , SqlDbType.VarChar , 25).Value = alname;

                scmd.Parameters.Add("@street" , SqlDbType.VarChar , 150).Value = astreet;
                scmd.Parameters.Add("@city" , SqlDbType.VarChar , 25).Value = acity;
                scmd.Parameters.Add("@stateName" , SqlDbType.VarChar , 25).Value = astate;
                scmd.Parameters.Add("@zip" , SqlDbType.VarChar , 10).Value = azip;
                scmd.Parameters.Add("@phone1" , SqlDbType.VarChar , 30).Value = aph1;
                scmd.Parameters.Add("@phone2" , SqlDbType.VarChar , 30).Value = aph2;
                scmd.Parameters.Add("@email" , SqlDbType.VarChar , 30).Value = aemail;

                scmd.Parameters.Add("@bestWay2contact" , SqlDbType.VarChar , 20).Value = abest;
                scmd.Parameters.Add("@linkedIn" , SqlDbType.VarChar , 80).Value = alink;
                scmd.Parameters.Add("@resumeName" , SqlDbType.VarChar , 80).Value = aresna;
                scmd.Parameters.Add("@resumePath" , SqlDbType.VarChar , 200).Value = aresp;

                scmd.Parameters.Add("@aSign" , SqlDbType.VarChar , 80).Value = asign;
                scmd.Parameters.Add("@submittedDate" , SqlDbType.DateTime).Value = asub;
                scmd.Parameters.Add("@archive" , SqlDbType.Bit).Value = archive;
                scmd.Parameters.Add("@emailed" , SqlDbType.Bit).Value = emailed;

                int scopeIdent = Convert.ToInt32(scmd.ExecuteScalar()); //execute the command
                                                                        //int rowCount = Convert.ToInt32(scmd.ExecuteScalar());
                return scopeIdent; //return the value returned from the scaler execution 

            }
            catch(SqlException)
            {
                return -1;
            }
            catch(Exception)
            {
                return -1;
            }
            finally
            {
                sconn.Close(); //close the connection
            }
        }

        public int insertEmployer(int appID , int emnohis , string emcom , string emjti , DateTime? emstar , DateTime? emend , int emcur , string emcit , string emsta , string emph , string emfn , string emln , string emdut , int emcont , string emleav , string startS , string endS)
        {
            try
            {
                sconn.Close();
                sconn.Open(); //open the sql connection
                scmd.Connection = sconn; //set the sql command connection to the sql connection
                scmd.CommandType = CommandType.StoredProcedure; //set the command type to stored procedure
                scmd.CommandText = "InsertEmployer_ip"; //enter the name of the stored procedure
                scmd.Parameters.Clear(); //clear the parameters list
                                         //set up the parameters to be used (default mode is be input parameters)
                scmd.Parameters.Add("@applicantID" , SqlDbType.Int).Value = appID;
                scmd.Parameters.Add("@noWorkHis" , SqlDbType.Bit).Value = emnohis;
                scmd.Parameters.Add("@company" , SqlDbType.VarChar , 100).Value = emcom;
                scmd.Parameters.Add("@jobTitle" , SqlDbType.VarChar , 50).Value = emjti;
                scmd.Parameters.Add("@startDate" , SqlDbType.Date).Value = emstar;
                scmd.Parameters.Add("@endDate" , SqlDbType.Date).Value = emend;
                scmd.Parameters.Add("@currentJob" , SqlDbType.Bit).Value = emcur;
                scmd.Parameters.Add("@city" , SqlDbType.VarChar , 25).Value = emcit;
                scmd.Parameters.Add("@stateName" , SqlDbType.VarChar , 25).Value = emsta;
                scmd.Parameters.Add("@phone" , SqlDbType.VarChar , 30).Value = emph;
                scmd.Parameters.Add("@superFName" , SqlDbType.VarChar , 30).Value = emfn;
                scmd.Parameters.Add("@superLName" , SqlDbType.Char , 30).Value = emln;
                scmd.Parameters.Add("@jobDuties" , SqlDbType.VarChar , 1500).Value = emdut;
                scmd.Parameters.Add("@contactEmp" , SqlDbType.Bit).Value = emcont;
                scmd.Parameters.Add("@reasonLeave" , SqlDbType.VarChar , 300).Value = emleav;
                scmd.Parameters.Add("@startSal" , SqlDbType.VarChar , 15).Value = startS;
                scmd.Parameters.Add("@endSal " , SqlDbType.VarChar , 15).Value = endS;

                int scopeIdent = Convert.ToInt32(scmd.ExecuteScalar()); //execute the command
                return scopeIdent; //return the value returned from the scaler execution 
            }
            catch(SqlException)
            {
                return -1;
            }
            catch(Exception)
            {
                return -1;
            }
            finally
            {
                sconn.Close(); //close the connection
            }
        }

        public int insertEducation(int appID , string edname , string edcity , string edsta , string edzip , DateTime? edstar , DateTime? edend , int edgrad , string eddeg)
        {
            try
            {
                sconn.Close();
                sconn.Open(); //open the sql connection
                scmd.Connection = sconn; //set the sql command connection to the sql connection
                scmd.CommandType = CommandType.StoredProcedure; //set the command type to stored procedure
                scmd.CommandText = "InsertEducation_ip"; //enter the name of the stored procedure
                scmd.Parameters.Clear(); //clear the parameters list
                                         //set up the parameters to be used (default mode is be input parameters
                scmd.Parameters.Add("@applicantID" , SqlDbType.Int).Value = appID;
                scmd.Parameters.Add("@schoolName" , SqlDbType.VarChar , 100).Value = edname;

                scmd.Parameters.Add("@city" , SqlDbType.VarChar , 25).Value = edcity;
                scmd.Parameters.Add("@stateName" , SqlDbType.VarChar , 25).Value = edsta;
                scmd.Parameters.Add("@zip" , SqlDbType.VarChar , 10).Value = edzip;
                scmd.Parameters.Add("@startDate" , SqlDbType.Date).Value = edstar;
                scmd.Parameters.Add("@endDate" , SqlDbType.Date).Value = edend;
                scmd.Parameters.Add("@graduate" , SqlDbType.Bit).Value = edgrad;
                scmd.Parameters.Add("@degree" , SqlDbType.VarChar , 50).Value = eddeg;
                int scopeIdent = Convert.ToInt32(scmd.ExecuteScalar()); //execute the command
                return scopeIdent; //return the value returned from the scaler execution 

            }
            catch(SqlException)
            {
                return -1;
            }
            catch(Exception)
            {
                return -1;
            }
            finally
            {
                sconn.Close(); //close the connection
            }
        }
    }
}