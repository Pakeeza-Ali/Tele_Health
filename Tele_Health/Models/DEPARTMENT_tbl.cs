namespace Tele_Health.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DEPARTMENT_tbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DEPARTMENT_tbl()
        {
            DOCTOR_tbl = new HashSet<DOCTOR_tbl>();
        }

        [Key]
        public int DEPARTMENT_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string DEPARTMENT_NAME { get; set; }

        public int HOSPITAL_FID { get; set; }

        public virtual HOSPITAL_tbl HOSPITAL_tbl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCTOR_tbl> DOCTOR_tbl { get; set; }
    }
}
