#pragma checksum "C:\WebProg\WebProjesiguz\KitapKesifleri\Views\Book\AllBooks.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c87424bdb41e3e464419375fc1fa986e0a715587"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Book_AllBooks), @"mvc.1.0.view", @"/Views/Book/AllBooks.cshtml")]
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
#line 1 "C:\WebProg\WebProjesiguz\KitapKesifleri\Views\_ViewImports.cshtml"
using KitapKesifleri;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\WebProg\WebProjesiguz\KitapKesifleri\Views\_ViewImports.cshtml"
using KitapKesifleri.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c87424bdb41e3e464419375fc1fa986e0a715587", @"/Views/Book/AllBooks.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6076feb3904c12fb10bce15a529ec3a991b9e525", @"/Views/_ViewImports.cshtml")]
    public class Views_Book_AllBooks : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<KitapKesifleri.Models.Book>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\WebProg\WebProjesiguz\KitapKesifleri\Views\Book\AllBooks.cshtml"
  
    ViewData["Title"] = "All Books";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<!-- Page Content -->
<div class=""page-heading products-heading header-text"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""text-content"">
                    <h4>new arrivals</h4>
                    <h2>sixteen products</h2>
                </div>
            </div>
        </div>
    </div>
</div>


<div class=""products"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-md-12"">
                <div class=""filters"">
                    <ul>
                        <li class=""active"" data-filter=""*"">All Products</li>
                        <li data-filter="".des"">Featured</li>
                        <li data-filter="".dev"">Flash Deals</li>
                        <li data-filter="".gra"">Last Minute</li>
                    </ul>
                </div>
            </div>
            <div class=""col-md-12"">
                <div class=""filters-content"">
                    <d");
            WriteLiteral("iv class=\"row grid\">\r\n");
#nullable restore
#line 39 "C:\WebProg\WebProjesiguz\KitapKesifleri\Views\Book\AllBooks.cshtml"
                         foreach (var x in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <div class=\"col-lg-4 col-md-4 all des\">\r\n                            <div class=\"product-item\">\r\n                                <a href=\"#\"><img");
            BeginWriteAttribute("src", " src=\"", 1388, "\"", 1406, 1);
#nullable restore
#line 43 "C:\WebProg\WebProjesiguz\KitapKesifleri\Views\Book\AllBooks.cshtml"
WriteAttributeValue("", 1394, x.BookCover, 1394, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1407, "\"", 1413, 0);
            EndWriteAttribute();
            WriteLiteral("></a>\r\n                                <div class=\"down-content\">\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 1519, "\"", 1545, 2);
            WriteAttributeValue("", 1526, "/Book/Details/", 1526, 14, true);
#nullable restore
#line 45 "C:\WebProg\WebProjesiguz\KitapKesifleri\Views\Book\AllBooks.cshtml"
WriteAttributeValue("", 1540, x.Id, 1540, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@"><h4>Tittle goes here</h4></a>
                                    <h6>$18.25</h6>
                                    <p>Lorem ipsume dolor sit amet, adipisicing elite. Itaque, corporis nulla aspernatur.</p>
                                    <ul class=""stars"">
                                        <li><i class=""fa fa-star""></i></li>
                                        <li><i class=""fa fa-star""></i></li>
                                        <li><i class=""fa fa-star""></i></li>
                                        <li><i class=""fa fa-star""></i></li>
                                        <li><i class=""fa fa-star""></i></li>
                                    </ul>
                                    <span>Reviews (12)</span>
                                </div>
                            </div>
                        </div>
");
#nullable restore
#line 59 "C:\WebProg\WebProjesiguz\KitapKesifleri\Views\Book\AllBooks.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
            </div></div>
            <div class=""col-md-12"">
                <ul class=""pages"">
                    <li><a href=""#"">1</a></li>
                    <li class=""active""><a href=""#"">2</a></li>
                    <li><a href=""#"">3</a></li>
                    <li><a href=""#"">4</a></li>
                    <li><a href=""#""><i class=""fa fa-angle-double-right""></i></a></li>
                </ul>
            </div>
        </div>
    </div>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<KitapKesifleri.Models.Book>> Html { get; private set; }
    }
}
#pragma warning restore 1591