namespace Tele_Health.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HOSPITAL_tbl
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOSPITAL_tbl()
        {
            DEPARTMENT_tbl = new HashSet<DEPARTMENT_tbl>();
            DOCTOR_tbl = new HashSet<DOCTOR_tbl>();
        }

        [Key]
        public int HOSPITAL_ID { get; set; }

        [Required]
        [StringLength(50)]
        public string HOSPITAL_NAME { get; set; }

        [Required]
        [StringLength(50)]
        public string HOSPITAL_ADDRESS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DEPARTMENT_tbl> DEPARTMENT_tbl { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DOCTOR_tbl> DOCTOR_tbl { get; set; }
    }
}
