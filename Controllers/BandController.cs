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
    public class BandController : Controller
    {
        private MongoDBContext dbcontext;
        private IMongoCollection<Band> BandCollection;

        public BandController()
        {
            dbcontext = new MongoDBContext();
            BandCollection = dbcontext.database.GetCollection<Band>("band");
        }
        // GET: Product
        public ActionResult Index()
        {
            List<Band> band = BandCollection.AsQueryable<Band>().ToList();
            return View(band);
        }

        // GET: Product/Details/5
        public ActionResult Details(string id)
        {
            var BandId = new ObjectId(id);

            var band = BandCollection.AsQueryable<Band>().SingleOrDefault(x => x.BandId == BandId);
            return View(band);
        }

        // GET: Product/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Band band)
        {
            try
            {

                BandCollection.InsertOne(band);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(string id)
        {
            var BandId = new ObjectId(id);

            var band = BandCollection.AsQueryable<Band>().SingleOrDefault(x => x.BandId == BandId);
            return View(band);

        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, Band band)
        {
            try
            {

                var filter = Builders<Band>.Filter.Eq("BandId", ObjectId.Parse(id));
                var update = Builders<Band>.Update
                    .Set("ime", band.ime);


                var result = BandCollection.UpdateOne(filter, update);
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
            var BandId = new ObjectId(id);

            var band = BandCollection.AsQueryable<Band>().SingleOrDefault(x => x.BandId == BandId);
            return View(band);

        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {

                BandCollection.DeleteOne(Builders<Band>.Filter.Eq("BandId", ObjectId.Parse(id)));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
