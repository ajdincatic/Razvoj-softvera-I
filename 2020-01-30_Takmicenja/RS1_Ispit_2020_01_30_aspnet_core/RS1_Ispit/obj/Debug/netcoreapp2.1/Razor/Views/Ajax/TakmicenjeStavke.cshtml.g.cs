#pragma checksum "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a3767bc5e608531cb2f5fb7e060123b5cac1a837"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ajax_TakmicenjeStavke), @"mvc.1.0.view", @"/Views/Ajax/TakmicenjeStavke.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Ajax/TakmicenjeStavke.cshtml", typeof(AspNetCore.Views_Ajax_TakmicenjeStavke))]
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
#line 1 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\_ViewImports.cshtml"
using RS1_Ispit_asp.net_core.VM;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a3767bc5e608531cb2f5fb7e060123b5cac1a837", @"/Views/Ajax/TakmicenjeStavke.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c1d38cc17611c033bae3cd81390fe1be388e9160", @"/Views/_ViewImports.cshtml")]
    public class Views_Ajax_TakmicenjeStavke : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AjaxTakmicenjeStavkeVM>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("ajax-poziv", new global::Microsoft.AspNetCore.Html.HtmlString("da"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("ajax-rezultat", new global::Microsoft.AspNetCore.Html.HtmlString("ajaxDiv"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Ajax/UpdateBodova"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Uredi", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Dodaj", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
  
    ViewData["Title"] = "TakmicenjeStavke";

#line default
#line hidden
            BeginContext(85, 399, true);
            WriteLiteral(@"
<table class=""table table-bordered text-center"">
    <thead>
        <tr>
            <th>Odjeljenje</th>
            <th>
                Broj u
                dnevniku
            </th>
            <th>Pristupio</th>
            <th>
                Rezultat bodovi
                (max 100)
            </th>
            <th>Akcija</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 24 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
         foreach (var x in Model.rows)
        {

#line default
#line hidden
            BeginContext(535, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(574, 12, false);
#line 27 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
               Write(x.Odjeljenje);

#line default
#line hidden
            EndContext();
            BeginContext(586, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(614, 15, false);
#line 28 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
               Write(x.BrojUDnevniku);

#line default
#line hidden
            EndContext();
            BeginContext(629, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 29 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
                 if (Model.Zakljucano)
                {

#line default
#line hidden
            BeginContext(695, 52, true);
            WriteLiteral("                    <td>\r\n                        <a");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 747, "\"", 832, 4);
            WriteAttributeValue("", 755, "color:white;", 755, 12, true);
            WriteAttributeValue(" ", 767, "padding:5px;", 768, 13, true);
            WriteAttributeValue(" ", 780, "background-color:", 781, 18, true);
#line 32 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
WriteAttributeValue("", 798, x.IsPristupio ? "green" : "red", 798, 34, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(833, 31, true);
            WriteLiteral("\r\n                            >");
            EndContext();
            BeginContext(866, 27, false);
#line 33 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
                         Write(x.IsPristupio ? "DA" : "NE");

#line default
#line hidden
            EndContext();
            BeginContext(894, 33, true);
            WriteLiteral("</a>\r\n                    </td>\r\n");
            EndContext();
#line 35 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(987, 50, true);
            WriteLiteral("                    <td>\r\n                        ");
            EndContext();
            BeginContext(1037, 291, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "65646ca7fbee4b27a330c0ef9bf3c31c", async() => {
                BeginContext(1296, 27, false);
#line 41 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
                        Write(x.IsPristupio ? "DA" : "NE");

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "style", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1047, "color:white;", 1047, 12, true);
            AddHtmlAttributeValue(" ", 1059, "padding:5px;", 1060, 13, true);
            AddHtmlAttributeValue(" ", 1072, "background-color:", 1073, 18, true);
#line 39 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
AddHtmlAttributeValue("", 1090, x.IsPristupio ? "green" : "red", 1090, 34, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginWriteTagHelperAttribute();
#line 40 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
                            WriteLiteral(x.IsPristupio ? "UcesnikNijePristupio" : "UcesnikJePristupio");

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-action", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-StavkaId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 40 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
                                                                                                                 WriteLiteral(x.StavkaId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["StavkaId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-StavkaId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["StavkaId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1328, 29, true);
            WriteLiteral("\r\n                    </td>\r\n");
            EndContext();
#line 43 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
                }

#line default
#line hidden
            BeginContext(1376, 18, true);
            WriteLiteral("                \r\n");
            EndContext();
#line 45 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
                 if (Model.Zakljucano)
                {

#line default
#line hidden
            BeginContext(1453, 84, true);
            WriteLiteral("                    <td><input style=\"text-align:center; background-color:lightgray\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 1537, "\"", 1554, 1);
#line 47 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
WriteAttributeValue("", 1545, x.Bodovi, 1545, 9, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1555, 49, true);
            WriteLiteral(" readonly/></td>\r\n                    <td></td>\r\n");
            EndContext();
#line 49 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(1664, 50, true);
            WriteLiteral("                    <td>\r\n                        ");
            EndContext();
            BeginContext(1714, 418, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1e955588e985419aa3676ae809ae176c", async() => {
                BeginContext(1811, 66, true);
                WriteLiteral("\r\n                            <input type=\"hidden\" name=\"StavkaId\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1877, "\"", 1896, 1);
#line 54 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
WriteAttributeValue("", 1885, x.StavkaId, 1885, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1897, 38, true);
                WriteLiteral("/>\r\n                            <input");
                EndContext();
                BeginWriteAttribute("id", " id=\"", 1935, "\"", 1958, 2);
                WriteAttributeValue("", 1940, "bodovi-", 1940, 7, true);
#line 55 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
WriteAttributeValue("", 1947, x.StavkaId, 1947, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1959, 27, true);
                WriteLiteral(" style=\"text-align:center;\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1986, "\"", 2003, 1);
#line 55 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
WriteAttributeValue("", 1994, x.Bodovi, 1994, 9, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2004, 121, true);
                WriteLiteral(" name=\"Bodovi\"/>\r\n                            <input type=\"submit\" style=\"visibility:hidden;\"/>\r\n                        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1724, "forma-", 1724, 6, true);
#line 53 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
AddHtmlAttributeValue("", 1730, x.StavkaId, 1730, 11, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2132, 75, true);
            WriteLiteral("\r\n                        <script>\r\n                            $(\"#bodovi-");
            EndContext();
            BeginContext(2208, 10, false);
#line 59 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
                                  Write(x.StavkaId);

#line default
#line hidden
            EndContext();
            BeginContext(2218, 234, true);
            WriteLiteral("\").change(function () {\r\n                                $.ajax({\r\n                                    type: \"POST\",\r\n                                    url: \"/Ajax/UpdateBodova\",\r\n                                    data: $(\"#forma-");
            EndContext();
            BeginContext(2453, 10, false);
#line 63 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
                                               Write(x.StavkaId);

#line default
#line hidden
            EndContext();
            BeginContext(2463, 132, true);
            WriteLiteral("\").serialize(),\r\n                                    success: function (data) {\r\n                                        $(\"#bodovi-");
            EndContext();
            BeginContext(2596, 10, false);
#line 65 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
                                              Write(x.StavkaId);

#line default
#line hidden
            EndContext();
            BeginContext(2606, 211, true);
            WriteLiteral("\").html(data);\r\n                                    }\r\n                                });\r\n                            });\r\n                        </script>\r\n                    </td>\r\n                    <td>");
            EndContext();
            BeginContext(2817, 104, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "01067701524b461e9c0e03f4da24db09", async() => {
                BeginContext(2912, 5, true);
                WriteLiteral("Uredi");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-StavkaId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 71 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
                                                                                              WriteLiteral(x.StavkaId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["StavkaId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-StavkaId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["StavkaId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2921, 7, true);
            WriteLiteral("</td>\r\n");
            EndContext();
#line 72 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
                }

#line default
#line hidden
            BeginContext(2947, 19, true);
            WriteLiteral("            </tr>\r\n");
            EndContext();
#line 74 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
        }

#line default
#line hidden
            BeginContext(2977, 32, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n<br />\r\n");
            EndContext();
            BeginContext(3009, 149, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "df1a20ff9b864de298f8bc3239f1db25", async() => {
                BeginContext(3140, 14, true);
                WriteLiteral("Dodaj učesnika");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-TakmicenjeId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 78 "C:\Users\Ajdin\Desktop\RS1\Razvoj-softvera-1-master\Rađeno\2020-01-30_Takmicenja\RS1_Ispit_2020_01_30_aspnet_core\RS1_Ispit\Views\Ajax\TakmicenjeStavke.cshtml"
                                                                                                  WriteLiteral(Model.TakmicenjeId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["TakmicenjeId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-TakmicenjeId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["TakmicenjeId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3158, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AjaxTakmicenjeStavkeVM> Html { get; private set; }
    }
}
#pragma warning restore 1591
