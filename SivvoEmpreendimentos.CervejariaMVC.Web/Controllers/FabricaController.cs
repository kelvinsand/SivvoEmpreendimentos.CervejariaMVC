using SivvoEmpreendimentos.CervejariaMVC.Web.DAO;
using SivvoEmpreendimentos.CervejariaMVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SivvoEmpreendimentos.CervejariaMVC.Web.Controllers
{
    public class FabricaController : Controller
    {
        private FabricasDAO _fabricaDAO { get; set; }

        public FabricaController(FabricasDAO fDAO)
        {
            this._fabricaDAO = fDAO;
        }

        // GET: Fabrica
        public ActionResult Index(Fabrica f)
        {
            IDictionary<string, string> estados = new Dictionary<string, string>();
            estados.Add("BA", "Bahia");
            estados.Add("RJ", "Rio de Janeiro");
            estados.Add("SP", "São Paulo");
            estados.Add("SE", "Sergipe");
            ViewBag.Estados = estados;
            return View(_fabricaDAO.GetFabricas());
        }

        [HttpPost]
        public ActionResult SalvarFabrica(Fabrica fab)
        {
            Fabrica f = _fabricaDAO.GetFabrica(fab.Id);
            
            if(f == null)
            {
                _fabricaDAO.Add(fab);
            }
            else
            {
                f.Descricao = fab.Descricao;
                f.Endereco = fab.Endereco;
                f.Cnpj = fab.Cnpj;
                f.Telefone = fab.Telefone;
                f.Cidade = fab.Cidade;
                f.Estado = fab.Estado;
                _fabricaDAO.Update(f);
            }

            return Json(fab);
        }

        [HttpPost]
        public ActionResult ObterFabricaJson(int id)
        {
            Fabrica fab = _fabricaDAO.GetFabrica(id);

            return Json(fab);
        }

        [HttpPost]
        public ActionResult DeletarFabrica(int id)
        {
            Fabrica fab = _fabricaDAO.GetFabrica(id);

            if (fab != null)
            {
                _fabricaDAO.Delete(fab);
                return Json(true);
            }

            return Json(false);
        }

    }
}