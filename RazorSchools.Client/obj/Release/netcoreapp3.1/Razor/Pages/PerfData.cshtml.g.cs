#pragma checksum "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "881837828a1ba4a943f93045e73767bb35ee0d2b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(RazorSchools.Client.Pages.Pages_PerfData), @"mvc.1.0.razor-page", @"/Pages/PerfData.cshtml")]
namespace RazorSchools.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\_ViewImports.cshtml"
using RazorSchools.Client;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"881837828a1ba4a943f93045e73767bb35ee0d2b", @"/Pages/PerfData.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0948a26c333b0b93c9a67210234ced6edcc1e036", @"/Pages/_ViewImports.cshtml")]
    public class Pages_PerfData : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml"
  
    ViewData["Title"]= "School API Performance Data";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n<h3>School API Performance Data</h3>\n\n");
#nullable restore
#line 10 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml"
 if (string.IsNullOrWhiteSpace(Model.ErrorString) == false)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"h2\">");
#nullable restore
#line 12 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml"
           Write(Model.ErrorString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div> ");
#nullable restore
#line 12 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml"
                                         }
else if (Model.CurrentPerf is null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"h4\">Loading...</div> ");
#nullable restore
#line 15 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml"
                                 }
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<table class=""table table-striped"">
    <thead class=""thead-dark"">
        <tr>
            <th>Performance</th>
            <th>Update</th>
            <th>Read</th>
            <th>Read2</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Initialize Performance</td>
            <td></td>
            <td>");
#nullable restore
#line 31 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml"
           Write(Model.CurrentPerf.InitPerformance);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td></td>\n        </tr>\n        <tr>\n            <td>Json Performance</td>\n            <td></td>\n            <td>");
#nullable restore
#line 37 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml"
           Write(Model.CurrentPerf.JsonPerformance);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 38 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml"
           Write(Model.CurrentPerf.JsonPerformance2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n        <tr>\n            <td>Dapper Performance</td>\n            <td>");
#nullable restore
#line 42 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml"
           Write(Model.CurrentPerf.DapperUpdatePerformance);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 43 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml"
           Write(Model.CurrentPerf.DapperPerformance);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 44 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml"
           Write(Model.CurrentPerf.DapperPerformance2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n        <tr>\n            <td>Entity Framework Performance</td>\n            <td>");
#nullable restore
#line 48 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml"
           Write(Model.CurrentPerf.EFUpdatePerformance);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 49 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml"
           Write(Model.CurrentPerf.EFPerformance);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 50 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml"
           Write(Model.CurrentPerf.EFPerformance2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n        <tr>\n            <td>Simulated Performance</td>\n            <td>");
#nullable restore
#line 54 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml"
           Write(Model.CurrentPerf.SimUpdatePerformance);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 55 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml"
           Write(Model.CurrentPerf.SimPerformance);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 56 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml"
           Write(Model.CurrentPerf.SimPerformance2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n        <tr>\n            <td>Use Simulated</td>\n            <td></td>\n            <td>");
#nullable restore
#line 61 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml"
           Write(Model.CurrentPerf.UseSIM);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td></td>\n        </tr>\n        <tr>\n            <td>Use Dapper Framework</td>\n            <td></td>\n            <td>");
#nullable restore
#line 67 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml"
           Write(Model.CurrentPerf.UseDapper);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td></td>\n        </tr>\n        <tr>\n            <td>Use Entity Framework</td>\n            <td></td>\n            <td>");
#nullable restore
#line 73 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml"
           Write(Model.CurrentPerf.UseEF);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td></td>\n        </tr>\n        <tr>\n            <td>Allow Dapper Framework</td>\n            <td></td>\n            <td>");
#nullable restore
#line 79 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml"
           Write(Model.CurrentPerf.AllowDapper);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td></td>\n        </tr>\n        <tr>\n            <td>Allow Entity Framework</td>\n            <td></td>\n            <td>");
#nullable restore
#line 85 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml"
           Write(Model.CurrentPerf.AllowEF);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td></td>\n        </tr>\n        <tr>\n            <td>Max Records</td>\n            <td>");
#nullable restore
#line 90 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml"
           Write(Model.CurrentPerf.MaxPage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td>");
#nullable restore
#line 91 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml"
           Write(Model.CurrentPerf.Records);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            <td></td>\n        </tr>\n\n    </tbody>\n</table>\n");
#nullable restore
#line 97 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\PerfData.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RazorSchools.Client.Pages.PerfDataModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RazorSchools.Client.Pages.PerfDataModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RazorSchools.Client.Pages.PerfDataModel>)PageContext?.ViewData;
        public RazorSchools.Client.Pages.PerfDataModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
