namespace OnlineShop.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;

    using OnlineShop.Data.Common.Repositories;
    using OnlineShop.Data.Models;
    using OnlineShop.Services.Data.Interfaces;

    public class CartService : ICartService
    {
        private readonly IProductService productService;
        private readonly IDeletableEntityRepository<Cart> cartRepository;
        private readonly IRepository<CartProduct> cartProductRepository;

        public CartService(
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IProductService productService,
            IDeletableEntityRepository<Cart> cartRepository,
            IRepository<CartProduct> cartProductRepository)
        {
            this.productService = productService;
            this.cartRepository = cartRepository;
            this.cartProductRepository = cartProductRepository;
        }

        public async Task<IEnumerable<Product>> AddProduct(string productName, string userId)
        {
            Product product = await this.productService.GetByName(productName);
            Cart cart = this.cartRepository
                                        .All()
                                        .Where(c => c.UserId == userId)
                                        .FirstOrDefault();

            CartProduct cartProduct = new CartProduct
            {
                Product = product,
                Cart = cart,
            };

            cart.CartProducts.Add(cartProduct);

            this.cartRepository.Update(cart);
            await this.cartRepository.SaveChangesAsync();

            return cart.CartProducts
                        .Select(cp => cp.Product)
                        .ToList();
        }

        public async Task ClearAllProducts(string userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts(string userId)
        {
            var cart = this.cartRepository
                                        .All()
                                        .Where(c => c.UserId == userId)
                                        .Select(c => new
                                        {
                                            Id = c.Id,
                                            Products = c.CartProducts
                                                    .Select(cp => cp.Product)
                                                    .ToList(),
                                        })
                                        .FirstOrDefault();

            return cart.Products;
        }

        public async Task<IEnumerable<Product>> RemoveProduct(string productName, string userId)
        {
            Product product = await this.productService.GetByName(productName);
            Cart cart = this.cartRepository
                                        .All()
                                        .Where(c => c.UserId == userId)
                                        .FirstOrDefault();

            CartProduct cartProduct = this.cartProductRepository
                                            .All()
                                            .FirstOrDefault(cp => 
                                                    cp.CartId == cart.Id &&
                                                    cp.ProductId == product.Id);

            this.cartProductRepository.Delete(cartProduct);

            // cart.CartProducts.Remove(cartProduct);

            // this.cartRepository.Update(cart);

            await this.cartProductRepository.SaveChangesAsync();

            // await this.cartRepository.SaveChangesAsync();

            return cart.CartProducts
                        .Select(cp => cp.Product)
                        .ToList();
        }
    }
}
