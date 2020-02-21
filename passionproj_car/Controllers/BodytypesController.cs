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
    public class BodytypesController : Controller
    {
        private CarContext db = new CarContext();
        // GET: Bodytypes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            //what data do we need?
            List<Bodytypes> allBodytypes = db.Bodytypes.SqlQuery("Select * from Bodytypes").ToList();

            return View(allBodytypes);
        }


        [HttpPost]
        public ActionResult Add(string BodytypeName)
        {
            string query = "insert into Bodytypes(BodytypeName) values (@BodytypeName)";
            SqlParameter param = new SqlParameter("@BodytypeName", BodytypeName);

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
            string query = "select * from Bodytypes where BodytypeID = @id";
            SqlParameter param = new SqlParameter("@id", id);


            Bodytypes selectedBodytype = db.Bodytypes.SqlQuery(query, param).FirstOrDefault();

            return View(selectedBodytype);


        }
        // [HttpPost] Update
        [HttpPost]
        public ActionResult Update(int id, string BodytypeName)
        {
            string query = "update Bodytypes set BodytypeName=@BodytypeName where BodytypeID=@id";
            SqlParameter[] sqlparams = new SqlParameter[2];
            sqlparams[0] = new SqlParameter("@BodytypeName", BodytypeName);
            sqlparams[1] = new SqlParameter("@id", id);
            Debug.WriteLine("trying to update " + BodytypeName + "");
            Debug.WriteLine(query);
            db.Database.ExecuteSqlCommand(query, sqlparams);
            
            return RedirectToAction("List");
        }

        public ActionResult Delete(int id)
        {
            string query = "Delete from Bodytypes where BodytypeID=@id";
            SqlParameter[] parameter = new SqlParameter[1];
            parameter[0] = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, parameter);
            return RedirectToAction("List");
        }
    }
}