namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ORDERS")]
    public partial class ORDER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ORDER()
        {
            ORDER_DETAILS = new HashSet<ORDER_DETAILS>();
        }

        [Key]
        public int IDORDERS { get; set; }

        public int ID_ACCOUNTS { get; set; }

        [StringLength(255)]
        [Display(Name = "Trạng thái")]
        public string STATUS { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Vui lòng nhập tên người nhận.")]
        [Display(Name = "Người nhận")]
        public string SHIPNAME { get; set; }
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Số điện thoại phải có 10 số.")]
        [Display(Name = "Số diện thoại")]
        public string PHONE { get; set; }
        [DisplayName("Địa chỉ email")]
        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ email.")]
        public string EMAIL { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ.")]
        [DisplayName("Địa chỉ nhận hàng")]
        public string ADDRESS { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER_DETAILS> ORDER_DETAILS { get; set; }
    }
}
