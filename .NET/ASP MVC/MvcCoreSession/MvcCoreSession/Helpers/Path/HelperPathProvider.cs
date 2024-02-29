using System.IO;
namespace MvcCoreSession.Helpers.Path
{
    public enum Folders { Images = 0, Facturas = 1, Uploads = 2, Temporal = 3 }

    public class HelperPathProvider
    {
        private IWebHostEnvironment hostEnvironment;
        private HttpContext httpContext;

        public HelperPathProvider(IWebHostEnvironment hostEnvironment, IHttpContextAccessor httpContext)
        {
            this.hostEnvironment = hostEnvironment;
            this.httpContext = httpContext.HttpContext;
        }

        public string MapPath(string fileName, Folders folder)
        {
            string carpeta = "";
            if (folder == Folders.Images)
            {
                carpeta = "images";
            }
            else if (folder == Folders.Temporal)
            {
                carpeta = "temp";
            }
            else if (folder == Folders.Facturas)
            {
                carpeta = "facturas";
            }
            else if (folder == Folders.Uploads)
            {
                carpeta = "uploads";
            }
            string path = this.hostEnvironment.WebRootPath;

            path = System.IO.Path.Combine(path, carpeta, fileName);

            return path;
        }

        public string CreateHostPath(string pathFile)
        {
            List<string> rootPathSegments = pathFile.Split("\\").ToList();
            int wwwrootIndex = rootPathSegments.IndexOf("wwwroot");
            List<string> relativeSegments = rootPathSegments.Skip(wwwrootIndex + 1).ToList();
            string pathFileRelative = string.Join("/", relativeSegments);

            HostString host = this.httpContext.Request.Host;
            string pathHost = ("https://" + host.ToUriComponent() + "/" + pathFileRelative);
            return pathHost;
        }
    }
}
