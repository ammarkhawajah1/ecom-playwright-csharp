using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;

namespace EcomPlaywrightTests.Tests {
    public class BaseTest {
        protected IPlaywright Playwright;
        protected IBrowser Browser;
        protected IPage Page;

        [SetUp]
        public async Task Setup() {
            // ← Call the static factory on the Playwright class:
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            // Launch Chromium with flags to ignore bad certs
            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions {
                Headless = true,
                Args = new[] {
                    "--ignore-certificate-errors",
                    "--disable-web-security"
                }
            });

            // Create a context that ignores HTTPS errors
            var context = await Browser.NewContextAsync(new BrowserNewContextOptions {
                IgnoreHTTPSErrors = true
            });
            Page = await context.NewPageAsync();
        }

        [TearDown]
        public async Task TearDown() {
            await Browser.CloseAsync();
            Playwright.Dispose();
        }
    }
}
