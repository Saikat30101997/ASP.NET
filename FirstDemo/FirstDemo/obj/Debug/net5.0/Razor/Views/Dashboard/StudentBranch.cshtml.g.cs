#pragma checksum "G:\ASP.NET\FirstDemo\FirstDemo\Views\Dashboard\StudentBranch.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0b947d2cdda519e1b243993f397cea4b3f10154a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_StudentBranch), @"mvc.1.0.view", @"/Views/Dashboard/StudentBranch.cshtml")]
namespace AspNetCore
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
#line 1 "G:\ASP.NET\FirstDemo\FirstDemo\Views\_ViewImports.cshtml"
using FirstDemo;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "G:\ASP.NET\FirstDemo\FirstDemo\Views\Dashboard\StudentBranch.cshtml"
using FirstDemo.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\ASP.NET\FirstDemo\FirstDemo\Views\Dashboard\StudentBranch.cshtml"
using FirstDemo.Controllers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0b947d2cdda519e1b243993f397cea4b3f10154a", @"/Views/Dashboard/StudentBranch.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"824b310a9460607485b225155cf727f086a76631", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_StudentBranch : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "G:\ASP.NET\FirstDemo\FirstDemo\Views\Dashboard\StudentBranch.cshtml"
  
    ViewData["Title"] = "StudentBranch";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>StudentBranch</h1>\r\n");
#nullable restore
#line 8 "G:\ASP.NET\FirstDemo\FirstDemo\Views\Dashboard\StudentBranch.cshtml"
  

    var std = new StudentInfo();

#line default
#line hidden
#nullable disable
            WriteLiteral("<table style=\"border: 1px solid black\">\r\n    <tr style=\"border:1px solid black\">\r\n        <th>RegNo</th>\r\n        <th>Name</th>\r\n    </tr>\r\n");
#nullable restore
#line 17 "G:\ASP.NET\FirstDemo\FirstDemo\Views\Dashboard\StudentBranch.cshtml"
     foreach (var item in std.GetStudentsRes())
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr style=\"border:1px solid black\">\r\n            <td style=\"border:1px solid black\">");
#nullable restore
#line 20 "G:\ASP.NET\FirstDemo\FirstDemo\Views\Dashboard\StudentBranch.cshtml"
                                          Write(item.RegNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td style=\"border:1px solid black\">");
#nullable restore
#line 21 "G:\ASP.NET\FirstDemo\FirstDemo\Views\Dashboard\StudentBranch.cshtml"
                                          Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 23 "G:\ASP.NET\FirstDemo\FirstDemo\Views\Dashboard\StudentBranch.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
