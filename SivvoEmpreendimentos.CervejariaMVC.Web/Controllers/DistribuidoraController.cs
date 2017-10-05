using SivvoEmpreendimentos.CervejariaMVC.Web.DAO;
using SivvoEmpreendimentos.CervejariaMVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SivvoEmpreendimentos.CervejariaMVC.Web.Controllers
{
    public class DistribuidoraController : Controller
    {
        private DistribuidorasDAO _distribuidoraDAO { get; set; }
        private FabricasDAO _fabricaDAO { get; set; }

        public DistribuidoraController(DistribuidorasDAO dDAO, FabricasDAO fDAO)
        {
            this._distribuidoraDAO = dDAO;
            this._fabricaDAO = fDAO;
        }

        // GET: Distribuidoras
        public ActionResult Index()
        {
            return View(this._distribuidoraDAO.GetDistribuidoras());
        }

        public ActionResult Gerir(int? id)
        {
            ViewBag.Fabricas = this._fabricaDAO.GetFabricas();

            if(id != null)
            {
                int idd = (int)id;
                Distribuidora dis = this._distribuidoraDAO.GetDistribuidora(idd);
                if (dis != null)
                {
                    return View(dis);
                }
            }

            return View();
        }

        public ActionResult Salvar(Distribuidora dis)
        {
            if(dis.Id == 0)
            {
                this._distribuidoraDAO.Add(dis);
            }
            else
            {
                this._distribuidoraDAO.Update(dis);
            }
            return RedirectToAction("Index");
        }
    }
}