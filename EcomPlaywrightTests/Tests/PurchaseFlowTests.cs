using NUnit.Framework;
using EcomPlaywrightTests.Pages;
using System.Threading.Tasks;

namespace EcomPlaywrightTests.Tests
{
    [Category("Regression")]
    public class PurchaseFlowTests : BaseTest
    {
        [Test]
        public async Task CompletePurchaseFlow_ShouldSucceed()
        {
            // 1) Login
            var login = new LoginPage(Page);
            await login.Login("standard_user", "secret_sauce");

            // 2) Add first product to cart
            var products = new ProductsPage(Page);
            await products.AddFirstProductToCart();
            await products.GoToCart();

            // 3) Proceed to checkout
            var cart = new CartPage(Page);
            await cart.ProceedToCheckout();

            // 4) Fill user info and continue
            var checkout = new CheckoutPage(Page);
            await checkout.FillUserInformation("Ammar", "Khawaja", "60000");
            await checkout.FinishCheckout();

            // 5) Verify the confirmation header
            var confirmation = await Page.InnerTextAsync(".complete-header");
            Assert.That(confirmation, Does.Contain("thank you for your order").IgnoreCase);

        }
    }
}
