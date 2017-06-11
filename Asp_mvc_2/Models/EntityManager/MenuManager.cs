using Asp_mvc_2.Models.DB;
using Asp_mvc_2.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asp_mvc_2.Models.EntityManager
{
    public class MenuManager
    {
        public void AddMenu(MenuView mv)
        {
            using (DemoDBEntities db = new DemoDBEntities())
            {
                menu mm = new menu();
                mm.menu1 = mv.menu;
                mm.stock = mv.stock;
                mm.harga = mv.harga;
                db.menus.Add(mm);
                db.SaveChanges();
            }
        }

        public void UpdateMenu(MenuView mv)
        {
            using (DemoDBEntities db = new DemoDBEntities())
            {
                menu mm = db.menus.Find(mv.id_menu);
                mm.menu1 = mv.menu;
                mm.stock= mv.stock;
                mm.harga = mv.harga;
                //db.kamars.Add(km);
                db.SaveChanges();
            }
        }

        public List<MenuView> GetMenuData()
        {
            using (DemoDBEntities db = new DemoDBEntities())
            {
                var menu = db.menus.Select(o => new MenuView
                {
                    id_menu = o.id_menu,
                    menu = o.menu1,
                    stock = o.stock,
                    harga = o.harga
                }).ToList();
                return menu;
            }
        }

        public void DeleteMenu(int MenuID)
        {
            using (DemoDBEntities db = new DemoDBEntities())
            {
                using (var dbContextTransaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var mm = db.menus.Where(o => o.id_menu == MenuID);
                        if (mm.Any()) {
                            db.menus.Remove(mm.FirstOrDefault());
                            db.SaveChanges();
                        }
                        dbContextTransaction.Commit();
                    }
                    catch {
                        dbContextTransaction.Rollback();
                    }
                }
            }
        }
    }
}