#pragma checksum "C:\Users\Cayman\OneDrive\Dojo_Assignments\C#\ORM\Entity\WeddingPlanner\Views\Home\WeddingDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "64ae4871909468796238907088f97bf926a631cb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_WeddingDetails), @"mvc.1.0.view", @"/Views/Home/WeddingDetails.cshtml")]
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
#line 1 "C:\Users\Cayman\OneDrive\Dojo_Assignments\C#\ORM\Entity\WeddingPlanner\Views\_ViewImports.cshtml"
using WeddingPlanner;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Cayman\OneDrive\Dojo_Assignments\C#\ORM\Entity\WeddingPlanner\Views\_ViewImports.cshtml"
using WeddingPlanner.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64ae4871909468796238907088f97bf926a631cb", @"/Views/Home/WeddingDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9e9e38482b8beecdb199b7be73dfa5c3d6a2f574", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_WeddingDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"text-center\">\r\n    <h1 class=\"text-success\">Weddings</h1>\r\n    <a href=\"/logout\"><button class=\"btn btn-outline-danger\">Logout!</button></a>\r\n    <a href=\"/WeddingList\"><button class=\"btn btn-outline-primary\">HomePage</button></a>\r\n    <h3>");
#nullable restore
#line 5 "C:\Users\Cayman\OneDrive\Dojo_Assignments\C#\ORM\Entity\WeddingPlanner\Views\Home\WeddingDetails.cshtml"
   Write(ViewBag.Wedding.WeddingOne);

#line default
#line hidden
#nullable disable
            WriteLiteral(" & ");
#nullable restore
#line 5 "C:\Users\Cayman\OneDrive\Dojo_Assignments\C#\ORM\Entity\WeddingPlanner\Views\Home\WeddingDetails.cshtml"
                                 Write(ViewBag.Wedding.WeddingTwo);

#line default
#line hidden
#nullable disable
            WriteLiteral(" Wedding</h3>\r\n    <ul>\r\n        Guests:\r\n");
#nullable restore
#line 8 "C:\Users\Cayman\OneDrive\Dojo_Assignments\C#\ORM\Entity\WeddingPlanner\Views\Home\WeddingDetails.cshtml"
          
            foreach(WeddingGuest guest in ViewBag.Wedding.Guests)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li> ");
#nullable restore
#line 11 "C:\Users\Cayman\OneDrive\Dojo_Assignments\C#\ORM\Entity\WeddingPlanner\Views\Home\WeddingDetails.cshtml"
                Write(guest.Guest.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 11 "C:\Users\Cayman\OneDrive\Dojo_Assignments\C#\ORM\Entity\WeddingPlanner\Views\Home\WeddingDetails.cshtml"
                                       Write(guest.Guest.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 12 "C:\Users\Cayman\OneDrive\Dojo_Assignments\C#\ORM\Entity\WeddingPlanner\Views\Home\WeddingDetails.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n</div>");
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
