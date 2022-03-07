using Microsoft.AspNetCore.Mvc.RazorPages;
using SavedTimesCosmos;

namespace WebApplication5.Pages
{
    public class AboutModel : PageModel
    {
        private readonly ILogger<AboutModel> _logger;
        private readonly ProgramTest _programTest;

        public AboutModel(ILogger<AboutModel> logger)
        {
            _logger = logger;
            _programTest = new ProgramTest();
        }

        public async Task OnGet()
        {
            await _programTest.InitClient();
            var v = await _programTest.GetSavedTimeItemAsync();
            SavedTime = v;
        }

        public DateTime SavedTime { get; set; }

        public async void OnPostSaveTimeClick(int id)
        {
            SavedTime = DateTime.Now;
            await _programTest.SaveTimeItemAsync(SavedTime);
        }
    }
}