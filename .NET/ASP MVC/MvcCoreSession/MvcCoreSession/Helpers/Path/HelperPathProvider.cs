namespace MvcCoreSession.Helpers.Path
{
    public enum Folders { Images = 0, Facturas = 1, Uploads = 2, Temporal = 3 }

    public class HelperPathProvider
    {
        private readonly IWebHostEnvironment webHost;
        public HelperPathProvider(IWebHostEnvironment webHost)
        {
            this.webHost = webHost;
        }
    }
}
