using System;
using System.Collections.Generic;
using System.Web.Http;
using Core.Entities;
using Services;
using WebGrease.Css.Extensions;

namespace API.Controllers
{
    public class ProizvodjacController : ApiController
    {
        public IEnumerable<Proizvodjac> Get()
        {
            var aps = ServiceProvider.Get<ProizvodjacService>().GetAll();
            aps.ForEach(o =>
            {
                o.LekList = null;
            });

            return aps;
        }

        // GET api/Proizvodjac/5
        public Proizvodjac Get(int id)
        {
            var o = ServiceProvider.Get<ProizvodjacService>().Get(id);

            if (o == null)
                return null;

            o.LekList = null;

            return o;
        }

        // POST api/Proizvodjac
        public bool Post([FromBody] Proizvodjac obj)
        {
            try
            {
                ServiceProvider.Get<ProizvodjacService>().Create(obj);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        // PUT api/Proizvodjac/5
        public void Put(int id, [FromBody] Proizvodjac obj)
        {
            ServiceProvider.Get<ProizvodjacService>().Update(id, obj);
        }

        // DELETE api/Proizvodjac/5
        public void Delete(int id)
        {
            ServiceProvider.Get<ProizvodjacService>().Delete(id);
        }
    }
}