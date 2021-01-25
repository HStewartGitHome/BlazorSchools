#pragma checksum "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\SchoolData.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f6dae78bd8af9fdd24f1619cb54670870a6891f8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(RazorSchools.Client.Pages.Pages_SchoolData), @"mvc.1.0.razor-page", @"/Pages/SchoolData.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6dae78bd8af9fdd24f1619cb54670870a6891f8", @"/Pages/SchoolData.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0948a26c333b0b93c9a67210234ced6edcc1e036", @"/Pages/_ViewImports.cshtml")]
    public class Pages_SchoolData : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\SchoolData.cshtml"
  
    ViewData["Title"] = "School API Data";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h3>School API Data</h3>\n\n");
#nullable restore
#line 9 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\SchoolData.cshtml"
 if (string.IsNullOrWhiteSpace(Model.ErrorString) == false)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"h2\">");
#nullable restore
#line 11 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\SchoolData.cshtml"
               Write(Model.ErrorString);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div> ");
#nullable restore
#line 11 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\SchoolData.cshtml"
                                             }
else if (@Model.CurrentSchools == null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"h4\">Loading...</div> ");
#nullable restore
#line 14 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\SchoolData.cshtml"
                                     }
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>\n        Start ");
#nullable restore
#line 18 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\SchoolData.cshtml"
         Write(Model.CurrentSchools.CurrentIndex);

#line default
#line hidden
#nullable disable
            WriteLiteral("  of ");
#nullable restore
#line 18 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\SchoolData.cshtml"
                                                Write(Model.CurrentSchools.MaxIndex);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </p>\n");
            WriteLiteral(@"    <table class=""table table-striped"">
        <thead class=""thead-dark"">
            <tr>
                <th>Name</th>
                <th>Street</th>
                <th>City</th>
                <th>State</th>
                <th>Zip</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 32 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\SchoolData.cshtml"
             foreach (var s in Model.CurrentSchools.schools)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\n                    <td>");
#nullable restore
#line 35 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\SchoolData.cshtml"
                   Write(s.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 36 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\SchoolData.cshtml"
                   Write(s.street);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 37 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\SchoolData.cshtml"
                   Write(s.city);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 38 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\SchoolData.cshtml"
                   Write(s.state);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 39 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\SchoolData.cshtml"
                   Write(s.zip);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                </tr>\n");
#nullable restore
#line 41 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\SchoolData.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\n    </table>\n");
#nullable restore
#line 44 "C:\SRC\BlazorSchools-master\RazorSchools.Client\Pages\SchoolData.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RazorSchools.Client.Pages.SchoolDataModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RazorSchools.Client.Pages.SchoolDataModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<RazorSchools.Client.Pages.SchoolDataModel>)PageContext?.ViewData;
        public RazorSchools.Client.Pages.SchoolDataModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591