namespace WebApiProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Stores
    {
        [Key]
        public int StoreID { get; set; }

        [StringLength(50)]
        public string StoreLocation { get; set; }

        [StringLength(50)]
        public string StoreTel { get; set; }

        public bool? PreferredSupplier { get; set; }
    }
}
