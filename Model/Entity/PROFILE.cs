namespace Model.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PROFILES")]
    public partial class PROFILE
    {
        [Key]
        [Column(Order = 0)]
        public int IDPROFILES { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_ACCOUNTS { get; set; }

        [StringLength(255)]
        public string FIRST_NAME { get; set; }

        [StringLength(255)]
        public string LAST_NAME { get; set; }

        [StringLength(100)]
        public string GENDER { get; set; }

        [StringLength(255)]
        public string ADDRESS { get; set; }

        [StringLength(50)]
        public string PHONENUMBER { get; set; }

        public virtual ACCOUNT ACCOUNT { get; set; }
    }
}
