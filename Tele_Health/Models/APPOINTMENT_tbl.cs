namespace Tele_Health.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class APPOINTMENT_tbl
    {
        [Key]
        public int APPOINTMENT_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string APPOINTMENT_NO { get; set; }

        public DateTime APPOINTMENT_DATE { get; set; }

        public int DOCTOR_FID { get; set; }

        public int PATIENT_FID { get; set; }

        public int SCHEDULE_FID { get; set; }

        public virtual DOCTOR_SCHEDULE DOCTOR_SCHEDULE { get; set; }

        public virtual PATIENT_tbl PATIENT_tbl { get; set; }
    }
}
