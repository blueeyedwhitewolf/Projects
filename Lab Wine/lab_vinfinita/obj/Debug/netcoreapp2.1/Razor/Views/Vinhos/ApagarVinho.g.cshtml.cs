#pragma checksum "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e3f7d0cb6844bb23b34914476b116532c0cbd710"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vinhos_ApagarVinho), @"mvc.1.0.view", @"/Views/Vinhos/ApagarVinho.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Vinhos/ApagarVinho.cshtml", typeof(AspNetCore.Views_Vinhos_ApagarVinho))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3f7d0cb6844bb23b34914476b116532c0cbd710", @"/Views/Vinhos/ApagarVinho.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44be2ae3f79708a2f6b007e58422b997c634f7fd", @"/Views/_ViewImports.cshtml")]
    public class Views_Vinhos_ApagarVinho : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<lab_vinfinita.Models.Vinho>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ApagarVinho", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(35, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
  
    ViewData["Title"] = "Delete";

#line default
#line hidden
            BeginContext(79, 190, true);
            WriteLiteral("\r\n<h2>Delete</h2>\r\n\r\n<h3>Tem a certeza que quer eliminar este vinho da sua garrafeira?</h3>\r\n<div>\r\n    <h4>Vinho</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(270, 45, false);
#line 15 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayNameFor(model => model.NomeVinho));

#line default
#line hidden
            EndContext();
            BeginContext(315, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(359, 41, false);
#line 18 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayFor(model => model.NomeVinho));

#line default
#line hidden
            EndContext();
            BeginContext(400, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(444, 46, false);
#line 21 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayNameFor(model => model.Capacidade));

#line default
#line hidden
            EndContext();
            BeginContext(490, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(534, 42, false);
#line 24 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayFor(model => model.Capacidade));

#line default
#line hidden
            EndContext();
            BeginContext(576, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(620, 46, false);
#line 27 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayNameFor(model => model.FotoFrente));

#line default
#line hidden
            EndContext();
            BeginContext(666, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(710, 42, false);
#line 30 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayFor(model => model.FotoFrente));

#line default
#line hidden
            EndContext();
            BeginContext(752, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(796, 44, false);
#line 33 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayNameFor(model => model.FotoTras));

#line default
#line hidden
            EndContext();
            BeginContext(840, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(884, 40, false);
#line 36 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayFor(model => model.FotoTras));

#line default
#line hidden
            EndContext();
            BeginContext(924, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(968, 46, false);
#line 39 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayNameFor(model => model.FotoRotulo));

#line default
#line hidden
            EndContext();
            BeginContext(1014, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1058, 42, false);
#line 42 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayFor(model => model.FotoRotulo));

#line default
#line hidden
            EndContext();
            BeginContext(1100, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1144, 49, false);
#line 45 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayNameFor(model => model.TeorAlcoolico));

#line default
#line hidden
            EndContext();
            BeginContext(1193, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1237, 45, false);
#line 48 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayFor(model => model.TeorAlcoolico));

#line default
#line hidden
            EndContext();
            BeginContext(1282, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1326, 42, false);
#line 51 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayNameFor(model => model.Castas));

#line default
#line hidden
            EndContext();
            BeginContext(1368, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1412, 38, false);
#line 54 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayFor(model => model.Castas));

#line default
#line hidden
            EndContext();
            BeginContext(1450, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1494, 47, false);
#line 57 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayNameFor(model => model.AnoProducao));

#line default
#line hidden
            EndContext();
            BeginContext(1541, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1585, 43, false);
#line 60 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayFor(model => model.AnoProducao));

#line default
#line hidden
            EndContext();
            BeginContext(1628, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1672, 77, false);
#line 63 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayNameFor(model => model.Possuir.IdProdutorNavigation.NomeProdutor));

#line default
#line hidden
            EndContext();
            BeginContext(1749, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1793, 73, false);
#line 66 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayFor(model => model.Possuir.IdProdutorNavigation.NomeProdutor));

#line default
#line hidden
            EndContext();
            BeginContext(1866, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1910, 73, false);
#line 69 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayNameFor(model => model.Possuir.IdRegiaoNavigation.NomeRegiao));

#line default
#line hidden
            EndContext();
            BeginContext(1983, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2027, 69, false);
#line 72 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayFor(model => model.Possuir.IdRegiaoNavigation.NomeRegiao));

#line default
#line hidden
            EndContext();
            BeginContext(2096, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2140, 69, false);
#line 75 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayNameFor(model => model.Possuir.IdTipoNavigation.NomeTipo));

#line default
#line hidden
            EndContext();
            BeginContext(2209, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2253, 65, false);
#line 78 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayFor(model => model.Possuir.IdTipoNavigation.NomeTipo));

#line default
#line hidden
            EndContext();
            BeginContext(2318, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2362, 41, false);
#line 81 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayNameFor(model => model.Preco));

#line default
#line hidden
            EndContext();
            BeginContext(2403, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2447, 37, false);
#line 84 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayFor(model => model.Preco));

#line default
#line hidden
            EndContext();
            BeginContext(2484, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(2528, 41, false);
#line 87 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayNameFor(model => model.Stock));

#line default
#line hidden
            EndContext();
            BeginContext(2569, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(2613, 37, false);
#line 90 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
       Write(Html.DisplayFor(model => model.Stock));

#line default
#line hidden
            EndContext();
            BeginContext(2650, 38, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    \r\n    ");
            EndContext();
            BeginContext(2688, 241, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0bed0483307e4a09b8467aee938f87f5", async() => {
                BeginContext(2719, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(2729, 41, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ad221b4ad3cf4ded98c81c946c9b119e", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 95 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ApagarVinho.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.IdVinho);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2770, 108, true);
                WriteLiteral("\r\n        <input type=\"submit\" value=\"Apagar vinho da sua garrafeira\" class=\"btn btn-default\" /> |\r\n        ");
                EndContext();
                BeginContext(2878, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e31df04ffcad499ca9b4a8ae0518d77d", async() => {
                    BeginContext(2900, 12, true);
                    WriteLiteral("Voltar atrás");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2916, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2929, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<lab_vinfinita.Models.Vinho> Html { get; private set; }
    }
}
#pragma warning restore 1591