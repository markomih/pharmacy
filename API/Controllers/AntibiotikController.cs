using System;
using System.Collections.Generic;
using System.Web.Http;
using Core.Entities;
using Services;
using WebGrease.Css.Extensions;

namespace API.Controllers
{
    public class AntibiotikController : ApiController
    {
        public IEnumerable<Antibiotik> Get()
        {
            var aps = ServiceProvider.Get<AntibiotikService>().GetAll();
            aps.ForEach(o =>
            {
                o.KontraindikacijaList = null;
                o.BolestList = null;
                o.ProdajnoMestoList = null;
                o.ProizvodjacList = null;
                o.ReceptList = null;
                o.Pakovanje = null;
            });

            return aps;
        }

        // GET api/bolest/5
        public Antibiotik Get(int id)
        {
            var o = ServiceProvider.Get<AntibiotikService>().Get(id);


            if (o == null)
                return null;

            o.KontraindikacijaList = null;
            o.BolestList = null;
            o.ProdajnoMestoList = null;
            o.ProizvodjacList = null;
            o.ReceptList = null;
            o.Pakovanje = null;

            return o;
        }

        // POST api/bolest
        public bool Post([FromBody] Antibiotik obj)
        {
            try
            {
                ServiceProvider.Get<AntibiotikService>().Create(obj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        // PUT api/bolest/5
        public void Put(int id, [FromBody] Antibiotik obj)
        {
            ServiceProvider.Get<AntibiotikService>().Update(id, obj);
        }

        // DELETE api/bolest/5
        public void Delete(int id)
        {
            ServiceProvider.Get<AntibiotikService>().Delete(id);
        }
    }
}