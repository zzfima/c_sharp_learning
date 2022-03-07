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

        public async void OnGet()
        {
            await _programTest.InitClient();
            var v = await _programTest.GetSavedTimeItemAsync();
            SavedTime = v.ToLongDateString();
        }

        public string SavedTime { get; set; }

        public void OnPostSaveTimeClick(int id)
        {
            SavedTime = DateTime.Now.ToLongTimeString();
        }
    }
}