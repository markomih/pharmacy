using System;
using System.Collections.Generic;
using System.Web.Http;
using Core.Entities;
using Services;
using WebGrease.Css.Extensions;

namespace API.Controllers
{
    public class AntipiretikController : ApiController
    {
        public IEnumerable<Antipiretik> Get()
        {
            var aps = ServiceProvider.Get<AntipiretikService>().GetAll();
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
        public Antipiretik Get(int id)
        {
            var o = ServiceProvider.Get<AntipiretikService>().Get(id);

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

        // POST api/Antipiretik
        public bool Post([FromBody] Antipiretik obj)
        {
            try
            {
                ServiceProvider.Get<AntipiretikService>().Create(obj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        // PUT api/Antipiretik/5
        public void Put(int id, [FromBody] Antipiretik obj)
        {
            ServiceProvider.Get<AntipiretikService>().Update(id, obj);
        }

        // DELETE api/Antipiretik/5
        public void Delete(int id)
        {
            ServiceProvider.Get<AntipiretikService>().Delete(id);
        }
    }
}