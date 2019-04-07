namespace GetJobsv3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Branch")]
    public partial class Branch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Branch()
        {
            JobPostings = new HashSet<JobPosting>();
            JobFairs = new HashSet<JobFair>();
            JobFairBranches = new HashSet<JobFairBranch>();
        }

        public int BranchID { get; set; }

        [Required(ErrorMessage ="Branch Name is Required")]
        [StringLength(100)]
        public string BranchName { get; set; }

        [StringLength(150)]
        public string Street { get; set; }

        [StringLength(25)]
        public string City { get; set; }

        [Required(ErrorMessage = "A State is Required")]
        [StringLength(25)]
        public string StateName { get; set; }

        [StringLength(10)]
        public string Zip { get; set; }

        [StringLength(30)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [StringLength(100)]
        public string CreatedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Edit Date is Required")]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:MM-dd-yy}")]
        [StringLength(100)]
        public string LastEditedBy { get; set; }

        [Column(TypeName = "date")]
        public DateTime LastEditedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobPosting> JobPostings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobFair> JobFairs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobFairBranch> JobFairBranches { get; set; }
    }
}
