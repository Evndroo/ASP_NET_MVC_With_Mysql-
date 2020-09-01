using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
     
        
        public ActionResult Index()
        {
            List<SelectListItem> livros = new List<SelectListItem>();
            using (MySqlConnection con = new MySqlConnection("Server=localhost; DataBase=bd_livraria; User=root; pwd=1234567"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from livro",con);
                    
                    MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    livros.Add(new SelectListItem
                    {
                        Text = rdr[2].ToString(),
                        Value = rdr[0].ToString()
                    });
                }

            }

            
            ViewBag.livro = new SelectList(livros, "Value", "Text");
            return View();
        }

        [HttpPost]
        public ActionResult Index(string valorR)
        {
            valorR = Request["livro"];
            return RedirectToAction("About");
        }





        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}