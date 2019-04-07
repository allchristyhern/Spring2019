namespace GetJobsv3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Applicant")]
    public partial class Applicant
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Applicant()
        {
            EduList = new HashSet<Education>();
            EmpList = new HashSet<Employer>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AppID { get; set; }

        public int JobPostingID { get; set; }

        [StringLength(25)]
        public string FirstName { get; set; }

        [StringLength(25)]
        public string MiddleName { get; set; }

        [StringLength(25)]
        public string LastName { get; set; }

        [StringLength(150)]
        public string Street { get; set; }

        [StringLength(25)]
        public string City { get; set; }

        [StringLength(25)]
        public string StateName { get; set; }

        [StringLength(10)]
        public string Zip { get; set; }

        [StringLength(30)]
        public string Phone1 { get; set; }

        [StringLength(30)]
        public string Phone2 { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(20)]
        public string BestWay2contact { get; set; }

        [StringLength(80)]
        public string LinkedIn { get; set; }

        [StringLength(80)]
        public string ResumeName { get; set; }

        [StringLength(200)]
        public string ResumePath { get; set; }

        [StringLength(80)]
        public string ASign { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? SubmittedDate { get; set; }

        public bool? Archive { get; set; }

        [Column(TypeName = "date")]
        public DateTime? WhenArchived { get; set; }

        public bool? Emailed { get; set; }

        [Column(TypeName = "date")]
        public DateTime? WhenEmailed { get; set; }

        [StringLength(300)]
        public string WhoEmailed { get; set; }

        public int? JobFairAttended { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Education> EduList { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employer> EmpList { get; set; }

        public virtual JobPosting JobPosting { get; set; }
    }
}
