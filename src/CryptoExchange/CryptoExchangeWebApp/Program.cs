using CryptoExchange.Common.Dtos;
using CryptoExchange.WebApp.Configuration;
using CryptoExchange.WebApp.Extensions;
using CryptoExchange.WebApp.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCommonOrderServices();
builder.Services.AddOptionsFromSection<Settings>("Settings");
builder.Services.AddSingleton<ISalesService, SalesService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.MapGet("/trading/buy/{numberOfBtc}",
		Results<Ok<ICollection<OrderDto>>, NoContent> (ISalesService salesService, int numberOfBtc) =>
			salesService.Buy(numberOfBtc) is { } orders
				? TypedResults.Ok(orders)
				: TypedResults.NoContent()
	)
	.WithName("BuyBtc")
	.WithOpenApi(x => new OpenApiOperation(x)
	 {
		 Summary = "Buys Btc",
		 Description = "Returns collection of orders.",
	 });

app.MapGet("/trading/sell/{numberOfBtc}",
		Results<Ok<ICollection<OrderDto>>, NoContent> (ISalesService salesService, int numberOfBtc) =>
			salesService.Sell(numberOfBtc) is { } orders
				? TypedResults.Ok(orders)
				: TypedResults.NoContent()
	)
	.WithName("SellBtc")
	.WithOpenApi(x => new OpenApiOperation(x)
	{
		Summary = "Sells Btc",
		Description = "Returns collection of orders.",
	});

app.Run();
