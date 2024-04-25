namespace MvcCoreCacheRedis.Helpers
{
    public enum Folders { Images, Documents }

    public class HelperPathProvider
    {
        private IWebHostEnvironment _environment;

        public HelperPathProvider(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public string MapPath(string fileName, Folders folder)
        {
            string? carpeta = "";
            switch (folder)
            {
                case Folders.Images:
                    carpeta = "images";
                    break;
                case Folders.Documents:
                    carpeta = "documents";
                    break;
            }
            string path = Path.Combine(_environment.WebRootPath, carpeta, fileName);
            return path;
        }
    }
}
