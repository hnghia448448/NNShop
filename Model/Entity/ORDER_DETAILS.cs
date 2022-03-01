namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ORDER_DETAILS
    {
        [Key]
        public int ID_PRODUCT_ORDER { get; set; }

        public int IDORDERS { get; set; }

        public int IDPRODUCTS { get; set; }

        public double? TOTAL { get; set; }

        public int? QUANTITY { get; set; }

        public virtual ORDER ORDER { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }
    }
}
