using MongoDB.Bson;
using MongoDB.Driver;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    // Definición de la clase ProductCollection que implementa la interfaz iProductCollection
    public class ProductCollection : iProductCollection
    {
        // Creación de una instancia de la clase MongoDBRepository
        internal MongoDBRepository _repository = new MongoDBRepository();
        // Declaración de una colección de productos en MongoDB
        private IMongoCollection<Product> Collection;

        // Constructor que inicializa la colección con la colección "Products" en la base de datos
        public ProductCollection()
        {
            Collection = _repository.db.GetCollection<Product>("Products");
        }

        // Método para eliminar un producto por su ID
        public async Task DeleteProducto(string id)
        {
            var filter = Builders<Product>.Filter.Eq(s => s.Id, new ObjectId(id));
            await Collection.DeleteOneAsync(filter);
        }

        // Método para obtener todos los productos
        public async Task<List<Product>> GetAllProducts()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        // Método para obtener un producto por su ID
        public async Task<Product> GetProductById(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        // Método para insertar un nuevo producto
        public async Task InsetProduct(Product product)
        {
            await Collection.InsertOneAsync(product);
        }

        // Método para actualizar un producto existente
        public async Task UpdateProduct(Product product)
        {
            var filter = Builders<Product>.Filter.Eq(s => s.Id, product.Id);
            await Collection.ReplaceOneAsync(filter, product);
        }
    }
}
