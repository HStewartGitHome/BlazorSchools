#pragma checksum "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\SchoolData.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b9c6af6f7851f2b2f5708ea8bc7888c89e7ecf64"
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
#line 3 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\SchoolData.razor"
using BlazorSchools.Shared;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/SchoolData")]
    public partial class SchoolData : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<h3>School API Data</h3>\n\n\n");
#nullable restore
#line 10 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\SchoolData.razor"
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
#line 12 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\SchoolData.razor"
                     errorString

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(5, "\n");
#nullable restore
#line 13 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\SchoolData.razor"
}
else if (currentSchools is null)
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(6, "    ");
            __builder.AddMarkupContent(7, "<div class=\"h4\">Loading...</div>\n");
#nullable restore
#line 17 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\SchoolData.razor"
}
else
{

#line default
#line hidden
#nullable disable
            __builder.AddContent(8, "    ");
            __builder.OpenElement(9, "p");
            __builder.AddMarkupContent(10, "\n        Start ");
            __builder.AddContent(11, 
#nullable restore
#line 21 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\SchoolData.razor"
               currentSchools.CurrentIndex

#line default
#line hidden
#nullable disable
            );
            __builder.AddContent(12, "  of ");
            __builder.AddContent(13, 
#nullable restore
#line 21 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\SchoolData.razor"
                                                currentSchools.MaxIndex

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(14, " \n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(15, "\n");
            __builder.AddContent(16, "    ");
            __builder.OpenElement(17, "table");
            __builder.AddAttribute(18, "class", "table table-striped");
            __builder.AddMarkupContent(19, "\n        ");
            __builder.AddMarkupContent(20, "<thead class=\"thead-dark\">\n            <tr>\n                <th>Name</th>\n                <th>Street</th>\n                <th>City</th>\n                <th>State</th>\n                <th>Zip</th>\n            </tr>\n        </thead>\n        ");
            __builder.OpenElement(21, "tbody");
            __builder.AddMarkupContent(22, "\n");
#nullable restore
#line 35 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\SchoolData.razor"
             foreach (var s in currentSchools.schools) 
            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(23, "                ");
            __builder.OpenElement(24, "tr");
            __builder.AddMarkupContent(25, "\n                    ");
            __builder.OpenElement(26, "td");
            __builder.AddContent(27, 
#nullable restore
#line 38 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\SchoolData.razor"
                         s.name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(28, "\n                    ");
            __builder.OpenElement(29, "td");
            __builder.AddContent(30, 
#nullable restore
#line 39 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\SchoolData.razor"
                         s.street

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\n                    ");
            __builder.OpenElement(32, "td");
            __builder.AddContent(33, 
#nullable restore
#line 40 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\SchoolData.razor"
                         s.city

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\n                    ");
            __builder.OpenElement(35, "td");
            __builder.AddContent(36, 
#nullable restore
#line 41 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\SchoolData.razor"
                         s.state

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\n                    ");
            __builder.OpenElement(38, "td");
            __builder.AddContent(39, 
#nullable restore
#line 42 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\SchoolData.razor"
                         s.zip

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(41, "\n");
#nullable restore
#line 44 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\SchoolData.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.AddContent(42, "        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(43, "\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(44, "\n");
#nullable restore
#line 47 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\SchoolData.razor"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
#nullable restore
#line 49 "C:\SRC\BlazorSchools-master\BlazorSchools\Client\Pages\SchoolData.razor"
       

    private Schools currentSchools;
    private string errorString;

    protected override async Task OnInitializedAsync()
    {


        try
        {
            currentSchools = await Http.GetFromJsonAsync<Schools>("SchoolModel");

            errorString = null;
        }
        catch (Exception ex)
        {
            errorString = $"There was an error getting our schools: { ex.Message }";
        }
    }





#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591