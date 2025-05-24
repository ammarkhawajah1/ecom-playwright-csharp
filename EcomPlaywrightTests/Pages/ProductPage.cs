using Microsoft.Playwright;
using System.Threading.Tasks;

namespace EcomPlaywrightTests.Pages
{
    public class ProductsPage
    {
        private readonly IPage _page;
        public ProductsPage(IPage page) => _page = page;

        /// <summary>
        /// Adds the first product in the inventory list to the cart.
        /// </summary>
        public async Task AddFirstProductToCart()
        {
            // 1) Wait for inventory items to render
            await _page.WaitForSelectorAsync(".inventory_item", new PageWaitForSelectorOptions { Timeout = 10000 });

            // 2) Click the first “Add to cart” button
            await _page.ClickAsync(".inventory_item:first-child button.btn_inventory");

            // 3) Wait for the cart badge to show “1”
            await _page.WaitForSelectorAsync(".shopping_cart_badge", new PageWaitForSelectorOptions { Timeout = 5000 });
        }

        /// <summary>
        /// Navigates to the shopping cart page.
        /// </summary>
        public async Task GoToCart()
        {
            await _page.ClickAsync(".shopping_cart_link");
            await _page.WaitForSelectorAsync(".cart_list", new PageWaitForSelectorOptions { Timeout = 10000 });
        }
    }
}
