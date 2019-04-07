namespace GetJobsv3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JobPosting")]
    public partial class JobPosting
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public JobPosting()
        {
            Applicants = new HashSet<Applicant>();
        }

        public int JobPostingID { get; set; }

        public int JobID { get; set; }

        public int BranchID { get; set; }

        [Column(TypeName = "date")]
        public DateTime DatePosted { get; set; }

        [Required]
        [StringLength(100)]
        public string CreatedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [StringLength(100)]
        public string LastEditedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime LastEditedDate { get; set; }

        public bool IsActive { get; set; }

        [StringLength(300)]
        public string HireMgrEmail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Applicant> Applicants { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual Job Job { get; set; }
    }
}
