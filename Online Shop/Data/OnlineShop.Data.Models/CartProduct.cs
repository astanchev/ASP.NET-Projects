﻿namespace OnlineShop.Data.Models
{
    public class CartProduct
    {
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int CartId { get; set; }

        public Cart Cart { get; set; }

        public int Quantity { get; set; }
    }
}
