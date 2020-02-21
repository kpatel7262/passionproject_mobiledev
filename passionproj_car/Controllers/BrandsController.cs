using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using passionproject_2.Data;
using passionproject_2.Models;
using System.Diagnostics;


namespace passionproject_2.Controllers
{
    public class BrandsController : Controller
    {
        private CarContext db = new CarContext();
        // GET: Brands
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            //what data do we need?
            List<Brands> allBrands = db.Brands.SqlQuery("Select * from Brands").ToList();

            return View(allBrands);
        }

        [HttpPost]
        public ActionResult Add(string BrandName)
        {
            string query = "insert into Brands(BrandName) values (@BrandName)";
            SqlParameter param = new SqlParameter("@BrandName", BrandName);

            db.Database.ExecuteSqlCommand(query, param);

            return RedirectToAction("List");
        }

        // Add
        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Update(int id)
        {
            string query = "select * from Brands where BrandID = @id";
            SqlParameter param = new SqlParameter("@id", id);


            Brands selectedBrand = db.Brands.SqlQuery(query, param).FirstOrDefault();

            return View(selectedBrand);


        }
        // [HttpPost] Update
        [HttpPost]
        public ActionResult Update(int id, string BrandName)
        {
            string query = "update Brands set BrandName=@BrandName where BrandID=@id";
            SqlParameter[] sqlparams = new SqlParameter[2];
            sqlparams[0] = new SqlParameter("@BrandName", BrandName);
            sqlparams[1] = new SqlParameter("@id", id);
            Debug.WriteLine("trying to update " + BrandName + "");
            db.Database.ExecuteSqlCommand(query, sqlparams);
            
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            string query = "Delete from Brands where BrandID=@id";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, parameter);
            return RedirectToAction("List");
        }

    }
}