using Microsoft.Playwright;
using System.Threading.Tasks;

namespace EcomPlaywrightTests.Pages
{
    public class LoginPage
    {
        private readonly IPage _page;
        public LoginPage(IPage page) => _page = page;

        public async Task Login(string username, string password)
        {
            // 1) Go to SauceDemo homepage
            await _page.GotoAsync("https://www.saucedemo.com/",
                new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle });

            // 2) Wait for username field
            await _page.WaitForSelectorAsync("#user-name", new PageWaitForSelectorOptions { Timeout = 10000 });

            // 3) Fill in credentials
            await _page.FillAsync("#user-name", username);
            await _page.FillAsync("#password", password);

            // 4) Click login
            await _page.ClickAsync("#login-button");

            // 5) Confirm login by waiting for inventory container
            await _page.WaitForSelectorAsync(".inventory_list", new PageWaitForSelectorOptions { Timeout = 10000 });
        }
    }
}
