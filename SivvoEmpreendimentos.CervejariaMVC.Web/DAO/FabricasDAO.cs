using SivvoEmpreendimentos.CervejariaMVC.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SivvoEmpreendimentos.CervejariaMVC.Web.DAO
{
    public class FabricasDAO
    {
        //using (var context = new ProgramContext()) {

        //    var query = from p in context.Pilots
        //                join c in context.FlightCompanies on p.CompanyId equals c.Id
        //                select new { Pilot = p.Name, Company = c.Name };

        //    var result = query;
        //}
        private CervejariaContext Ctxt { get; set; }

        public FabricasDAO(CervejariaContext ctxt)
        {
            this.Ctxt = ctxt;
        }

        public Fabrica Add(Fabrica f)
        {
            Fabrica fab = Ctxt.Fabricas.Add(f);
            Ctxt.SaveChanges();
            return fab;
        }

        public void Update(Fabrica f)
        {
            Ctxt.Entry(f).State = System.Data.Entity.EntityState.Modified;
            Ctxt.SaveChanges();
        }

        public void Delete(Fabrica f)
        {
            Ctxt.Entry(f).State = System.Data.Entity.EntityState.Deleted;
            Ctxt.SaveChanges();
        }

        public Fabrica GetFabrica(int id)
        {
            Fabrica fab = Ctxt.Fabricas.FirstOrDefault(f => f.Id == id);
            return fab;
        }

        public IList<Fabrica> GetFabricas()
        {
            IList<Fabrica> fabs = Ctxt.Fabricas.AsNoTracking().ToList();
            return fabs;
        }
    }
}