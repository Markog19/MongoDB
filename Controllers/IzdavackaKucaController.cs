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
    public class IzdavackaKucaController : Controller
    {
        private MongoDBContext dbcontext;
        private IMongoCollection<IzdavackaKuca> kucaCollection;

        public IzdavackaKucaController()
        {
            dbcontext = new MongoDBContext();
            kucaCollection = dbcontext.database.GetCollection<IzdavackaKuca>("IzdavackaKuca");
        }
        // GET: Product
        public ActionResult Index()
        {
            List<IzdavackaKuca> kuca = kucaCollection.AsQueryable<IzdavackaKuca>().ToList();
            return View(kuca);
        }

        // GET: Product/Details/5
        public ActionResult Details(string id)
        {
            var kucaId = new ObjectId(id);
            var kuca = kucaCollection.AsQueryable<IzdavackaKuca>().SingleOrDefault(x => x.id == kucaId);
            return View(kuca);
        }

        // GET: Product/Create

        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(IzdavackaKuca kuca)
        {
            try
            {

                kucaCollection.InsertOne(kuca);
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
            var kucaId = new ObjectId(id);

            var kuca = kucaCollection.AsQueryable<IzdavackaKuca>().SingleOrDefault(x => x.id == kucaId);
            return View(kuca);

        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, IzdavackaKuca kuca)
        {
            try
            {

                var filter = Builders<IzdavackaKuca>.Filter.Eq("id", ObjectId.Parse(id));
                var update = Builders<IzdavackaKuca>.Update
                    .Set("ime", kuca.Ime);


                var result = kucaCollection.UpdateOne(filter, update);
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
            var kucaId = new ObjectId(id);

            var kuca = kucaCollection.AsQueryable<IzdavackaKuca>().SingleOrDefault(x => x.id == kucaId);
            return View(kuca);

        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {

                kucaCollection.DeleteOne(Builders<IzdavackaKuca>.Filter.Eq("id", ObjectId.Parse(id)));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
