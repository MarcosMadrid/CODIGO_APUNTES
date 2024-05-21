using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcCoreElastiCacheAWS.Repositories;

namespace MvcCoreElastiCacheAWS.Controllers
{
    public class CochesController : Controller
    {
        private RepositoryCoches repositoryCoches;

        public CochesController(RepositoryCoches repositoryCoches)
        {
            this.repositoryCoches = repositoryCoches;
        }

        // GET: CochesController
        public ActionResult Index()
        {
            return View(repositoryCoches.GetCoches());
        }

        // GET: CochesController/Details/5
        public ActionResult Details(int id)
        {
            return View(repositoryCoches.GetCoche(id));
        }
    }
}
