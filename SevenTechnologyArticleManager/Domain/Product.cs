namespace SevenTechnologyArticleManager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Prices = new HashSet<Price>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(7)]
        public string Code { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public decimal? Mass { get; set; }

        [StringLength(50)]
        public string UnitOfMass { get; set; }

        public DateTime? DateOfCreation { get; set; } //Data_Dodania

        public DateTime? DateOfModification { get; set; } //Data_Modyfikacji

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Price> Prices { get; set; }
    }
}
