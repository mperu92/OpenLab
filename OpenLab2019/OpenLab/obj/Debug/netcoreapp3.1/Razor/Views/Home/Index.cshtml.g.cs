#pragma checksum "C:\Users\matte\Source\Repos\OpenLab\OpenLab2019\OpenLab\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d27c0e33f2e0330a91f13e880d9cba333596e09d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\matte\Source\Repos\OpenLab\OpenLab2019\OpenLab\Views\_ViewImports.cshtml"
using OpenLab;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\matte\Source\Repos\OpenLab\OpenLab2019\OpenLab\Views\_ViewImports.cshtml"
using OpenLab.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\matte\Source\Repos\OpenLab\OpenLab2019\OpenLab\Views\_ViewImports.cshtml"
using OpenLab.Infrastructure.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\matte\Source\Repos\OpenLab\OpenLab2019\OpenLab\Views\_ViewImports.cshtml"
using OpenLab.Infrastructure.PresentationModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\matte\Source\Repos\OpenLab\OpenLab2019\OpenLab\Views\_ViewImports.cshtml"
using OpenLab.Infrastructure.Interfaces.PresentationModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d27c0e33f2e0330a91f13e880d9cba333596e09d", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d9782dfdd1e3ff59ad9a1013dd8f44e64e36c03", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\matte\Source\Repos\OpenLab\OpenLab2019\OpenLab\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    Layout = "~/Views/Shared/_Layout.cshtml";

    string errorMessage = ViewBag.ErrorMessage ?? string.Empty;
    string successMessage = ViewBag.SuccessMessage ?? string.Empty;

    string user = ViewBag.User ?? string.Empty;
    int isLoggedNuber = ViewBag.IsLogged == true ? 1 : 0;
    int isAdminRoleNumber = ViewBag.IsAdminRole == true ? 1 : 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<script type=\"text/javascript\">\r\n    __globalJsData.successMessage = \'");
#nullable restore
#line 14 "C:\Users\matte\Source\Repos\OpenLab\OpenLab2019\OpenLab\Views\Home\Index.cshtml"
                                Write(successMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n    __globalJsData.errorMessage = \'");
#nullable restore
#line 15 "C:\Users\matte\Source\Repos\OpenLab\OpenLab2019\OpenLab\Views\Home\Index.cshtml"
                              Write(errorMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n\r\n    __globalJsData.user = \'");
#nullable restore
#line 17 "C:\Users\matte\Source\Repos\OpenLab\OpenLab2019\OpenLab\Views\Home\Index.cshtml"
                       Write(Html.Raw(user));

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n    __globalJsData.isLogged = ");
#nullable restore
#line 18 "C:\Users\matte\Source\Repos\OpenLab\OpenLab2019\OpenLab\Views\Home\Index.cshtml"
                         Write(isLoggedNuber);

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n    __globalJsData.isAdminRole = ");
#nullable restore
#line 19 "C:\Users\matte\Source\Repos\OpenLab\OpenLab2019\OpenLab\Views\Home\Index.cshtml"
                            Write(isAdminRoleNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n</script>\r\n\r\n<div id=\"ol-controller\" class=\"ol-dashboard-frontend\" data-controller=\"dashboardPageFrontend\">\r\n    <div id=\"js-frontend\"></div>\r\n</div>\r\n");
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
