using Microsoft.Playwright;
using System.Threading.Tasks;

namespace EcomPlaywrightTests.Pages {
    public class HomePage {
        private readonly IPage _page;

        public HomePage(IPage page) {
            _page = page;
        }

        /// <summary>
        /// Searches for a product by term and waits for results.
        /// </summary>
        public async Task Search(string term) {
            // 1) Enter search term
            await _page.FillAsync("#search_query_top", term);

            // 2) Click the Search button
            await _page.ClickAsync("button[name='submit_search']");

            // 3) Wait for the product list to appear
            await _page.WaitForSelectorAsync(".product_list", new PageWaitForSelectorOptions { Timeout = 5000 });
        }
    }
}
