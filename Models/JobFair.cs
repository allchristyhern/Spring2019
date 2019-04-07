namespace GetJobsv3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JobFair")]
    public partial class JobFair
    {
        public int JobFairID { get; set; }

        public int BranchID { get; set; }

        [StringLength(300)]
        public string FairDate { get; set; }

        public bool? ShowFair { get; set; }

        public virtual Branch Branch { get; set; }
    }
}
