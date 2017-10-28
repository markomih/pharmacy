using System;
using System.Collections.Generic;
using System.Web.Http;
using Core.Entities;
using Services;
using WebGrease.Css.Extensions;

namespace API.Controllers
{
    public class KontraindikacijaController : ApiController
    {
        public IEnumerable<Kontraindikacija> Get()
        {
            var aps = ServiceProvider.Get<KontraindikacijaService>().GetAll();

            return aps;
        }

        // GET api/Kontraindikacija/5
        public Kontraindikacija Get(int id)
        {
            var o = ServiceProvider.Get<KontraindikacijaService>().Get(id);

            return o;
        }

        // POST api/Kontraindikacija
        public bool Post([FromBody] Kontraindikacija obj)
        {
            try
            {
                ServiceProvider.Get<KontraindikacijaService>().Create(obj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        // PUT api/Kontraindikacija/5
        public void Put(int id, [FromBody] Kontraindikacija obj)
        {
            ServiceProvider.Get<KontraindikacijaService>().Update(id, obj);
        }

        // DELETE api/Kontraindikacija/5
        public void Delete(int id)
        {
            ServiceProvider.Get<KontraindikacijaService>().Delete(id);
        }
    }
}