#pragma checksum "C:\Users\Administrator\Desktop\kaniniday1\dbms\day7\day16\FirstMVCApplication\FirstMVCApplication\Views\Student\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "00f4d957027aee1a280d4113d1a45359a43d5f78"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Student_Index), @"mvc.1.0.view", @"/Views/Student/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00f4d957027aee1a280d4113d1a45359a43d5f78", @"/Views/Student/Index.cshtml")]
    public class Views_Student_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FirstMVCApplication.Models.Student>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<div>\r\n    Student Id: ");
#nullable restore
#line 38 "C:\Users\Administrator\Desktop\kaniniday1\dbms\day7\day16\FirstMVCApplication\FirstMVCApplication\Views\Student\Index.cshtml"
           Write(Model.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <br />\r\n    Student Name: ");
#nullable restore
#line 40 "C:\Users\Administrator\Desktop\kaniniday1\dbms\day7\day16\FirstMVCApplication\FirstMVCApplication\Views\Student\Index.cshtml"
             Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <br />\r\n    Student Age: ");
#nullable restore
#line 42 "C:\Users\Administrator\Desktop\kaniniday1\dbms\day7\day16\FirstMVCApplication\FirstMVCApplication\Views\Student\Index.cshtml"
            Write(Model.Age);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FirstMVCApplication.Models.Student> Html { get; private set; }
    }
}
#pragma warning restore 1591