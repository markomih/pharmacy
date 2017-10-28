using System;
using System.Collections.Generic;
using System.Web.Http;
using Core.Entities;
using Services;
using WebGrease.Css.Extensions;

namespace API.Controllers
{
    public class AnalgetikController : ApiController
    {
        public IEnumerable<Analgetik> Get()
        {
            var aps = ServiceProvider.Get<AnalgetikService>().GetAll();

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
        public Analgetik Get(int id)
        {
            var o = ServiceProvider.Get<AnalgetikService>().Get(id);

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
        public bool Post([FromBody] Analgetik obj)
        {
            try
            {
                ServiceProvider.Get<AnalgetikService>().Create(obj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        // PUT api/bolest/5
        public void Put(int id, [FromBody] Analgetik obj)
        {
            ServiceProvider.Get<AnalgetikService>().Update(id, obj);
        }

        // DELETE api/bolest/5
        public void Delete(int id)
        {
            ServiceProvider.Get<AnalgetikService>().Delete(id);
        }
    }
}