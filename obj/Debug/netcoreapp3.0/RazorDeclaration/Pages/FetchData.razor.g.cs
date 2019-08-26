#pragma checksum "C:\Users\Gytis\source\repos\BlazorApp\Pages\FetchData.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c097815e16bd220bb0958f34343efed5d69faf29"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace BlazorApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "C:\Users\Gytis\source\repos\BlazorApp\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "C:\Users\Gytis\source\repos\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#line 3 "C:\Users\Gytis\source\repos\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 4 "C:\Users\Gytis\source\repos\BlazorApp\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 5 "C:\Users\Gytis\source\repos\BlazorApp\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 6 "C:\Users\Gytis\source\repos\BlazorApp\_Imports.razor"
using BlazorApp;

#line default
#line hidden
#line 7 "C:\Users\Gytis\source\repos\BlazorApp\_Imports.razor"
using BlazorApp.Shared;

#line default
#line hidden
#line 2 "C:\Users\Gytis\source\repos\BlazorApp\Pages\FetchData.razor"
using BlazorApp.Data;

#line default
#line hidden
#line 3 "C:\Users\Gytis\source\repos\BlazorApp\Pages\FetchData.razor"
using BlazorAppDB.Data.Weather;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public class FetchData : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
        }
        #pragma warning restore 1998
#line 89 "C:\Users\Gytis\source\repos\BlazorApp\Pages\FetchData.razor"
       
    [CascadingParameter]
    private Task<AuthenticationState> authenticationStateTask { get; set; }
    List<WeatherForecast> forecasts;
    WeatherForecast objWeatherForecast = new WeatherForecast();
    bool ShowPopup = false;
    protected override async Task OnInitializedAsync()
    {
        var user = (await authenticationStateTask).User;
        forecasts = await ForecastService.GetForecastAsync(user.Identity.Name);
    }
    void ClosePopup()
    {
        ShowPopup = false;
    }
    void AddNewForecast()
    {
        objWeatherForecast = new WeatherForecast();
        objWeatherForecast.Id = 0;
        ShowPopup = true;
    }
    async Task SaveForecast()
    {
        ShowPopup = false;
        var user = (await authenticationStateTask).User;
        if (objWeatherForecast.Id == 0)
        {
            WeatherForecast objNewWeatherForecast = new WeatherForecast();
            objNewWeatherForecast.Date = System.DateTime.Now;
            objNewWeatherForecast.Summary = objWeatherForecast.Summary;
            objNewWeatherForecast.TemperatureC =
            Convert.ToInt32(objWeatherForecast.TemperatureC);
            objNewWeatherForecast.TemperatureF =
            Convert.ToInt32(objWeatherForecast.TemperatureF);
            objNewWeatherForecast.UserName = user.Identity.Name;
            var result =
            ForecastService.CreateForecastAsync(objNewWeatherForecast);
        }
        else
        {
            var result =
            ForecastService.UpdateForecastAsync(objWeatherForecast);
        }
        forecasts =
        await ForecastService.GetForecastAsync(user.Identity.Name);
    }

    void EditForecast(WeatherForecast weatherForecast)
    {
        objWeatherForecast = weatherForecast;
        ShowPopup = true;
    }

#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private WeatherForecastService ForecastService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    }
}
#pragma warning restore 1591
