using System;
using System.Collections.Generic;
using System.Web.Http;
using Core.Entities;
using Services;
using WebGrease.Css.Extensions;

namespace API.Controllers
{
    public class PakovanjeController : ApiController
    {
        public IEnumerable<Pakovanje> Get()
        {
            var aps = ServiceProvider.Get<PakovanjeService>().GetAll();
            aps.ForEach(o =>
            {
                o.LekList = null;
                o.KontraindikacijaList = null;
            });

            return aps;
        }

        // GET api/Pakovanje/5
        public Pakovanje Get(int id)
        {
            var o = ServiceProvider.Get<PakovanjeService>().Get(id);

            if (o == null)
                return null;

            o.LekList = null;
            o.KontraindikacijaList = null;

            return o;
        }

        // POST api/Pakovanje
        public bool Post([FromBody] Pakovanje obj)
        {
            try
            {
                ServiceProvider.Get<PakovanjeService>().Create(obj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        // PUT api/Pakovanje/5
        public void Put(int id, [FromBody] Pakovanje obj)
        {
            ServiceProvider.Get<PakovanjeService>().Update(id, obj);
        }

        // DELETE api/Pakovanje/5
        public void Delete(int id)
        {
            ServiceProvider.Get<PakovanjeService>().Delete(id);
        }
    }
}