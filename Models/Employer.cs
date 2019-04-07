namespace GetJobsv3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employer")]
    public partial class Employer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmpID { get; set; }

        public int ApplicantID { get; set; }

        public bool? NoWorkHis { get; set; }

        [Required]
        [StringLength(100)]
        public string Company { get; set; }

        [StringLength(50)]
        public string JobTitle { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public bool? CurrentJob { get; set; }

        [StringLength(25)]
        public string City { get; set; }

        [StringLength(25)]
        public string StateName { get; set; }

        [StringLength(30)]
        public string Phone { get; set; }

        [StringLength(30)]
        public string SuperFName { get; set; }

        [StringLength(30)]
        public string SuperLName { get; set; }

        [StringLength(1500)]
        public string JobDuties { get; set; }

        public bool? ContactEmp { get; set; }

        [StringLength(300)]
        public string ReasonLeave { get; set; }

        [StringLength(15)]
        public string StartSal { get; set; }

        [StringLength(15)]
        public string EndSal { get; set; }

        public virtual Applicant Applicant { get; set; }
    }
}
