using System;
using System.Collections.Generic;
using System.Web.Http;
using Core.Entities;
using Services;
using WebGrease.Css.Extensions;

namespace API.Controllers
{
    public class LekController : ApiController
    {
        public IEnumerable<Lek> Get()
        {
            var aps = ServiceProvider.Get<LekService>().GetAll();
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
        public Lek Get(int id)
        {
            var o = ServiceProvider.Get<LekService>().Get(id);

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

        // POST api/Lek
        public bool Post([FromBody] Lek obj)
        {
            try
            {
                ServiceProvider.Get<LekService>().Create(obj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        // PUT api/Lek/5
        public void Put(int id, [FromBody] Lek obj)
        {
            ServiceProvider.Get<LekService>().Update(id, obj);
        }

        // DELETE api/Lek/5
        public void Delete(int id)
        {
            ServiceProvider.Get<LekService>().Delete(id);
        }
    }
}