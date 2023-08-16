using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface iProductCollection
    {
        Task InsetProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProducto(string id);

        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(string id);

    }
}
