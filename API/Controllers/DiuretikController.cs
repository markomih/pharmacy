using System;
using System.Collections.Generic;
using System.Web.Http;
using Core.Entities;
using Services;
using WebGrease.Css.Extensions;

namespace API.Controllers
{
    public class DiuretikController : ApiController
    {
        public IEnumerable<Diuretik> Get()
        {
            var aps = ServiceProvider.Get<DiuretikService>().GetAll();
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
        public Diuretik Get(int id)
        {
            var o = ServiceProvider.Get<DiuretikService>().Get(id);

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
        public bool Post([FromBody] Diuretik obj)
        {
            try
            {
                ServiceProvider.Get<DiuretikService>().Create(obj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        // PUT api/bolest/5
        public void Put(int id, [FromBody] Diuretik obj)
        {
            ServiceProvider.Get<DiuretikService>().Update(id, obj);
        }

        // DELETE api/bolest/5
        public void Delete(int id)
        {
            ServiceProvider.Get<DiuretikService>().Delete(id);
        }
    }
}