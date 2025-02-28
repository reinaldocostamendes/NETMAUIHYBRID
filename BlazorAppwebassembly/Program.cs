﻿using BlazorAppwebassembly;
using MauiAppBlazorHybrid.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ShareRazorClassLibraryForAll.Data.Blog;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp=> new HttpClient { BaseAddress=new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddSingleton<IBlogService, BlogService>();

await builder.Build().RunAsync();
