using CommonModels.Auth;
using CommonModels.Inventory;
using CommonModels.Reports;
using Core.BaseRepository;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Handlers;
using Microsoft.Maui.Handlers; // CRUCIAL FOR THE FIX
using MudBlazor.Services;
using Services.Auth;
using Services.Handlers;
using Services.Inventory;
using Services.Reports;
using Services.Expenses;
using Services.Employees;

namespace TechnotechInnovation.ERPMobile
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            // =========================================================
            // THIS IS THE FIX FOR THE TOP BAR OVERLAP
            // =========================================================
#if ANDROID
            Microsoft.Maui.Handlers.WebViewHandler.Mapper.AppendToMapping("SafeArea", (handler, view) =>
            {
                AndroidX.Core.View.ViewCompat.SetFitsSystemWindows(handler.PlatformView, true);
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.ParseColor("#123a70"));
            });
#endif
            // =========================================================

            builder.Services.AddMudServices();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            // 1. SETUP HTTP CLIENT WITH AUTH HANDLER
            builder.Services.AddTransient<AuthHandler>();

            builder.Services.AddHttpClient("ERPApi", client =>
            {
                // REPLACE THIS WITH YOUR ACTUAL API URL!
                client.BaseAddress = new Uri("https://your-api-url.com/");
            })
            .AddHttpMessageHandler<AuthHandler>();

            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ERPApi"));

            // 2. REGISTER SERVICES
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IDashboardService, DashboardService>();
            builder.Services.AddScoped<IInventoryService, InventoryService>();
            builder.Services.AddScoped<IEodService, EodService>();
            builder.Services.AddScoped<IExpenseService, ExpenseService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();

            // 3. AUTHENTICATION STATE
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, TechnotechInnovation.ERPMobile.Components.CustomAuthStateProvider>();

            return builder.Build();
        }
    }
}