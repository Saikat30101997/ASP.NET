#pragma checksum "G:\ASP.NET\Assignment3\AttendanceSystem\AttendanceSystem.Web\Areas\Admin\Views\Student\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e7c4066600bf7f6d68ae143073a4400bd02744c0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Student_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Student/Index.cshtml")]
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
#line 1 "G:\ASP.NET\Assignment3\AttendanceSystem\AttendanceSystem.Web\Areas\Admin\Views\_ViewImports.cshtml"
using AttendanceSystem.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\ASP.NET\Assignment3\AttendanceSystem\AttendanceSystem.Web\Areas\Admin\Views\_ViewImports.cshtml"
using AttendanceSystem.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e7c4066600bf7f6d68ae143073a4400bd02744c0", @"/Areas/Admin/Views/Student/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a53e28e0c4fb6ece1dcc12245e4aaaf93bd63d0b", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Student_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<AttendanceSystem.Web.Areas.Admin.Models.Students.StudentListModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_DeletePopUpPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "G:\ASP.NET\Assignment3\AttendanceSystem\AttendanceSystem.Web\Areas\Admin\Views\Student\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    <link rel=\"stylesheet\" href=\"/admin/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css\">\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""/admin/plugins/datatables/jquery.dataTables.min.js""></script>
    <script src=""/admin/plugins/datatables-bs4/js/dataTables.bootstrap4.min.js""></script>
    <script>
        $(function () {
            $('#students').DataTable({
                ""processing"": true,
                ""serverSide"": true,
                ""ajax"": ""/Admin/Student/GetStudentData"",
                ""columnDefs"": [
                    {
                        ""orderable"": false,
                        ""targets"": 2,
                        ""render"": function (data, type, row) {
                            return `<button type=""submit"" class=""btn btn-info btn-sm"" onclick=""window.location.href='/admin/student/edit/${data}'"" value='${data}'>
                                        <i class=""fas fa-pencil-alt"">
                                        </i>
                                        Edit
                                    </button>
                                    <button type=""submit"" cla");
                WriteLiteral(@"ss=""btn btn-danger btn-sm show-bs-modal"" href=""#"" data-id='${data}' value='${data}'>
                                        <i class=""fas fa-trash"">
                                        </i>
                                        Delete
                                    </button>`;
                        }
                    }
                ]
            });
            $('#students').on('click', '.show-bs-modal', function (event) {
                var id = $(this).data(""id"");
                var modal = $(""#modal-default"");
                modal.find('.modal-body p').text('Are you sure you want to delete this record?')
                $(""#deleteId"").val(id);
                $(""#deleteForm"").attr(""action"", ""/admin/student/delete"")
                modal.modal('show');
            });
            $(""#deleteButton"").click(function () {
                $(""#deleteForm"").submit();
            });
        });

    </script>
");
            }
            );
            WriteLiteral(@"
<!-- Content Wrapper. Contains page content -->
<section class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-sm-6"">
                <h1>Available Students</h1>
            </div>
            <div class=""col-sm-6"">
                <ol class=""breadcrumb float-sm-right"">
                    <li class=""breadcrumb-item""><a href=""#"">Home</a></li>
                    <li class=""breadcrumb-item active"">Students</li>
                </ol>
            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>


<!-- Main content -->
<section class=""content"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-12"">
                <div class=""card"">
                    <div class=""card-header"">
                        <h3 class=""card-title"">All Available Students</h3>
                    </div>
                    <!-- /.card-header -->
                    <div class=""card-body"">");
            WriteLiteral(@"
                        <table id=""students"" class=""table table-bordered table-hover"">
                            <thead>
                                <tr>
                                    <th>Name</th>
                                    <th>Student Roll Number</th>
                                    <th style=""width:150px"">Action</th>
                                </tr>
                            </thead>
                            <tfoot>
                                <tr>
                                    <th>Name</th>
                                    <th>Student Roll Number</th>
                                    <th style=""width:150px"">Action</th>
                                </tr>
                            </tfoot>
                        </table>
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e7c4066600bf7f6d68ae143073a4400bd02744c08216", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                    </div>
                    <!-- /.card-body -->
                </div>
                <!-- /.card -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
    </div>
    <!-- /.container-fluid -->
</section>
<!-- /.content-wrapper -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AttendanceSystem.Web.Areas.Admin.Models.Students.StudentListModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
