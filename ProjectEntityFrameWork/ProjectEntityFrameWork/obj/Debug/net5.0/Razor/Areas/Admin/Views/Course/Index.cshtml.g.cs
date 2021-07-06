#pragma checksum "G:\ASP.NET\ProjectEntityFrameWork\ProjectEntityFrameWork\Areas\Admin\Views\Course\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4c96164580736091c0c12ed9bd955a42744accda"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Course_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Course/Index.cshtml")]
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
#line 1 "G:\ASP.NET\ProjectEntityFrameWork\ProjectEntityFrameWork\Areas\Admin\Views\_ViewImports.cshtml"
using ProjectEntityFrameWork;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\ASP.NET\ProjectEntityFrameWork\ProjectEntityFrameWork\Areas\Admin\Views\_ViewImports.cshtml"
using ProjectEntityFrameWork.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c96164580736091c0c12ed9bd955a42744accda", @"/Areas/Admin/Views/Course/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7466c0ca6fdc7b6bf03ad344d2b289e1cd4492bd", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Course_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProjectEntityFrameWork.Areas.Admin.Models.CourseListModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "G:\ASP.NET\ProjectEntityFrameWork\ProjectEntityFrameWork\Areas\Admin\Views\Course\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    <link rel=\"stylesheet\" href=\"/admin/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css\">v\r\n");
            }
            );
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script src=""/admin/plugins/datatables/jquery.dataTables.min.js""></script>
    <script src=""/admin/plugins/datatables-bs4/js/dataTables.bootstrap4.min.js""></script>
    <script>
    $(function () {
            
            $('#courses').DataTable();
        });</script>
");
            }
            );
            WriteLiteral(@"

        <!-- Content Wrapper. Contains page content -->
          <section class=""content-header"">
                    <div class=""container-fluid"">
                    <div class=""row mb-2"">
                        <div class=""col-sm-6"">
                            <h1>Available Courses</h1>
                        </div>
                        <div class=""col-sm-6"">
                           <ol class=""breadcrumb float-sm-right"">
                                <li class=""breadcrumb-item""><a href=""#"">Home</a></li>
                                <li class=""breadcrumb-item active"">Courses</li>
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
                            ");
            WriteLiteral(@"<div class=""card"">
                                <div class=""card-header"">
                                    <h3 class=""card-title"">All Available Courses</h3>
                                </div>
                                <!-- /.card-header -->
                                <div class=""card-body"">
                                    <table id=""courses"" class=""table table-bordered table-hover"">
                                        <thead>
                                            <tr>
                                                <th>Title</th>
                                                <th>Fees</th>
                                                <th>Start Date</th> 
                                            </tr>
                                        </thead>
                                        <tbody>
");
#nullable restore
#line 59 "G:\ASP.NET\ProjectEntityFrameWork\ProjectEntityFrameWork\Areas\Admin\Views\Course\Index.cshtml"
                                             foreach (var course in Model.Courses)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr>\r\n                                                    <td>");
#nullable restore
#line 62 "G:\ASP.NET\ProjectEntityFrameWork\ProjectEntityFrameWork\Areas\Admin\Views\Course\Index.cshtml"
                                                   Write(course.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 63 "G:\ASP.NET\ProjectEntityFrameWork\ProjectEntityFrameWork\Areas\Admin\Views\Course\Index.cshtml"
                                                   Write(course.Fees);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 64 "G:\ASP.NET\ProjectEntityFrameWork\ProjectEntityFrameWork\Areas\Admin\Views\Course\Index.cshtml"
                                                   Write(course.StartDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                </tr>\r\n");
#nullable restore
#line 66 "G:\ASP.NET\ProjectEntityFrameWork\ProjectEntityFrameWork\Areas\Admin\Views\Course\Index.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        </tbody>
                                        <tfoot>
                                            <tr>
                                                <th>Title</th>
                                                <th>Fees</th>
                                                <th>Start Date</th> 
                                            </tr>
                                        </tfoot>
                                    </table>
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
        <!-- /.content-wrapper -->
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProjectEntityFrameWork.Areas.Admin.Models.CourseListModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
