namespace Tele_Health.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PATIENT_tbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PATIENT_tbl()
        {
            APPOINTMENT_tbl = new HashSet<APPOINTMENT_tbl>();
            FEEDBACK_tbl = new HashSet<FEEDBACK_tbl>();
        }

        [Key]
        public int PATIENT_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string PATIENT_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string PATIENT_CNIC { get; set; }

        [Required]
        [StringLength(50)]
        public string PATIENT_EMAIL { get; set; }

        [Required]
        [StringLength(50)]
        public string PATIENT_PASSWORD { get; set; }

        [Required]
        [StringLength(50)]
        public string PATIENT_ADDRESS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APPOINTMENT_tbl> APPOINTMENT_tbl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FEEDBACK_tbl> FEEDBACK_tbl { get; set; }
    }
}
