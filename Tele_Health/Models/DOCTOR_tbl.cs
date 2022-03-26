namespace Tele_Health.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DOCTOR_tbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DOCTOR_tbl()
        {
            DOCTOR_SCHEDULE = new HashSet<DOCTOR_SCHEDULE>();
            FEEDBACK_tbl = new HashSet<FEEDBACK_tbl>();
        }

        [Key]
        public int DOCTOR_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string DOCTOR_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string DOCTOR_CNIC { get; set; }

        [Required]
        [StringLength(50)]
        public string DOCTOR_EMAIL { get; set; }

        [Required]
        [StringLength(50)]
        public string DOCTOR_PASSWORD { get; set; }

        [Required]
        [StringLength(300)]
        public string DOCTOR_ADDRESS { get; set; }

        [Required]
        [StringLength(50)]
        public string DOCTOR_SPECIFICATION { get; set; }

        public int DEPARTMENT_FID { get; set; }

        public int HOSPITAL_FID { get; set; }

        public virtual DEPARTMENT_tbl DEPARTMENT_tbl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCTOR_SCHEDULE> DOCTOR_SCHEDULE { get; set; }

        public virtual HOSPITAL_tbl HOSPITAL_tbl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FEEDBACK_tbl> FEEDBACK_tbl { get; set; }
    }
}
