#pragma checksum "C:\Users\matte\Source\Repos\OpenLab\OpenLab2019\OpenLab\Areas\Backoffice\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91c55c8e8f1b74fd8f1cfcc67e609a84fce89fea"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Backoffice_Views_Dashboard_Index), @"mvc.1.0.view", @"/Areas/Backoffice/Views/Dashboard/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91c55c8e8f1b74fd8f1cfcc67e609a84fce89fea", @"/Areas/Backoffice/Views/Dashboard/Index.cshtml")]
    public class Areas_Backoffice_Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\matte\Source\Repos\OpenLab\OpenLab2019\OpenLab\Areas\Backoffice\Views\Dashboard\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_LayoutBackoffice.cshtml";

    string welcomePhrase = "Here you can load contents";
    string userName = ViewBag.Username;
    bool isAdmin = User.IsInRole("Admin");
    if (isAdmin) welcomePhrase += " and manage application";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"jumbotron text-center\">\r\n        <h1>Backoffice Dashboard</h1>\r\n        <hr />\r\n        <p>Hi <b>");
#nullable restore
#line 16 "C:\Users\matte\Source\Repos\OpenLab\OpenLab2019\OpenLab\Areas\Backoffice\Views\Dashboard\Index.cshtml"
            Write(userName);

#line default
#line hidden
#nullable disable
            WriteLiteral(",</b></p>\r\n        <p>");
#nullable restore
#line 17 "C:\Users\matte\Source\Repos\OpenLab\OpenLab2019\OpenLab\Areas\Backoffice\Views\Dashboard\Index.cshtml"
      Write(welcomePhrase);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n</div>\r\n");
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
