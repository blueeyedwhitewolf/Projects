#pragma checksum "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5672f9596f2806b390b97ea2a064814e1002b5db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vinhos_ListagemGarrafeira), @"mvc.1.0.view", @"/Views/Vinhos/ListagemGarrafeira.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Vinhos/ListagemGarrafeira.cshtml", typeof(AspNetCore.Views_Vinhos_ListagemGarrafeira))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5672f9596f2806b390b97ea2a064814e1002b5db", @"/Views/Vinhos/ListagemGarrafeira.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44be2ae3f79708a2f6b007e58422b997c634f7fd", @"/Views/_ViewImports.cshtml")]
    public class Views_Vinhos_ListagemGarrafeira : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<lab_vinfinita.Models.Vinho>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CriarVinho", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-responsive center-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("object-fit:scale-down; width:200px; height:300px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AtualizarStock", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AtualizarPreco", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DetalhesVinho", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ApagarVinho", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(48, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
  
    ViewData["Title"] = "Listagem de Vinhos";

#line default
#line hidden
            BeginContext(104, 63, true);
            WriteLiteral("\r\n\r\n<h2>Catálogo de Vinhos</h2>\r\n<h2>Listagem</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(167, 49, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "02d1b90e30764a17ab0f885f86bd8caa", async() => {
                BeginContext(194, 18, true);
                WriteLiteral("Adicionar um vinho");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(216, 8, true);
            WriteLiteral("\r\n</p>\r\n");
            EndContext();
            BeginContext(259, 299, true);
            WriteLiteral(@"<div id=""tabs"">
    <ul>
        <li><a href=""#vinhobranco"">Vinho Branco</a></li>
        <li><a href=""#vinhotinto"">Vinho Tinto</a></li>
        <li><a href=""#vinhrose"">Vinho Rosé</a></li>
    </ul>
</div>

<table class=""table"">
    <thead>
        <tr>
            <th>
                ");
            EndContext();
            BeginContext(559, 45, false);
#line 27 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
           Write(Html.DisplayNameFor(model => model.NomeVinho));

#line default
#line hidden
            EndContext();
            BeginContext(604, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(660, 46, false);
#line 30 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
           Write(Html.DisplayNameFor(model => model.Capacidade));

#line default
#line hidden
            EndContext();
            BeginContext(706, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(762, 31, false);
#line 33 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
           Write(Html.DisplayName("Fotografias"));

#line default
#line hidden
            EndContext();
            BeginContext(793, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(849, 49, false);
#line 36 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
           Write(Html.DisplayNameFor(model => model.TeorAlcoolico));

#line default
#line hidden
            EndContext();
            BeginContext(898, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(954, 42, false);
#line 39 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
           Write(Html.DisplayNameFor(model => model.Castas));

#line default
#line hidden
            EndContext();
            BeginContext(996, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1052, 47, false);
#line 42 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
           Write(Html.DisplayNameFor(model => model.AnoProducao));

#line default
#line hidden
            EndContext();
            BeginContext(1099, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1155, 24, false);
#line 45 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
           Write(Html.DisplayName("Tipo"));

#line default
#line hidden
            EndContext();
            BeginContext(1179, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1235, 26, false);
#line 48 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
           Write(Html.DisplayName("Regiao"));

#line default
#line hidden
            EndContext();
            BeginContext(1261, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1317, 28, false);
#line 51 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
           Write(Html.DisplayName("Produtor"));

#line default
#line hidden
            EndContext();
            BeginContext(1345, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1401, 25, false);
#line 54 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
           Write(Html.DisplayName("Preco"));

#line default
#line hidden
            EndContext();
            BeginContext(1426, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1482, 25, false);
#line 57 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
           Write(Html.DisplayName("Stock"));

#line default
#line hidden
            EndContext();
            BeginContext(1507, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 63 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(1642, 15, true);
            WriteLiteral("            <tr");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 1657, "\"", 1716, 1);
#line 65 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
WriteAttributeValue("", 1662, item.Inserir.Where(p=>p.IdGarrafeira==ViewBag.id_gar), 1662, 54, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1717, 45, true);
            WriteLiteral(">\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1763, 44, false);
#line 67 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
               Write(Html.DisplayFor(modelItem => item.NomeVinho));

#line default
#line hidden
            EndContext();
            BeginContext(1807, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1875, 45, false);
#line 70 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
               Write(Html.DisplayFor(modelItem => item.Capacidade));

#line default
#line hidden
            EndContext();
            BeginContext(1920, 666, true);
            WriteLiteral(@"
                </td>
                <td>

                    <div id=""myCarousel"" class=""carousel slide"" data-ride=""carousel"" data-interval=""6000"">
                        <ol class=""carousel-indicators"">
                            <li data-target=""#myCarousel"" data-slide-to=""0"" class=""active""></li>
                            <li data-target=""#myCarousel"" data-slide-to=""1""></li>
                            <li data-target=""#myCarousel"" data-slide-to=""2""></li>
                        </ol>
                        <div class=""carousel-inner"" role=""listbox"">
                            <div class=""item active"">
                                ");
            EndContext();
            BeginContext(2586, 131, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "42542ef8ce5f48a5a614585c6dc56366", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2689, "~/fotos/", 2689, 8, true);
#line 82 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
AddHtmlAttributeValue("", 2697, item.FotoFrente, 2697, 16, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2717, 118, true);
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"item\">\r\n                                ");
            EndContext();
            BeginContext(2835, 129, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3135e319fdf84f03a90ed995f7591a45", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2938, "~/fotos/", 2938, 8, true);
#line 85 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
AddHtmlAttributeValue("", 2946, item.FotoTras, 2946, 14, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2964, 118, true);
            WriteLiteral("\r\n                            </div>\r\n                            <div class=\"item\">\r\n                                ");
            EndContext();
            BeginContext(3082, 131, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1fa9b381ed7b4ef4b7e198e2fd6fa373", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3185, "~/fotos/", 3185, 8, true);
#line 88 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
AddHtmlAttributeValue("", 3193, item.FotoRotulo, 3193, 16, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3213, 866, true);
            WriteLiteral(@"
                            </div>
                        </div>

                        <a class=""left carousel-control"" style=""background:none; color:darkred"" href=""#myCarousel"" role=""button"" data-slide=""prev"">
                            <span class=""glyphicon glyphicon-chevron-left"" aria-hidden=""true""></span>
                            <span class=""sr-only"">Anterior</span>
                        </a>
                        <a class=""right carousel-control"" style=""background:none; color:darkred"" href=""#myCarousel"" role=""button"" data-slide=""next"">
                            <span class=""glyphicon glyphicon-chevron-right"" aria-hidden=""true""></span>
                            <span class=""sr-only"">Próximo</span>
                        </a>
                    </div>

                </td>
                <td>
                    ");
            EndContext();
            BeginContext(4080, 48, false);
#line 104 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
               Write(Html.DisplayFor(modelItem => item.TeorAlcoolico));

#line default
#line hidden
            EndContext();
            BeginContext(4128, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(4196, 41, false);
#line 107 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
               Write(Html.DisplayFor(modelItem => item.Castas));

#line default
#line hidden
            EndContext();
            BeginContext(4237, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(4305, 46, false);
#line 110 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
               Write(Html.DisplayFor(modelItem => item.AnoProducao));

#line default
#line hidden
            EndContext();
            BeginContext(4351, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(4419, 68, false);
#line 113 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
               Write(Html.DisplayFor(modelItem => item.Possuir.IdTipoNavigation.NomeTipo));

#line default
#line hidden
            EndContext();
            BeginContext(4487, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(4555, 72, false);
#line 116 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
               Write(Html.DisplayFor(modelItem => item.Possuir.IdRegiaoNavigation.NomeRegiao));

#line default
#line hidden
            EndContext();
            BeginContext(4627, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(4695, 76, false);
#line 119 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
               Write(Html.DisplayFor(modelItem => item.Possuir.IdProdutorNavigation.NomeProdutor));

#line default
#line hidden
            EndContext();
            BeginContext(4771, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(4839, 40, false);
#line 122 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
               Write(Html.DisplayFor(modelItem => item.Preco));

#line default
#line hidden
            EndContext();
            BeginContext(4879, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(4947, 40, false);
#line 125 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
               Write(Html.DisplayFor(modelItem => item.Stock));

#line default
#line hidden
            EndContext();
            BeginContext(4987, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(5054, 79, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7cd1051ff4eb4c5587f72d57b36eb421", async() => {
                BeginContext(5114, 15, true);
                WriteLiteral("Atualizar Stock");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 128 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
                                                     WriteLiteral(item.IdVinho);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5133, 24, true);
            WriteLiteral(" |\r\n                    ");
            EndContext();
            BeginContext(5157, 79, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fe6560d5b11d41d8a81864dd021b964e", async() => {
                BeginContext(5217, 15, true);
                WriteLiteral("Atualizar Preco");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 129 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
                                                     WriteLiteral(item.IdVinho);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5236, 24, true);
            WriteLiteral(" |\r\n                    ");
            EndContext();
            BeginContext(5260, 80, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4cd66373a76f444398734f6a7ce2d4a5", async() => {
                BeginContext(5319, 17, true);
                WriteLiteral("Detalhes do vinho");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 130 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
                                                    WriteLiteral(item.IdVinho);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5340, 24, true);
            WriteLiteral(" |\r\n                    ");
            EndContext();
            BeginContext(5364, 75, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "23cb04b398214c0ca3637c06246f0f1b", async() => {
                BeginContext(5421, 14, true);
                WriteLiteral("Eliminar vinho");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 131 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
                                                  WriteLiteral(item.IdVinho);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5439, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 134 "C:\Users\Admin\Desktop\lab\ProjetoLab_WineBay\lab_vinfinita\Views\Vinhos\ListagemGarrafeira.cshtml"
        }

#line default
#line hidden
            BeginContext(5494, 35, true);
            WriteLiteral("        }\r\n    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<lab_vinfinita.Models.Vinho>> Html { get; private set; }
    }
}
#pragma warning restore 1591