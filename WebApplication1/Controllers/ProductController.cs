using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    // La ruta y el ApiController atribuyen a esta clase como un controlador de API
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        // Declaración de una interfaz para comunicarse con la base de datos
        private iProductCollection db = new ProductCollection();

        // Método GET para obtener todos los productos
        [HttpGet]
        public async Task<ActionResult> GetAllProducts()
        {
            // Devuelve una respuesta OK con todos los productos
            return Ok(await db.GetAllProducts());
        }

        // Método GET para obtener un producto por su ID
        // La ruta será algo como "api/Product/{id}"
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetProductById(string id)
        {
            // Devuelve una respuesta OK con el producto encontrado
            return Ok(await db.GetProductById(id));
        }

        // Método POST para insertar un nuevo producto
        [HttpPost]
        public async Task<ActionResult> InsertProduct([FromBody] Product product)
        {
            // Validación para verificar que el producto no sea nulo y que no exceda cierta longitud
            if (product == null || product.Name.Length > 100 || product.Category.Length > 50)
                return BadRequest("Product validation failed.");

            // Inserta el producto en la base de datos
            await db.InsetProduct(product);
            return Ok(); // Devuelve una respuesta OK
        }

        // Método PUT para actualizar un producto existente
        [HttpPut("{id}")] // Acepta el ID como parámetro en la ruta
        public async Task<ActionResult> UpdateProduct(string id, [FromBody] Product product)
        {
            // Validación para verificar que el producto no sea nulo y que no exceda cierta longitud
            if (product == null || product.Name.Length > 100 || product.Category.Length > 50)
                return BadRequest("Product validation failed.");

            // Actualiza el ID del producto con el ID proporcionado en la ruta
            product.Id = new MongoDB.Bson.ObjectId(id);

            // Actualiza el producto en la base de datos usando el ID
            await db.UpdateProduct(product);
            return Ok(); // Devuelve una respuesta OK
        }

        // Método DELETE para eliminar un producto por su ID
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteProduct(string id)
        {
            // Elimina el producto de la base de datos
            await db.DeleteProducto(id);
            return Ok(); // Devuelve una respuesta OK
        }
    }
}
