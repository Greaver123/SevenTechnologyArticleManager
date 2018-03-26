namespace SevenTechnologyArticleManager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Price
    {
        public int Id { get; set; }

        public int? PriceListId { get; set; }

        public int? ProductId { get; set; }

        public decimal ProductPrice { get; set; }

        public decimal? Discount { get; set; }

        public virtual PriceList PriceList { get; set; }

        public virtual Product Product { get; set; }
    }
}
