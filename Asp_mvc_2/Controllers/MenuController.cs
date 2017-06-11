using Asp_mvc_2.Models.EntityManager;
using Asp_mvc_2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Asp_mvc_2.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult AddMenu()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddMenu(MenuView kv)
        {
            if (ModelState.IsValid)
            {
                MenuManager KM = new MenuManager();
                KM.AddMenu(kv);
                return RedirectToAction("AdminOnly", "Home");
            }
            return View();
        }

        public ActionResult ManageMenuPartial(string status = "")
        {
            //if (User.Identity.IsAuthenticated)
            //{
            string loginName = User.Identity.Name;
            MenuManager MM = new MenuManager();
            MenuDataView MDV = new MenuDataView();
            MDV.MenuProfile = MM.GetMenuData();
            string message = string.Empty;
            if (status.Equals("update"))
                message = "Update Successful";
            else if (status.Equals("delete"))
                message = "Delete Successful";
            ViewBag.Message = message;
            return PartialView(MDV);
            //}  
            // return RedirectToAction("Index", "Home");
        }

        public ActionResult UpdateMenuData(int menuID, string menu, int stock, int harga)
        {
            MenuView MV = new MenuView();
            MV.id_menu = menuID;
            MV.menu = menu;
            MV.stock = stock;
            MV.harga = harga;
            MenuManager MM = new MenuManager();
            MM.UpdateMenu(MV);
            return Json(new { success = true });
        }

        public ActionResult DeleteMenu(int menuID)
        {
            MenuManager MM = new MenuManager();
            MM.DeleteMenu(menuID);
            return Json(new { success = true });
        }

        public ActionResult Perubahan()
        {
            return View();
        }

    }
}