using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MvcCoreUtilidades.Controllers
{
    public class CachingController : Controller
    {
        private IMemoryCache memoryCache;

        public CachingController(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }


        public IActionResult MemoriaPersonalizada(int? tiempo)
        {
            if (tiempo == null)
            {
                tiempo = 60;
            }
            
            string fecha =
                DateTime.Now.ToLongDateString() + " -- "
                + DateTime.Now.ToLongTimeString();
            //PREGUNTAMOS SI EXISTE ALGO EN CACHE O NO EXISTE
            if (this.memoryCache.Get("FECHA") == null)
            {
                //NO EXISTE NADA EN CACHE TODAVIA
                this.memoryCache.Set("FECHA", fecha);
                ViewData["MENSAJE"] = "Almacenando en Cache";
                ViewData["FECHA"] = this.memoryCache.Get("FECHA");
            }
            else
            {
                //TENEMOS LA FECHA EN CACHE
                fecha = this.memoryCache.Get<string>("FECHA");
                ViewData["MENSAJE"] = "Recuperando de Cache";
                ViewData["FECHA"] = fecha;
            }
            return View("Index");
        }
    }
}
