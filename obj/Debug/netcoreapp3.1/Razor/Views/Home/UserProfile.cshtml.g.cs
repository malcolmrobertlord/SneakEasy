#pragma checksum "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b71b6232d70d1e5a53f676446b05ab0a7c19098a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_UserProfile), @"mvc.1.0.view", @"/Views/Home/UserProfile.cshtml")]
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
#line 1 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/_ViewImports.cshtml"
using SneakEasy;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/_ViewImports.cshtml"
using SneakEasy.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b71b6232d70d1e5a53f676446b05ab0a7c19098a", @"/Views/Home/UserProfile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f547131f03fbe1988463f3946ffb32ba62f731f9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_UserProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
  
    ViewData["Title"] = "Login";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<div class=\"container1 p-3\" style=\"background-color: white; min-height: 800px; border: 4px solid black;\">\n\n    <h1>Hey ");
#nullable restore
#line 7 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
       Write(ViewBag.LoggedIn.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n\n    <div class=\"row\" style=\"min-height: 300px;\">\n        <div class=\"col-6\">\n            <h3>Your Recent Purchases</h3>\n");
#nullable restore
#line 12 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
             if(ViewBag.LoggedIn.MyOrders == null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h5>You haven\'t made any purchases yet!</h5>\n                <a href=\"/sneakers/all\" class=\"btn btn-primary\">Explore All Shoes</a>\n");
#nullable restore
#line 16 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
            } else {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
                 foreach(Order s in ViewBag.LoggedIn.MyOrders)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"d-flex\">\n                        <img");
            BeginWriteAttribute("src", " src=\"", 690, "\"", 715, 1);
#nullable restore
#line 20 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
WriteAttributeValue("", 696, s.Sneaker.PhotoURL, 696, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 716, "\"", 737, 1);
#nullable restore
#line 20 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
WriteAttributeValue("", 722, s.Sneaker.Name, 722, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"height: 150px; width: 150px;\">\n                        <div class=\"card-body\">\n                            <h5 class=\"card-title\">");
#nullable restore
#line 22 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
                                              Write(s.Sneaker.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n                            <p class=\"card-text\">Brand: ");
#nullable restore
#line 23 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
                                                   Write(s.Sneaker.Brand);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\n                            <p class=\"card-text\">Size: ");
#nullable restore
#line 24 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
                                                  Write(s.Sneaker.Size);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\n                            <p class=\"card-text\">$");
#nullable restore
#line 25 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
                                             Write(s.Sneaker.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                            <p class=\"card-text\">Date Purchased: ");
#nullable restore
#line 26 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
                                                            Write(s.CreatedAt.ToString("MMMM dd, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                        </div>\n                    </div>\n");
#nullable restore
#line 29 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\n        <div class=\"col-6\">\n            <h3>Your Recent Sales</h3>\n");
#nullable restore
#line 34 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
                 foreach (Sneaker s in ViewBag.AllSneakers)
                {
                    if (s.CustomerOrders.Exists(a => a.SneakerId == s.SneakerId) && s.UserId == ViewBag.LoggedIn.UserId)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"d-flex\">\n                            <img");
            BeginWriteAttribute("src", " src=\"", 1700, "\"", 1717, 1);
#nullable restore
#line 39 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
WriteAttributeValue("", 1706, s.PhotoURL, 1706, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1718, "\"", 1731, 1);
#nullable restore
#line 39 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
WriteAttributeValue("", 1724, s.Name, 1724, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"height: 150px; width: 150px;\">\n                            <div class=\"card-body\">\n                                <h5 class=\"card-title\">");
#nullable restore
#line 41 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
                                                  Write(s.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n                                <p class=\"card-text\">Brand: ");
#nullable restore
#line 42 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
                                                       Write(s.Brand);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\n                                <p class=\"card-text\">Size: ");
#nullable restore
#line 43 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
                                                      Write(s.Size);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\n                                <p class=\"card-text\">$");
#nullable restore
#line 44 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
                                                 Write(s.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                                <p class=\"card-text\">Date Sold: ");
#nullable restore
#line 45 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
                                                           Write(s.CustomerOrders.SingleOrDefault().CreatedAt.ToString("MMMM dd, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                            </div>\n                        </div>\n");
#nullable restore
#line 48 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
                    }
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\n    </div>\n    <div class=\"row\">\n        <div class=\"col-6\">\n            <h3>Your Sneakers Up For Sale</h3>\n");
#nullable restore
#line 55 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
             if(ViewBag.LoggedIn.SneakersBeingSold.Count == 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h5>You haven\'t put any sneakers up for sale yet!</h5>\n                <a href=\"/sneakers/add\" class=\"btn btn-secondary\">Sell a Pair</a>\n");
#nullable restore
#line 59 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 60 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
             foreach (Sneaker s in ViewBag.LoggedIn.SneakersBeingSold)
            {
                if(!s.CustomerOrders.Exists(a => a.SneakerId == s.SneakerId))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a");
            BeginWriteAttribute("href", " href=\"", 2916, "\"", 2944, 2);
            WriteAttributeValue("", 2923, "/sneaker/", 2923, 9, true);
#nullable restore
#line 64 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
WriteAttributeValue("", 2932, s.SneakerId, 2932, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                <div class=\"d-flex\">\n                    <img");
            BeginWriteAttribute("src", " src=\"", 3008, "\"", 3025, 1);
#nullable restore
#line 66 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
WriteAttributeValue("", 3014, s.PhotoURL, 3014, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 3026, "\"", 3039, 1);
#nullable restore
#line 66 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
WriteAttributeValue("", 3032, s.Name, 3032, 7, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"height: 150px; width: 150px;\">\n                    <div class=\"card-body\">\n                        <h5 class=\"card-title\">");
#nullable restore
#line 68 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
                                          Write(s.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\n                            <p class=\"card-text\">Brand: ");
#nullable restore
#line 69 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
                                                   Write(s.Brand);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\n                            <p class=\"card-text\">Size: ");
#nullable restore
#line 70 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
                                                  Write(s.Size);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </p>\n                            <p class=\"card-text\">$");
#nullable restore
#line 71 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
                                             Write(s.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                    </div>\n                </div>\n                </a>\n");
#nullable restore
#line 75 "/Users/malcolmrlord/Desktop/CodingDojo/SneakEasy/Views/Home/UserProfile.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\n        <div class=\"col-6\"></div>\n    </div>\n\n</div>");
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
