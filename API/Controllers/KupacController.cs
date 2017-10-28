using System;
using System.Collections.Generic;
using System.Web.Http;
using Core.Entities;
using Services;
using WebGrease.Css.Extensions;

namespace API.Controllers
{
    public class KupacController : ApiController
    {
        public IEnumerable<Kupac> Get()
        {
            var aps = ServiceProvider.Get<KupacService>().GetAll();
            aps.ForEach(o =>
            {
                o.ReceptList = null;
            });

            return aps;
        }

        // GET api/Kupac/5
        public Kupac Get(int id)
        {
            var o = ServiceProvider.Get<KupacService>().Get(id);

            if (o == null)
                return null;

            o.ReceptList = null;

            return o;
        }

        // POST api/Kupac
        public bool Post([FromBody] Kupac obj)
        {
            try
            {
                ServiceProvider.Get<KupacService>().Create(obj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        // PUT api/Kupac/5
        public void Put(int id, [FromBody] Kupac obj)
        {
            ServiceProvider.Get<KupacService>().Update(id, obj);
        }

        // DELETE api/Kupac/5
        public void Delete(int id)
        {
            ServiceProvider.Get<KupacService>().Delete(id);
        }
    }
}