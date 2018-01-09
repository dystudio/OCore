﻿using Microsoft.AspNetCore.Http;
using XCore.DisplayManagement.Theming;
using System;
using System.Threading.Tasks;

namespace XCore.Admin
{
    /// <summary>
    /// Provides the theme defined in the site configuration for the current scope (request).
    /// The same <see cref="ThemeSelectorResult"/> is returned if called multiple times
    /// during the same scope.
    /// </summary>
    public class AdminThemeSelector : IThemeSelector
    {
        private readonly IAdminThemeService _adminThemeService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AdminThemeSelector(
            IAdminThemeService adminThemeService,
            IHttpContextAccessor httpContextAccessor
            )
        {
            _adminThemeService = adminThemeService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ThemeSelectorResult> GetThemeAsync()
        {
            if (AdminAttribute.IsApplied(_httpContextAccessor.HttpContext))
            {
                string adminThemeName = "TheAdmin";//await _adminThemeService.GetAdminThemeNameAsync();
                if (String.IsNullOrEmpty(adminThemeName))
                {
                    return null;
                }

                return new ThemeSelectorResult
                {
                    Priority = 100,
                    ThemeName = adminThemeName
                };
            }
            await Task.Run(()=> { });

            return null;
        }
    }
}
