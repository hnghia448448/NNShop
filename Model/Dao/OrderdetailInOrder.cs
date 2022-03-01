using Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrderdetailInOrder
    {
        public int IDORDERS { get; set; }

        public int? ID_ACCOUNTS { get; set; }

        [StringLength(255)]
        public string STATUS { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage = "Vui lòng nhập tên người nhận.")]
        public string SHIPNAME { get; set; }
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Số điện thoại phải có 10 số.")]
        public string PHONE { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ email.")]
        public string EMAIL { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ.")]
        public string ADDRESS { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER_DETAILS> ORDER_DETAILS { get; set; }
        public int ID_PRODUCT_ORDER { get; set; }

        public int IDPRODUCTS { get; set; }

        public double? TOTAL { get; set; }

        public int? QUANTITY { get; set; }

        public virtual ORDER ORDER { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }

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
    }
}
