namespace Shopping.Web.Pages
{
    public class IndexModel
        (ICatalogService catalogService, IBasketService basketService, ILogger<IndexModel> logger)
        : PageModel
    {
        public IEnumerable<ProductModel> ProductList { get; set; } = new List<ProductModel>();

        public async Task<IActionResult> OnGetAsync(Guid productId)
        {
            logger.LogInformation("Index page visited");

            var productResponse = await catalogService.GetProducts();

            var result = await catalogService.GetProducts();
            ProductList = result.Products;

            return Page();
        }
        public async Task<IActionResult> OnPostAddToCartAsync(Guid productId)
    }
}
