using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products.API.Abstractions;
using Products.API.DTOs;

namespace Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [EndpointSummary("Purge and reseed Products.")]
        [EndpointDescription($"This endpoint deletes all of the Products in the database, then inserts a new collection " +
            $"of Products into the database.")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost("[action]")]
        public async Task<IActionResult> PurgeAndSeedData()
        {
            var result = await _productService.PurgeAndSeedDataAsync();
            if (result.IsSuccess) return NoContent();
            return BadRequest(result.ErrorMessage);
        }

        [EndpointSummary("Get Product by Id.")]
        [EndpointDescription($"This endpoint gets a Product with the Id property specified by the path parameter 'id' and " +
            $"if such a Product exists, returns it in the form of a ProductDTO.")]
        [Produces(typeof(ProductDTO))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetById(string id)
        {
            var result = await _productService.GetProductByIdAsync(id);
            if (result.IsSuccess) return Ok(result.Product);
            return BadRequest(result.ErrorMessage);
        }

        [EndpointSummary("Get all Products.")]
        [EndpointDescription($"This endpoint gets all of the Products from the database and returns them in the form of a " +
            $"collection of ProductDTOs. If the optional query string parameter 'category' is provided, the Products returned " +
            $"will be limited to those whose Category property matches the provided category query string parameter.")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get(string? category = null)
        {
            var result = await _productService.GetProductsAsync(category);
            if (result.IsSuccess) return Ok(result.Products);
            return BadRequest(result.ErrorMessage);
        }

        [EndpointSummary("Add a new Product.")]
        [EndpointDescription($"This endpoint creates a new Product using the properties provided by the AddProductDTO input " +
            $"and saves it to the database.")]
        [Produces(typeof(string))]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost]
        public async Task<IActionResult> Post(AddProductDTO addProductDTO)
        {
            var result = await _productService.AddAsync(addProductDTO);
            if (result.IsSuccess) return Ok(result.ProductId);
            return BadRequest(result.ErrorMessage);
        }

        [EndpointSummary("Update an existing Product.")]
        [EndpointDescription($"This endpoint gets a Product from the database and updates it's properties based on the properties " +
            $"of the UpdateProductDTO input. The updated Product is saved to the database.")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPut]
        public async Task<IActionResult> Put(UpdateProductDTO updateProductDTO)
        {
            var result = await _productService.UpdateAsync(updateProductDTO);
            if (result.IsSuccess) return NoContent();
            return BadRequest(result.ErrorMessage);
        }

        [EndpointSummary("Update the Status of an existing Product.")]
        [EndpointDescription($"This endpoint gets a Product from the database and updates it's Status property based on the Status " +
            $"property value of the UpdateStatusDTO input. The updated Product is saved to the database.")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateStatus(UpdateStatusDTO updateStatusDTO)
        {
            var result = await _productService.UpdateStatusAsync(updateStatusDTO);
            if (result.IsSuccess) return NoContent();
            return BadRequest(result.ErrorMessage);
        }

        [EndpointSummary("Add an Image to a Product.")]
        [EndpointDescription($"This endpoint gets a Product from the database and adds an Image to the Product's Images property, " +
            $"which is a List of ImageData objects. The Product is then saved to the database.")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost("images")]
        public async Task<IActionResult> Post(AddImageDTO addImageDTO)
        {
            var result = await _productService.AddImageAsync(addImageDTO);
            if (result.IsSuccess) return NoContent();
            return BadRequest(result.ErrorMessage);
        }

        [EndpointSummary("Add a Document to a Product.")]
        [EndpointDescription($"This endpoint gets a Product from the database and adds a Document to the Product's Documents property, " +
            $"which is a List of DocumentData objects. The Product is then saved to the database.")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost("documents")]
        public async Task<IActionResult> Post(AddDocumentDTO addDocumentDTO)
        {
            var result = await _productService.AddDocumentAsync(addDocumentDTO);
            if (result.IsSuccess) return NoContent();
            return BadRequest(result.ErrorMessage);
        }
        [EndpointSummary("Delete a Product Image.")]
        [EndpointDescription($"This endpoint gets a Product from the database and deletes an Image from the Product's Images property, " +
                    $"which is a List of ImageData objects. The Product is then saved to the database.")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpDelete("images")]
        public async Task<IActionResult> Delete(DeleteImageDTO deleteImageDTO)
        {
            var result = await _productService.DeleteImageAsync(deleteImageDTO);
            if (result.IsSuccess) return NoContent();
            return BadRequest(result.ErrorMessage);
        }

        [EndpointSummary("Delete a Product Document.")]
        [EndpointDescription($"This endpoint gets a Product from the database and deletes a Document from the Product's Documents property, " +
            $"which is a List of DocumentData objects. The Product is then saved to the database.")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpDelete("documents")]
        public async Task<IActionResult> Delete(DeleteDocumentDTO deleteDocumentDTO)
        {
            var result = await _productService.DeleteDocumentAsync(deleteDocumentDTO);
            if (result.IsSuccess) return NoContent();
            return BadRequest(result.ErrorMessage);
        }

        [EndpointSummary("Delete a Product.")]
        [EndpointDescription($"This endpoint deletes an existing Product from the database.")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProductDTO deleteProductDTO)
        {
            var result = await _productService.DeleteProdcutAsync(deleteProductDTO);
            if (result.IsSuccess) return NoContent();
            return BadRequest(result.ErrorMessage);
        }
    }
}
