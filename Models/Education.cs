namespace GetJobsv3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Education")]
    public partial class Education
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EdID { get; set; }

        public int ApplicantID { get; set; }

        [StringLength(100)]
        public string SchoolName { get; set; }

        [StringLength(25)]
        public string City { get; set; }

        [StringLength(25)]
        public string StateName { get; set; }

        [StringLength(10)]
        public string Zip { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        public bool? Graduate { get; set; }

        [StringLength(50)]
        public string Degree { get; set; }

        [StringLength(20)]
        public string StartY { get; set; }

        [StringLength(20)]
        public string EndY { get; set; }

        public virtual Applicant Applicant { get; set; }
    }
}
