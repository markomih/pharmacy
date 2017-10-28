using System;
using System.Collections.Generic;
using System.Web.Http;
using Core.Entities;
using Services;
using WebGrease.Css.Extensions;

namespace API.Controllers
{
    public class ZaposleniController : ApiController
    {
        public IEnumerable<Zaposleni> Get()
        {
            var aps = ServiceProvider.Get<ZaposleniService>().GetAll();
            aps.ForEach(o =>
            {
                o.ReceptList = null;
            });

            return aps;
        }

        // GET api/Zaposleni/5
        public Zaposleni Get(int id)
        {
            var o = ServiceProvider.Get<ZaposleniService>().Get(id);

            if (o == null)
                return null;

            o.ReceptList = null;

            return o;
        }

        // POST api/Zaposleni
        public bool Post([FromBody] Zaposleni obj)
        {
            try
            {
                ServiceProvider.Get<ZaposleniService>().Create(obj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        // PUT api/Zaposleni/5
        public void Put(int id, [FromBody] Zaposleni obj)
        {
            ServiceProvider.Get<ZaposleniService>().Update(id, obj);
        }

        // DELETE api/Zaposleni/5
        public void Delete(int id)
        {
            ServiceProvider.Get<ZaposleniService>().Delete(id);
        }
    }
}