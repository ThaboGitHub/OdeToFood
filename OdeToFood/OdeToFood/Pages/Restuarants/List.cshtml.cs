using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restuarants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration configuration;
        private readonly IRestuarantData restuarantData;

        public ListModel(IConfiguration configuration,IRestuarantData restuarantData)
        {
            this.configuration = configuration;
            this.restuarantData = restuarantData;
        }
        public string Message { get; set; }
        public IEnumerable<Restuarant> Restuarants { get; set; }

        public void OnGet(string searchTerm)
        {

            Restuarants = restuarantData.GetRestuarantsByName(searchTerm);
            //Message = configuration["Message"]; //"Hello Word";
        }
    }
}
