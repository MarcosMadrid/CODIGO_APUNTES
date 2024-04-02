using CountryInfoService;
using Microsoft.AspNetCore.Mvc;
using MvcCoreCliente.Services;

namespace MvcCoreCliente.Controllers
{
    public class CountriesController : Controller
    {
        private ServicesCountries servicesCountries;

        public CountriesController(ServicesCountries servicesCountries)
        {
            this.servicesCountries = servicesCountries;
        }

        public async Task<IActionResult> Index()
        {
            tCountryCodeAndName[] countries = await servicesCountries.GetCountries();
            return View(countries);
        }

        public async Task<IActionResult> Details(string isoCode)
        {
            tCountryInfo countryInfo = await servicesCountries.GetCountryInfoISO(isoCode);
            return View(countryInfo);
        }
    }
}
