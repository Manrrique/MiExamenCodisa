#pragma checksum "C:\Users\erik.arita\Desktop\Erik\EXAMEN\EXAMEN\Views\Empleados\ArbolEmpleados.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "56c92ed5d5b82e5d05bf45986de6dbec79899512"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Empleados_ArbolEmpleados), @"mvc.1.0.view", @"/Views/Empleados/ArbolEmpleados.cshtml")]
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
#line 1 "C:\Users\erik.arita\Desktop\Erik\EXAMEN\EXAMEN\Views\_ViewImports.cshtml"
using EXAMEN;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\erik.arita\Desktop\Erik\EXAMEN\EXAMEN\Views\_ViewImports.cshtml"
using EXAMEN.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"56c92ed5d5b82e5d05bf45986de6dbec79899512", @"/Views/Empleados/ArbolEmpleados.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b64c5d94071c9fdbf5d8cccd33d43750be0aadd", @"/Views/_ViewImports.cshtml")]
    public class Views_Empleados_ArbolEmpleados : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<EXAMEN.Models.Empleado>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\erik.arita\Desktop\Erik\EXAMEN\EXAMEN\Views\Empleados\ArbolEmpleados.cshtml"
  
    ViewData["Title"] = "ArbolEmpleados";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h4>Arbol de empleados</h4>\r\n\r\n<div>\r\n    <div class=\"row\">\r\n        ");
#nullable restore
#line 12 "C:\Users\erik.arita\Desktop\Erik\EXAMEN\EXAMEN\Views\Empleados\ArbolEmpleados.cshtml"
   Write(await Html.PartialAsync("_EmpleadosPartial", Model));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<EXAMEN.Models.Empleado>> Html { get; private set; }
    }
}
#pragma warning restore 1591
