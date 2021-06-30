using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
  public  interface IRestuarantData
    {
        IEnumerable<Restuarant> GetRestuarantsByName(string name);
    }

    public class InMemoryRestuarantData : IRestuarantData
    {

        public List<Restuarant> Restuarants { get; set; }

        public InMemoryRestuarantData()
        {
            Restuarants = new List<Restuarant> {
            new Restuarant { Id = 1, Name = "Bunny Chow", Location = "Durban", Cousine= CousineType.Indian },
            new Restuarant { Id = 2, Name = "Scott's Pizza", Location = "Sandton", Cousine = CousineType.Italian },
            new Restuarant { Id = 3, Name = "The Jalapinos", Location = "Johanesburg", Cousine = CousineType.Mexican },
            new Restuarant { Id = 4, Name = "Motswako Pot", Location = "Honeydew", Cousine = CousineType.African }
                     };
        }
        public IEnumerable<Restuarant> GetRestuarantsByName(string name = null)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return Restuarants.ToList()
                .Where(x => x.Name.StartsWith(name, StringComparison.InvariantCultureIgnoreCase))
                .OrderBy(y => y.Name);
            }
            else {
                return Restuarants.ToList().OrderBy(y => y.Name);
            }
            
        }
    }
}
