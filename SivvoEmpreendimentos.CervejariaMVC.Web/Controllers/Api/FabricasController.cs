using SivvoEmpreendimentos.CervejariaMVC.Web.DAO;
using SivvoEmpreendimentos.CervejariaMVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SivvoEmpreendimentos.CervejariaMVC.Web.Controllers.Api
{
    public class FabricasController : ApiController
    {
        private FabricasDAO _fabricaDAO { get; set; }

        public FabricasController()
        {
            _fabricaDAO = new FabricasDAO(new CervejariaContext());
            //_fabricaDAO = fDAO;
        }

        //GET /api/fabricas
        [HttpGet]
        public IEnumerable<Fabrica> GetFabrica()
        {
            return _fabricaDAO.GetFabricas();
        }

        //GET /api/fabricas/id
        [HttpGet]
        public Fabrica GetFabrica(int id)
        {
            Fabrica fab = _fabricaDAO.GetFabrica(id);
            if(fab == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return fab;
        }

        //POST /api/fabricas
        [HttpPost]
        public Fabrica CreateFabrica(Fabrica fabrica)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            
            return _fabricaDAO.Add(fabrica);
        }

        //PUT /api/fabricas
        [HttpPut]
        public Fabrica UpdateFabrica(int id, Fabrica fabrica)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            Fabrica fabDB = _fabricaDAO.GetFabrica(id);

            if (fabDB != null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            fabDB.Descricao = fabrica.Descricao;
            fabDB.Endereco = fabrica.Endereco;
            fabDB.Cnpj = fabrica.Cnpj;
            fabDB.Telefone = fabrica.Telefone;
            fabDB.Cidade = fabrica.Cidade;
            fabDB.Estado = fabrica.Estado;
            _fabricaDAO.Update(fabDB);

            return fabDB;
        }

        //DELETE /api/fabricas
        [HttpDelete]
        public void DeleteFabrica(int id)
        {
            Fabrica fabDB = _fabricaDAO.GetFabrica(id);

            if (fabDB != null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _fabricaDAO.Delete(fabDB);
        }
    }
}
