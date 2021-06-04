using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver.Core;
using System.Configuration;
using MVCwithMongoDBCRUD.App_Start;
using MongoDB.Driver;
using MVCwithMongoDBCRUD.Models;

namespace MVCwithMongoDBCRUD.Controllers
{
    public class AlbumiController : Controller
    {
        private MongoDBContext dbcontext;
        private IMongoCollection<Album> AlbumCollection;
        private IMongoCollection<Band> BandCollection;



        public AlbumiController()
        {
            dbcontext = new MongoDBContext();
            AlbumCollection = dbcontext.database.GetCollection<Album>("album");
        }
        // GET: Product
        public ActionResult Index()
        {
            List<Album> albumi = AlbumCollection.AsQueryable<Album>().ToList();
         
           
            return View(albumi);
        }

        // GET: Product/Details/5
        public ActionResult Details(string id)
        {
            var albumId = new ObjectId(id);
            var album = AlbumCollection.AsQueryable<Album>().SingleOrDefault(x => x.AlbumId == albumId);

            return View(album);
        }

        // GET: Product/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Album album)
        {
            try
            {

                AlbumCollection.InsertOne(album);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(string  id)
        {
            var albumId = new ObjectId(id);
            var album = AlbumCollection.AsQueryable<Album>().SingleOrDefault(x => x.AlbumId == albumId);
            return View(album);

        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Album album)
        {
            try
            {

                var filter = Builders<Album>.Filter.Eq("AlbumId", ObjectId.Parse(id));
                var update = Builders<Album>.Update
                    .Set("GodinaIzdavanja", album.GodinaIzdavanja)
                    .Set("Naziv", album.Naziv);
                    

                var result = AlbumCollection.UpdateOne(filter, update);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(string id)
        {
            var albumId = new ObjectId(id);
            var album = AlbumCollection.AsQueryable<Album>().SingleOrDefault(x => x.AlbumId == albumId);
            return View(album);

        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {

                AlbumCollection.DeleteOne(Builders<Album>.Filter.Eq("AlbumId", ObjectId.Parse(id)));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
