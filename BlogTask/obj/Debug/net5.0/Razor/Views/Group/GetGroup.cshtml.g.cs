#pragma checksum "D:\Courses\Core\Social Project\V4\BlogTask\BlogTask\Views\Group\GetGroup.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "06ccc663c69d5f1ae36c633d87a0d9997151d686"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Group_GetGroup), @"mvc.1.0.view", @"/Views/Group/GetGroup.cshtml")]
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
#line 1 "D:\Courses\Core\Social Project\V4\BlogTask\BlogTask\Views\_ViewImports.cshtml"
using BlogTask;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Courses\Core\Social Project\V4\BlogTask\BlogTask\Views\_ViewImports.cshtml"
using BlogTask.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Courses\Core\Social Project\V4\BlogTask\BlogTask\Views\_ViewImports.cshtml"
using BlogTaskDB.DAL.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Courses\Core\Social Project\V4\BlogTask\BlogTask\Views\_ViewImports.cshtml"
using BlogTaskDB.DAL.Paginattion;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"06ccc663c69d5f1ae36c633d87a0d9997151d686", @"/Views/Group/GetGroup.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c86f60ebe908687d98ebb6d293a7dc20f8a6f90e", @"/Views/_ViewImports.cshtml")]
    public class Views_Group_GetGroup : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Delete.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n\r\n<div id=\"searchSection\">\r\n  \r\n</div>\r\n\r\n<div id=\"headerGroup\">\r\n\r\n</div>\r\n<input id=\"groupId\" type=\"hidden\"");
            BeginWriteAttribute("name", " name=\"", 113, "\"", 120, 0);
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 121, "\"", 145, 1);
#nullable restore
#line 11 "D:\Courses\Core\Social Project\V4\BlogTask\BlogTask\Views\Group\GetGroup.cshtml"
WriteAttributeValue("", 129, ViewBag.GroupID, 129, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n<div class=\"row mt-3\">\r\n    <p class=\"col-md-3\">\r\n        <a");
            BeginWriteAttribute("onclick", " onclick=\"", 211, "\"", 315, 3);
            WriteAttributeValue("", 221, "showInputPopup(\'", 221, 16, true);
#nullable restore
#line 14 "D:\Courses\Core\Social Project\V4\BlogTask\BlogTask\Views\Group\GetGroup.cshtml"
WriteAttributeValue("", 237, Url.Action("CreatePostInGroup","Post",new { id = ViewBag.GroupID}), 237, 67, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 304, "\',\'Create\')", 304, 11, true);
            EndWriteAttribute();
            WriteLiteral(@" style=""cursor:pointer"" class=""btn btn-info""><i class=""fa fa-plus"" aria-hidden=""true""></i></a>
    </p>
</div>

<div id=""allPosts"">

</div>
<div class=""modal"" tabindex=""-1"" id=""form-modal"">
    <div class=""modal-dialog"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title""></h5>
                <button type=""button"" class=""btn-close"" data-bs-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">

            </div>

        </div>
    </div>
</div>

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "06ccc663c69d5f1ae36c633d87a0d9997151d6865793", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<script>
    $(document).ready(function () {
        var _groupID = document.getElementById(""groupId"").value;
        var groupID = parseInt(_groupID);
        //alert(groupID);
        getSearchForm(groupID);
        GetHeaderGroup(groupID);
        GetPostsIngroup(groupID, 1, null);
    })
    function GetHeaderGroup(id) {
        var groupId = id;
        $.ajax({
            type: ""Get"",
            //url: 'Group/GetDataGroup',
            url: '");
#nullable restore
#line 54 "D:\Courses\Core\Social Project\V4\BlogTask\BlogTask\Views\Group\GetGroup.cshtml"
             Write(Url.Action("GetDataGroup","Group"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"',
            data: {
                ""id"": groupId
            },
            success: (res) => {
                $(""#headerGroup"").html(res);
            }, error: () => {
                $(""#headerGroup"").html(""Can't Load Data."");

            }
        })
    }

    //function GetPostsIngroup(id,pageIndex) {
    //    var groupId = id;
       
    //    $.ajax({
    //        type: ""Get"",
    //        url: '/Post/GetPostsInGroup?id=' + id + '&pageIndex=' + pageIndex,
            
    //        success: (res) => {
    //            $(""#allPosts"").html(res);
    //        }, error: () => {
    //            $(""#allPosts"").html(""Can't Load Data."");

    //        }
    //    })
    //}

    //Try
    function GetPostsIngroup(id, pageIndex,_data) {
        var groupId = id;

        $.ajax({
            type: ""Get"",
            url: '/Post/GetPostsInGroup?id=' + id + '&pageIndex=' + pageIndex,
            data: _data,
            success: (res) => {
                $(""#");
            WriteLiteral(@"allPosts"").html(res);
            }, error: () => {
                $(""#allPosts"").html(""Can't Load Data."");

            }
        })
    }
    function getSearchForm(id) {
        $.ajax({
            type: ""Get"",
            url: '/Post/GetSearchForm',
            data: { ""id"": id },
            success: (res) => {
                $(""#searchSection"").html(res);
            },
            error: (res) => {
                $(""#searchSection"").html(""Can't load Form Section"");

            }
        })

    }
</script>");
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
