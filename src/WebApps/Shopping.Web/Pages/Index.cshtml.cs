namespace Shopping.Web.Pages
{
    public class IndexModel
        (ICatalogService catalogService, IBasketService basketService, ILogger<IndexModel> logger)
        : PageModel
    {
        public IEnumerable<ProductModel> ProductList { get; set; } = new List<ProductModel>();

        public async Task<IActionResult> OnPostAddToCartAsync(Guid productId)
        {
            logger.LogInformation("Add to cart button clicked");

            var productResponse = await catalogService.GetProduct(productId);

            var result = await catalogService.GetProducts();
            ProductList = result.Products;

            return Page();
        }
    }
}
