namespace Tele_Health.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FEEDBACK_tbl
    {
        [Key]
        public int P_FEEDBACK_ID { get; set; }

        public int PATIENT_FID { get; set; }

        public int DOCTOR_FID { get; set; }

        public int HOSPITAL_FID { get; set; }

        [Required]
        [StringLength(300)]
        public string P_FEEDBACK_DETAIL { get; set; }

        public DateTime P_FEEDBACK_DATE { get; set; }

        public DateTime P_FEEDBACK_TIME { get; set; }

        public virtual DOCTOR_tbl DOCTOR_tbl { get; set; }

        public virtual PATIENT_tbl PATIENT_tbl { get; set; }
    }
}
