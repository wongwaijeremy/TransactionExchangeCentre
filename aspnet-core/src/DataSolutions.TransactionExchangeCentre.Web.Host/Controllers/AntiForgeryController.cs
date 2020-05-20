using Microsoft.AspNetCore.Antiforgery;
using DataSolutions.TransactionExchangeCentre.Controllers;

namespace DataSolutions.TransactionExchangeCentre.Web.Host.Controllers
{
    public class AntiForgeryController : TransactionExchangeCentreControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
