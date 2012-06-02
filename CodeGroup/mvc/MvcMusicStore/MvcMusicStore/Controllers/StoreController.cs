using System.Web;
using System.Web.Mvc;
using MvcMusicStore.Models;
using System.Collections.Generic;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        public ActionResult Index()
        {
            var genres = new List<Genre> { 
                new Genre { Name = "Disco" }, 
                new Genre { Name = "Jazz" }, 
                new Genre { Name = "Rock" } };
            return View(genres);
        }

        //
        // GET: /Store/Browse?genre=Disco
        public ActionResult Browse(string genreName)
        {
            var genreModel = new Genre { Name = genreName };
            return View(genreModel);
        }

        //
        // GET: /Store/Details/5
        public ActionResult Details(int id)
        {
            var album = new Album { Title = "Album " + id };
            return View(album);
        }
    }
}