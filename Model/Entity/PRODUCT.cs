namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PRODUCTS")]
    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            ORDER_DETAILS = new HashSet<ORDER_DETAILS>();
        }

        [Key]
        public int IDPRODUCTS { get; set; }

        public int IDCATEGORIES { get; set; }

        [StringLength(255)]
        [DisplayName("Tên tác giả")]
        [Required(ErrorMessage = "Vui lòng nhập tên tác giả.")]

        public string AUTHOR { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập giá của sản phẩm.")]
        [DisplayName("Giá mới")]
        public double PRICE { get; set; }
        [DisplayName("Nhà cung cấp")]

        [StringLength(255)]
        [Required(ErrorMessage = "Vui lòng nhập nhà sản xuất.")]
        public string VENDOR { get; set; }

        [StringLength(255)]
        [DisplayName("Tên sách")]
        [Required(ErrorMessage = "Vui lòng nhập tên sách.")]
        public string PRODUCTS_NAME { get; set; }
        [DisplayName("Tên hình ảnh")]

        [StringLength(255)]
        public string IMAGE_NAME { get; set; }
        [DisplayName("Mô tả")]

        [StringLength(4000)]
        public string DESCRIPTION { get; set; }
        [DisplayName("Giá cũ")]
        public double? OLDPRICE { get; set; }

        public virtual CATEGORY CATEGORy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER_DETAILS> ORDER_DETAILS { get; set; }
    }
}
