#pragma checksum "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Home\Garrafeira.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "80c170c1eefc858797a2d6aff40b1e122814dbbd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Garrafeira), @"mvc.1.0.view", @"/Views/Home/Garrafeira.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Garrafeira.cshtml", typeof(AspNetCore.Views_Home_Garrafeira))]
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
#line 1 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\_ViewImports.cshtml"
using lab_vinfinita;

#line default
#line hidden
#line 2 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\_ViewImports.cshtml"
using lab_vinfinita.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80c170c1eefc858797a2d6aff40b1e122814dbbd", @"/Views/Home/Garrafeira.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44be2ae3f79708a2f6b007e58422b997c634f7fd", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Garrafeira : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Home\Garrafeira.cshtml"
  
    ViewBag.Title = "Catálogo de cada Garrafeira";

#line default
#line hidden
            BeginContext(66, 226, true);
            WriteLiteral("\r\n<ul></ul>\r\n\r\n<div id=\"tabs\">\r\n    <ul>\r\n        <li><a href=\"#garrafeira1\">Garrafeira1</a></li>\r\n        <li><a href=\"#garrafeira2\">Garrafeira2</a></li>\r\n        <li><a href=\"#garrafeira3\">Garrafeira3</a></li>\r\n    </ul>\r\n\r\n");
            EndContext();
            BeginContext(343, 322, true);
            WriteLiteral(@"    <div id=""garrafeira1"">
        <img src="""" id=""imagem2"" width=""150"" height=""320"" />

    </div>

    <div id=""garrafeira2"">
        <img src="""" id=""imagem"" width=""150"" height=""320"" />
    </div>

    <div id=""garrafeira3"">
        <img src="""" id=""imagem"" width=""150"" height=""320"" />
    </div>

</div>

");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(751, 429, true);
                WriteLiteral(@"
    <script>
        var i = 0;
        setInterval(function () {
            i = (i % 3) + 1;
            $(""#imagem"").attr(""src"", ""/images/fotos/vinho"" + i + "".jpg"");
        }, 5000);
        $(""#tabs"").tabs();

        setInterval(function () {
            i = (i % 3) + 1;
            $(""#imagem2"").attr(""src"", ""/images/fotos/vinhoo"" + i + "".jpg"");
        }, 5000);
        $(""#tabs"").tabs();
    </script>
");
                EndContext();
            }
            );
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
