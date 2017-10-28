using System;
using System.Collections.Generic;
using System.Web.Http;
using Core.Entities;
using Services;
using WebGrease.Css.Extensions;

namespace API.Controllers
{
    public class SirupController : ApiController
    {
        public IEnumerable<Sirup> Get()
        {
            var aps = ServiceProvider.Get<SirupService>().GetAll();
            aps.ForEach(o =>
            {
                o.LekList = null;
                o.KontraindikacijaList = null;
            });

            return aps;
        }

        // GET api/Sirup/5
        public Sirup Get(int id)
        {
            var o = ServiceProvider.Get<SirupService>().Get(id);

            if (o == null)
                return null;

            o.LekList = null;
            o.KontraindikacijaList = null;

            return o;
        }

        // POST api/Sirup
        public bool Post([FromBody] Sirup obj)
        {
            try
            {
                ServiceProvider.Get<SirupService>().Create(obj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        // PUT api/Sirup/5
        public void Put(int id, [FromBody] Sirup obj)
        {
            ServiceProvider.Get<SirupService>().Update(id, obj);
        }

        // DELETE api/Sirup/5
        public void Delete(int id)
        {
            ServiceProvider.Get<SirupService>().Delete(id);
        }
    }
}