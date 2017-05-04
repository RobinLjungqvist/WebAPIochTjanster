namespace WebApiProject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Titles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Titles()
        {
            Authors = new HashSet<Authors>();
        }

        [Key]
        [StringLength(50)]
        public string ISBN { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public int? EditionNumber { get; set; }

        [StringLength(50)]
        public string Copyright { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Authors> Authors { get; set; }
    }
}
