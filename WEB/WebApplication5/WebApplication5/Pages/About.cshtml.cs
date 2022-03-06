﻿using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication5.Pages
{
    public class AboutModel : PageModel
    {
        private readonly ILogger<AboutModel> _logger;

        public AboutModel(ILogger<AboutModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            SavedTime = "CRUD Saved Time";
        }

        public string SavedTime { get; set; }

        public void OnPostSaveTimeClick(int id)
        {
            SavedTime = "Edit handler fired";
        }
    }
}