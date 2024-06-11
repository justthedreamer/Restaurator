using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor_App.Pages.Restaurant;

public class Index : PageModel
{
    [BindProperty(SupportsGet = true)] 
    public Guid RestaurantId { get; set; }

    public void OnGet()
    {
    }
}