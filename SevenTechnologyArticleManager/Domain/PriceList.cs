namespace SevenTechnologyArticleManager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PriceList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PriceList()
        {
            Prices = new HashSet<Price>();
        }
        
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; } //Nazwa

        public DateTime? DateFrom { get; set; }//Data_Od

        public DateTime? DateTo { get; set; } // Data_Do

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Price> Prices { get; set; }
    }
}
