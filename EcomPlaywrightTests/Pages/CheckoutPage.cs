using Microsoft.Playwright;
using System.Threading.Tasks;

namespace EcomPlaywrightTests.Pages
{
    public class CheckoutPage
    {
        private readonly IPage _page;
        public CheckoutPage(IPage page) => _page = page;

        /// <summary>
        /// Fills customer info and continues to overview.
        /// </summary>
        public async Task FillUserInformation(string firstName, string lastName, string postalCode)
        {
            await _page.FillAsync("#first-name", firstName);
            await _page.FillAsync("#last-name", lastName);
            await _page.FillAsync("#postal-code", postalCode);
            await _page.ClickAsync("#continue");
            // Wait for overview page
            await _page.WaitForSelectorAsync(".summary_info", new PageWaitForSelectorOptions { Timeout = 10000 });
        }

        /// <summary>
        /// Finishes the checkout by clicking “Finish” and waits for confirmation.
        /// </summary>
        public async Task FinishCheckout()
        {
            await _page.ClickAsync("#finish");
            // Wait for the complete header
            await _page.WaitForSelectorAsync(".complete-header", new PageWaitForSelectorOptions { Timeout = 10000 });
        }
    }
}
