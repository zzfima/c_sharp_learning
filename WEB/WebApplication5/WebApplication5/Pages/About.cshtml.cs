using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication5.Pages
{
    public class AboutModel : PageModel
    {
        private readonly ILogger<AboutModel> _logger;


        public AboutModel(ILogger<AboutModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet()
        {
            var v = await Program._programTest.GetSavedTimeItemAsync();
            SavedTime = v;
        }

        public DateTime SavedTime { get; set; }

        public async void OnPostSaveTimeClick(int id)
        {
            SavedTime = DateTime.Now;
            await Program._programTest.SaveTimeItemAsync(SavedTime);
        }
    }
}