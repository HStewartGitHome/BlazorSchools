#pragma checksum "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2734fb3720ae4ed95346088b9f3ef2872deb7d4c"
// <auto-generated/>
#pragma warning disable 1591
namespace BlazorSchools.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\_Imports.razor"
using BlazorSchools.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\_Imports.razor"
using BlazorSchools.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
using BlazorSchools.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/PerfData")]
    public partial class PerfDara : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>School API Performance Data</h3>\n\n");
#nullable restore
#line 9 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
 if (string.IsNullOrWhiteSpace(errorString) == false)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(1, "    ");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "h2");
            __builder.AddContent(4, 
#nullable restore
#line 11 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
                     errorString

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(5, "\n");
#nullable restore
#line 12 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
}
else if (currentPerf is null)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(6, "    ");
            __builder.AddMarkupContent(7, "<div class=\"h4\">Loading...</div>\n");
#nullable restore
#line 16 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.OpenElement(8, "table");
            __builder.AddAttribute(9, "class", "table table-striped");
            __builder.AddMarkupContent(10, "\n    ");
            __builder.AddMarkupContent(11, "<thead class=\"thead-dark\">\n        <tr>\n            <th>Performance</th>\n            <th>Update</th>\n            <th>Read</th>\n            <th>Read2</th>\n        </tr>\n    </thead>\n    ");
            __builder.OpenElement(12, "tbody");
            __builder.AddMarkupContent(13, "\n        ");
            __builder.OpenElement(14, "tr");
            __builder.AddMarkupContent(15, "\n            ");
            __builder.AddMarkupContent(16, "<td>Initialize Performance</td>\n            <td></td>\n            ");
            __builder.OpenElement(17, "td");
            __builder.AddContent(18, 
#nullable restore
#line 32 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
                 currentPerf.InitPerformance

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\n            <td></td>\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(20, "\n        ");
            __builder.OpenElement(21, "tr");
            __builder.AddMarkupContent(22, "\n            ");
            __builder.AddMarkupContent(23, "<td>Json Performance</td>\n            <td></td>\n            ");
            __builder.OpenElement(24, "td");
            __builder.AddContent(25, 
#nullable restore
#line 38 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
                 currentPerf.JsonPerformance

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\n            ");
            __builder.OpenElement(27, "td");
            __builder.AddContent(28, 
#nullable restore
#line 39 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
                 currentPerf.JsonPerformance2

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(29, "\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\n        ");
            __builder.OpenElement(31, "tr");
            __builder.AddMarkupContent(32, "\n            ");
            __builder.AddMarkupContent(33, "<td>Dapper Performance</td>\n            ");
            __builder.OpenElement(34, "td");
            __builder.AddContent(35, 
#nullable restore
#line 43 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
                 currentPerf.DapperUpdatePerformance

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(36, "\n            ");
            __builder.OpenElement(37, "td");
            __builder.AddContent(38, 
#nullable restore
#line 44 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
                 currentPerf.DapperPerformance

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\n            ");
            __builder.OpenElement(40, "td");
            __builder.AddContent(41, 
#nullable restore
#line 45 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
                 currentPerf.DapperPerformance2

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(42, "\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(43, "\n        ");
            __builder.OpenElement(44, "tr");
            __builder.AddMarkupContent(45, "\n            ");
            __builder.AddMarkupContent(46, "<td>Entity Framework Performance</td>\n            ");
            __builder.OpenElement(47, "td");
            __builder.AddContent(48, 
#nullable restore
#line 49 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
                 currentPerf.EFUpdatePerformance

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(49, "\n            ");
            __builder.OpenElement(50, "td");
            __builder.AddContent(51, 
#nullable restore
#line 50 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
                 currentPerf.EFPerformance

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(52, "\n            ");
            __builder.OpenElement(53, "td");
            __builder.AddContent(54, 
#nullable restore
#line 51 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
                 currentPerf.EFPerformance2

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(55, "\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(56, "\n        ");
            __builder.OpenElement(57, "tr");
            __builder.AddMarkupContent(58, "\n            ");
            __builder.AddMarkupContent(59, "<td>Simulated Performance</td>\n            ");
            __builder.OpenElement(60, "td");
            __builder.AddContent(61, 
#nullable restore
#line 55 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
                 currentPerf.SimUpdatePerformance

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(62, "\n            ");
            __builder.OpenElement(63, "td");
            __builder.AddContent(64, 
#nullable restore
#line 56 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
                 currentPerf.SimPerformance

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(65, "\n            ");
            __builder.OpenElement(66, "td");
            __builder.AddContent(67, 
#nullable restore
#line 57 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
                 currentPerf.SimPerformance2

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(68, "\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(69, "\n        ");
            __builder.OpenElement(70, "tr");
            __builder.AddMarkupContent(71, "\n            ");
            __builder.AddMarkupContent(72, "<td>Use Simulated</td>\n            <td></td>\n            ");
            __builder.OpenElement(73, "td");
            __builder.AddContent(74, 
#nullable restore
#line 62 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
                 currentPerf.UseSIM

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(75, "\n            <td></td>\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(76, "\n        ");
            __builder.OpenElement(77, "tr");
            __builder.AddMarkupContent(78, "\n            ");
            __builder.AddMarkupContent(79, "<td>Use Dapper Framework</td>\n            <td></td>\n            ");
            __builder.OpenElement(80, "td");
            __builder.AddContent(81, 
#nullable restore
#line 68 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
                 currentPerf.UseDapper

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(82, "\n            <td></td>\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(83, "\n        ");
            __builder.OpenElement(84, "tr");
            __builder.AddMarkupContent(85, "\n            ");
            __builder.AddMarkupContent(86, "<td>Use Entity Framework</td>\n            <td></td>\n            ");
            __builder.OpenElement(87, "td");
            __builder.AddContent(88, 
#nullable restore
#line 74 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
                 currentPerf.UseEF

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(89, "\n            <td></td>\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(90, "\n        ");
            __builder.OpenElement(91, "tr");
            __builder.AddMarkupContent(92, "\n            ");
            __builder.AddMarkupContent(93, "<td>Allow Dapper Framework</td>\n            <td></td>\n            ");
            __builder.OpenElement(94, "td");
            __builder.AddContent(95, 
#nullable restore
#line 80 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
                 currentPerf.AllowDapper

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(96, "\n            <td></td>\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(97, "\n        ");
            __builder.OpenElement(98, "tr");
            __builder.AddMarkupContent(99, "\n            ");
            __builder.AddMarkupContent(100, "<td>Allow Entity Framework</td>\n            <td></td>\n            ");
            __builder.OpenElement(101, "td");
            __builder.AddContent(102, 
#nullable restore
#line 86 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
                 currentPerf.AllowEF

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(103, "\n            <td></td>\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(104, "\n        ");
            __builder.OpenElement(105, "tr");
            __builder.AddMarkupContent(106, "\n            ");
            __builder.AddMarkupContent(107, "<td>Max Records</td>\n            ");
            __builder.OpenElement(108, "td");
            __builder.AddContent(109, 
#nullable restore
#line 91 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
                 currentPerf.MaxPage

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(110, "\n            ");
            __builder.OpenElement(111, "td");
            __builder.AddContent(112, 
#nullable restore
#line 92 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
                 currentPerf.Records

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(113, "\n            <td></td>\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(114, "\n\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(115, "\n");
            __builder.CloseElement();
            __builder.AddMarkupContent(116, "\n");
#nullable restore
#line 98 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 100 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\PerfDara.razor"
       

    private Performance currentPerf;
    private string errorString;

    protected override async Task OnInitializedAsync()
    {

        try
        {
            currentPerf = await Http.GetFromJsonAsync<Performance>("SchoolPerformance");

            errorString = null;
        }
        catch (Exception ex)
        {
            errorString = $"There was an error getting our schools API performance data: { ex.Message }";
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591