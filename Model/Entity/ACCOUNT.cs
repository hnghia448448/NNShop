namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ACCOUNTS")]
    public partial class ACCOUNT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ACCOUNT()
        {
            ORDERS = new HashSet<ORDER>();
            PROFILES = new HashSet<PROFILE>();
        }

        [Key]
        public int ID_ACCOUNTS { get; set; }

        [StringLength(50)]
        [Display(Name="Tên người dùng")]
        public string USERNAME { get; set; }

        [StringLength(255)]
        [Display(Name = "Tài khoản")]
        public string EMAIL { get; set; }

        [StringLength(255)]
        [Display(Name = "Mật khẩu")]
        public string PASSWORD { get; set; }

        [StringLength(255)]
        [Display(Name = "Quyền sử dụng")]
        public string PERMISSION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDERS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PROFILE> PROFILES { get; set; }
    }
}
