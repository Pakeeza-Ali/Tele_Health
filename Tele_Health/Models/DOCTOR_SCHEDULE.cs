namespace Tele_Health.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DOCTOR_SCHEDULE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOCTOR_SCHEDULE()
        {
            APPOINTMENT_tbl = new HashSet<APPOINTMENT_tbl>();
        }

        [Key]
        public int SCHEDULE_ID { get; set; }

        public int DOCTOR_FID { get; set; }

        [Required]
        [StringLength(50)]
        public string TOTAL_APPOINTMENTS { get; set; }

        public DateTime TIME { get; set; }

        public DateTime DATE { get; set; }

        [Required]
        [StringLength(50)]
        public string DAY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APPOINTMENT_tbl> APPOINTMENT_tbl { get; set; }

        public virtual DOCTOR_tbl DOCTOR_tbl { get; set; }
    }
}
