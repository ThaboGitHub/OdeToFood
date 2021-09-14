# OdeToFood
ASP.NET CORE Documentation https://docs.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-5.0

Tag Helpers/HtmlHelpers enable server-side code to participate in creating and rendering HTML elements in Razor files. (asp-page,asp-for)
https://docs.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/built-in/?view=aspnetcore-5.0

<a class="nav-link text-dark" asp-area="" asp-page="/Restuarants/list">Restuarants</a>
@Html.ActionLink(employee.Id.ToString(), "Details", new { id = employee.Id })

Read application configurations from the appSettings.json, use the IConfiguration interface and access the using Iconfiguration["ConfigurationFieldName"]
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-5.0

public class MyConfigurations
{
		private readonly IConfiguration configuration;

        public MyConfigurations(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Message { get; set; }

        public string void GetConfig()
        {
            Message = configuration["Message"]; //"Hello Word";
        }
}

Dependency injection done on the startup.cs on the ConfigureServices Method.
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/startup?view=aspnetcore-5.0
 public void ConfigureServices(IServiceCollection services)
        {

            services.AddSingleton<IRestuarantData,InMemoryRestuarantData>();
           
        }


Model Binding.
You can bind to a querty string, but accepting parameters on the OnGet method/ using bindingg property
When using the binding property the parameter can serve both as an input and output property

[BindProperty(SupportsGet =true)] 
public string SearchTerm { get; set; }


<!-- You can change the routing for a asp .net page  here to support Detail/{parameter}
    You can specify constraints
-->
@page "{restuarantId:int}"

https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-5.0
Model validation, use DataAnnotations,ModelState and validation tag helper
 [Required,StringLength(80)]
        public string Name { get; set; }
        [Required, StringLength(80)]
        public string Location { get; set; }

ModelState.IsValid

<span class="text-danger" asp-validation-for="Restuarant.Name"></span>

-------------------------------------------------------------------------------------------------------------------------------------------------------------------

SQL Server and EntityFramwork

Install the following nuget packages 
 - Microsoft.EntityFrameworkCore - Core EF Framework.
 - Microsoft.EntityFrameworkCore.SqlServer - EF  package to work with microsoft sql.
 - Microsoft.EntityFrameworkCore.Design - Enables EF to use designg time features i.e configurations settings (Install this package on the startup ptoject so you can read configs from startup application)
 - Microsoft.EntityFrameworkCore.Tools -Allows for exuting ef commands on the package manager console
 
 Add Connection string to appSettingsJS
 "ConnectionStrings": {
    "OdeToFoodDb": "Data Source=(localdb)\\ProjectsV13;Initial Catalog=OdeToFood;Integrated Security=True"
  }
 
 Create DbContext Class
  public OdeToFoodDbContext(DbContextOptions<OdeToFoodDbContext> options):base(options){}
 
 Add DB context to DI containter.
 services.AddDbContextPool<OdeToFoodDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("OdeToFoodDb"));
            });
 
       
 User Inteface
 ----------------------------------------------------------------------------
 Layout
 _ViewImport
 _ViewStart
 Partial view  - <partial name="_Summary" model="rest" />
 
 View Components - Self contiained component, that  can be reused.
 1. Class in the ViewComponents folder
	 - Class name must inherit from ViewComponent and have naming convention {ClassName}ViewComponent
	 - Class must have method Invoke that returns IViewComponentResult
	 
	 public class RestuarantCountViewComponent : ViewComponent
    {
        private readonly IRestuarantData restuarantData;

        public RestuarantCountViewComponent(IRestuarantData restuarantData)
        {
            this.restuarantData = restuarantData;
        }

        public IViewComponentResult Invoke() 
        {
            var count = restuarantData.GetResruarantCount();
            return View(count);
        }
    }

2. Create View component page
	- ASP .Net Core requires that the view component view be in the shared folder under the Components folder.
	- Create a folder with the same name as your view component class without the ViewComponent suffix and add a view in that folder named Default.
	
3. Add TagHelper to the _ViewImport page to the assembly where your view component is loccated
	- @addTagHelper *,OdeToFood
	
4.	Add  view component to the _Layout page.
	- <vc:restuarant-count></vc:restuarant-count>
	
	
Client Side Integration (JavaScript & CSS)

ClientSide Validation
<script src="~/lib/jquery-validation/dist/jquery.validate.min.js"></script>
<script src="~/lib/jquery-validation-unobtrusive/jquery.validate.unobtrusive.min.js"></script>


