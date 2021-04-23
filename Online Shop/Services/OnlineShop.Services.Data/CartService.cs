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
            int cartId = this.cartRepository
                                        .All()
                                        .Where(c => c.UserId == userId)
                                        .Select(c => c.Id)
                                        .FirstOrDefault();

            CartProduct cp = this.cartProductRepository
                                    .All()
                                    .Where(cp => cp.CartId == cartId &&
                                                       cp.ProductId == product.Id)
                                    .FirstOrDefault();

            if (cp == null)
            {
                cp = new CartProduct
                {
                    CartId = cartId,
                    ProductId = product.Id,
                    Quantity = 1,
                };

                await this.cartProductRepository.AddAsync(cp);
            }
            else
            {
                cp.Quantity = cp.Quantity + 1;

                this.cartProductRepository.Update(cp);
            }

            await this.cartProductRepository.SaveChangesAsync();

            return this.GetAllProducts(userId);
        }

        public async Task ClearAllProducts(string userId)
        {
            int cartId = this.cartRepository
                                        .All()
                                        .Where(c => c.UserId == userId)
                                        .Select(c => c.Id)
                                        .FirstOrDefault();

            var cartProducts = this.cartProductRepository
                                    .All()
                                    .Where(cp => cp.CartId == cartId)
                                    .ToList();

            foreach (var cp in cartProducts)
            {
                this.cartProductRepository.Delete(cp);
            }

            await this.cartProductRepository.SaveChangesAsync();
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
            int cartId = this.cartRepository
                                        .All()
                                        .Where(c => c.UserId == userId)
                                        .Select(c => c.Id)
                                        .FirstOrDefault();

            CartProduct cp = this.cartProductRepository
                                    .All()
                                    .Where(cp => cp.CartId == cartId &&
                                                       cp.ProductId == product.Id)
                                    .FirstOrDefault();

            if (cp.Quantity == 1)
            {
                this.cartProductRepository.Delete(cp);
            }
            else
            {
                cp.Quantity = cp.Quantity - 1;
                this.cartProductRepository.Update(cp);
            }

            await this.cartProductRepository.SaveChangesAsync();

            return this.GetAllProducts(userId);
        }
    }
}
