using Microsoft.Playwright;
using System.Threading.Tasks;

namespace EcomPlaywrightTests.Pages
{
    public class CartPage
    {
        private readonly IPage _page;
        public CartPage(IPage page) => _page = page;

        /// <summary>
        /// Clicks the “Checkout” button on the cart page.
        /// </summary>
        public async Task ProceedToCheckout()
        {
            // 1) Wait for the cart list to load
            await _page.WaitForSelectorAsync(".cart_list", new PageWaitForSelectorOptions { Timeout = 10000 });

            // 2) Click the “Checkout” button
            await _page.ClickAsync("button#checkout");

            // 3) Wait for the checkout form to appear
            await _page.WaitForSelectorAsync("#first-name", new PageWaitForSelectorOptions { Timeout = 10000 });
        }
    }
}
