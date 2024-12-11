using CryptoExchange.WebApp.Configuration;
using CryptoExchange.WebApp.Extensions;

namespace CryptoExchange.WebApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddRazorPages();
			builder.Services.AddCommonOrderServices();
			builder.Services.AddOptionsFromSection<Settings>("Settings");

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
			}
			app.UseStaticFiles();

			app.UseRouting();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Trading}/{action=Buy}/{numberOfBtc?}");


			app.UseAuthorization();

			app.MapRazorPages();

			app.Run();
		}
	}
}
