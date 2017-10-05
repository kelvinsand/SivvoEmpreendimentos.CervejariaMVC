using SivvoEmpreendimentos.CervejariaMVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SivvoEmpreendimentos.CervejariaMVC.Web.DAO
{
    public class DistribuidorasDAO
    {
        private CervejariaContext _ctxt { get; set; }

        public DistribuidorasDAO(CervejariaContext ctxt)
        {
            this._ctxt = ctxt;
        }

        public void Add(Distribuidora dis)
        {
            this._ctxt.Distribuidoras.Add(dis);
            this._ctxt.SaveChanges();
        }

        public void Update(Distribuidora dis)
        {
            this._ctxt.Entry<Distribuidora>(dis).State = System.Data.Entity.EntityState.Modified;
            this._ctxt.SaveChanges();
        }

        public Distribuidora GetDistribuidora(int id)
        {
            return this._ctxt.Distribuidoras.FirstOrDefault(d => d.Id == id);
        }

        public IList<Distribuidora> GetDistribuidoras()
        {
            return this._ctxt.Distribuidoras.ToList();
        }
    }
}