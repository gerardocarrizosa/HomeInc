namespace HomeInc.Services
{
    public class ProductsService : IProductsService
    {
        private readonly DataContext _context;
        public ProductsService(DataContext context) {
            _context = context;
        }

        public async Task<List<Products>> CreateProduct(Products product)
        {
            var dbProduct = _context.Products.Add(product);
            if (product.Category == ProductCategories.Electronicos) dbProduct.Entity.Warranty = "1 mes";
            if (product.Category == ProductCategories.Linea_Blanca) dbProduct.Entity.Warranty = "2 meses";
            if (product.Category == ProductCategories.Hogar) dbProduct.Entity.Warranty = "3 meses";

            await _context.SaveChangesAsync();

            var newProducts = await _context.Products.ToListAsync();
            return newProducts;
        }

        public async Task<Products> DeleteProduct(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return product;
            }
            throw new NotImplementedException();
        }

        public async Task<List<Products>> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Products> GetProductById(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (product is not null)
            {
                _context.SaveChanges();
                return product;
            }
            throw new NotImplementedException();
        }

        public async Task<Products> UpdateProduct(Products product)
        {
            var productFound = await _context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

            if (productFound is not null)
            {
                productFound.Name = product.Name;
                productFound.Category = product.Category;
                if (product.Category == ProductCategories.Electronicos) productFound.Warranty = "1 mes";
                if (product.Category == ProductCategories.Linea_Blanca) productFound.Warranty = "2 meses";
                if (product.Category == ProductCategories.Hogar) productFound.Warranty = "3 meses";
                await _context.SaveChangesAsync();
                return productFound;

            }
            throw new NotImplementedException();
        }
    }
}
