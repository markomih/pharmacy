using System;
using System.Collections.Generic;
using System.Web.Http;
using Core.Entities;
using Services;
using WebGrease.Css.Extensions;

namespace API.Controllers
{
    public class InjekcijaController : ApiController
    {
        public IEnumerable<Injekcija> Get()
        {
            var aps = ServiceProvider.Get<InjekcijaService>().GetAll();
            aps.ForEach(o =>
            {
                o.LekList = null;
                o.KontraindikacijaList = null;
            });

            return aps;
        }

        // GET api/Injekcija/5
        public Injekcija Get(int id)
        {
            var o = ServiceProvider.Get<InjekcijaService>().Get(id);

            if (o == null)
                return null;

            o.LekList = null;
            o.KontraindikacijaList = null;

            return o;
        }

        // POST api/Injekcija
        public bool Post([FromBody] Injekcija obj)
        {
            try
            {
                ServiceProvider.Get<InjekcijaService>().Create(obj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        // PUT api/Injekcija/5
        public void Put(int id, [FromBody] Injekcija obj)
        {
            ServiceProvider.Get<InjekcijaService>().Update(id, obj);
        }

        // DELETE api/Injekcija/5
        public void Delete(int id)
        {
            ServiceProvider.Get<InjekcijaService>().Delete(id);
        }
    }
}