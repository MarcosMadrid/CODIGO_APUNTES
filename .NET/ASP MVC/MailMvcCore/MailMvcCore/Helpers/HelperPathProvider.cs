namespace MailMvcCore.Helpers.Path
{
    public enum Folders { Images = 0, Facturas = 1, Uploads = 2, Temporal = 3, Mails = 4 }

    public class HelperPathProvider
    {
        private IWebHostEnvironment hostEnvironment;

        public HelperPathProvider(IWebHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }

        public string MapPath(string fileName)
        {
            string carpeta = "";
            string path = this.hostEnvironment.WebRootPath;

            path = System.IO.Path.Combine(path, carpeta, fileName);

            return path;
        }

        public string GetFolderPath(Folders folder)
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

            return carpeta;
        }
    }
}
