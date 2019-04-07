namespace GetJobsv3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Job")]
    public partial class Job
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Job()
        {
            JobPostings = new List<JobPosting>();
        }

        public int jobID { get; set; }

        [Required]
        [StringLength(100)]
        public string JobTitle { get; set; }

        public string Description { get; set; }

        public string PreferredSkills { get; set; }

        public string EoeMessage { get; set; }

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

        public bool? ResumeRequired { get; set; }

        public bool? Delete_flag { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<JobPosting> JobPostings { get; set; }

       
    }
}
