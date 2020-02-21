using System;
using System.Collections.Generic;
using System.Data;
//required for SqlParameter class
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using passionproject_2.Data;
using passionproject_2.Models;
using passionproject_2.Models.ViewModel;
using System.Diagnostics;
using System.IO;

namespace passionproject_2.Controllers
{
    public class CarsController : Controller
    {
        private CarContext db = new CarContext();

        // GET: Pet
        public ActionResult List(string Carsearchkey)
        {
            
            Debug.WriteLine("The search key is " + Carsearchkey);
            string query = "Select * from Cars";

            if (Carsearchkey != "")
            {
                //search key
                query = query + " where CarName like '%" + Carsearchkey + "%'";
                Debug.WriteLine("The query is " + query);
            }

            List<Cars> cars = db.Cars.SqlQuery(query).ToList();
            return View(cars);

        }

        // GET: Cars
        public ActionResult Index()
        {
            return View();
        }

        //add cars
        [HttpPost]
        public ActionResult Add(string CarName, int BrandID, int BodytypeID)
        {
            string query = "insert into Cars (CarName, BrandID, BodytypeID) values (@CarName,@BrandID, @BodytypeID)";
            SqlParameter[] sqlparams = new SqlParameter[3];
            sqlparams[0] = new SqlParameter("@CarName", CarName);
            sqlparams[1] = new SqlParameter("@BrandID", BrandID);
            sqlparams[2] = new SqlParameter("@BodytypeID", BodytypeID);

            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("List");
        }

        public ActionResult Add()
        {
            AddCarViewModel carViewModel = new AddCarViewModel();
            List<Brands> Brands = db.Brands.SqlQuery("select * from Brands").ToList();
            List<Bodytypes> Bodytypes = db.Bodytypes.SqlQuery("select * from Bodytypes").ToList();
            carViewModel.Brands = Brands;
            carViewModel.Bodytypes = Bodytypes;
            return View(carViewModel);
        }
        

    }
}