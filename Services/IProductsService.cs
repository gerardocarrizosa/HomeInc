using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HomeInc.Services
{
    public interface IProductsService
    {
        Task<List<Products>> GetAllProducts();
        Task<Products> GetProductById(Guid id);
        Task<List<Products>> CreateProduct(Products product);
        Task<Products> UpdateProduct(Products product); 
        Task<Products> DeleteProduct(Guid id);
    }
}
