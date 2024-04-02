using CountryInfoService;

namespace MvcCoreCliente.Services
{
    public class ServicesCountries
    {
        CountryInfoServiceSoapTypeClient client;

        public ServicesCountries()
        {
            this.client =
                new CountryInfoServiceSoapTypeClient
 (CountryInfoServiceSoapTypeClient.EndpointConfiguration.CountryInfoServiceSoap);

        }

        public async Task<tCountryCodeAndName[]> GetCountries()
        {
            var response = this.client.ListOfCountryNamesByNameAsync();
            tCountryCodeAndName[] data = response.Result.Body.ListOfCountryNamesByNameResult;
            return data;
        }

        public async Task<tCountryInfo> GetCountryInfoISO(string isoCode)
        {
            FullCountryInfoResponse fullCountry = await client.FullCountryInfoAsync(isoCode);
            tCountryInfo countryInfo = fullCountry.Body.FullCountryInfoResult;
            return countryInfo;
        }
    }
}
