#pragma checksum "G:\ASP.NET\InventorySystem\InventorySystem.Web\Areas\Admin\Views\Shared\_AdminMenuPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "32ff4b0662130ef8b0242aee101dee79f1f2cca1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared__AdminMenuPartial), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/_AdminMenuPartial.cshtml")]
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
#line 1 "G:\ASP.NET\InventorySystem\InventorySystem.Web\Areas\Admin\Views\_ViewImports.cshtml"
using InventorySystem.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "G:\ASP.NET\InventorySystem\InventorySystem.Web\Areas\Admin\Views\_ViewImports.cshtml"
using InventorySystem.Web.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32ff4b0662130ef8b0242aee101dee79f1f2cca1", @"/Areas/Admin/Views/Shared/_AdminMenuPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5078cc41fb3d51068d87e217d36850ccedc3a1ed", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared__AdminMenuPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""sidebar"">
    <!-- Sidebar user panel (optional) -->
    <div class=""user-panel mt-3 pb-3 mb-3 d-flex"">
        <div class=""image"">
            <img src=""/admin/img/user2-160x160.jpg"" class=""img-circle elevation-2"" alt=""User Image"">
        </div>
        <div class=""info"">
            <a href=""#"" class=""d-block"">Alexander Pierce</a>
        </div>
    </div>

    <!-- SidebarSearch Form -->
    <div class=""form-inline"">
        <div class=""input-group"" data-widget=""sidebar-search"">
            <input class=""form-control form-control-sidebar"" type=""search"" placeholder=""Search"" aria-label=""Search"">
            <div class=""input-group-append"">
                <button class=""btn btn-sidebar"">
                    <i class=""fas fa-search fa-fw""></i>
                </button>
            </div>
        </div>
    </div>

    <!-- Sidebar Menu -->
    <nav class=""mt-2"">
        <ul class=""nav nav-pills nav-sidebar flex-column"" data-widget=""treeview"" role=""menu"" data-accordion=""fa");
            WriteLiteral(@"lse"">
            <!-- Add icons to the links using the .nav-icon class
                 with font-awesome or any other icon font library -->
            <li class=""nav-item menu-open"">
                <a href=""#"" class=""nav-link active"">
                    <i class=""nav-icon fas fa-tachometer-alt""></i>
                    <p>
                        Dashboard
                        <i class=""right fas fa-angle-left""></i>
                    </p>
                </a>
                <ul class=""nav nav-treeview"">
                    <li class=""nav-item"">
                        <a href=""./index.html"" class=""nav-link active"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Dashboard v1</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""./index2.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                        ");
            WriteLiteral(@"    <p>Dashboard v2</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""./index3.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Dashboard v3</p>
                        </a>
                    </li>
                </ul>
            </li>
            <li class=""nav-item"">
                <a href=""pages/widgets.html"" class=""nav-link"">
                    <i class=""nav-icon fas fa-th""></i>
                    <p>
                        Widgets
                        <span class=""right badge badge-danger"">New</span>
                    </p>
                </a>
            </li>
            <li class=""nav-item"">
                <a href=""#"" class=""nav-link"">
                    <i class=""nav-icon fas fa-copy""></i>
                    <p>
                        Layout Options
                        <i class=""fas fa-angle-left righ");
            WriteLiteral(@"t""></i>
                        <span class=""badge badge-info right"">6</span>
                    </p>
                </a>
                <ul class=""nav nav-treeview"">
                    <li class=""nav-item"">
                        <a href=""pages/layout/top-nav.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Top Navigation</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/layout/top-nav-sidebar.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Top Navigation + Sidebar</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/layout/boxed.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Boxed</p>
     ");
            WriteLiteral(@"                   </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/layout/fixed-sidebar.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Fixed Sidebar</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/layout/fixed-sidebar-custom.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Fixed Sidebar <small>+ Custom Area</small></p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/layout/fixed-topnav.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Fixed Navbar</p>
                        </a>
                    </li>
                    <li class");
            WriteLiteral(@"=""nav-item"">
                        <a href=""pages/layout/fixed-footer.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Fixed Footer</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/layout/collapsed-sidebar.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Collapsed Sidebar</p>
                        </a>
                    </li>
                </ul>
            </li>
            <li class=""nav-item"">
                <a href=""#"" class=""nav-link"">
                    <i class=""nav-icon fas fa-chart-pie""></i>
                    <p>
                        Charts
                        <i class=""right fas fa-angle-left""></i>
                    </p>
                </a>
                <ul class=""nav nav-treeview"">
                    <li class=""nav-it");
            WriteLiteral(@"em"">
                        <a href=""pages/charts/chartjs.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>ChartJS</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/charts/flot.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Flot</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/charts/inline.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Inline</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/charts/uplot.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
        ");
            WriteLiteral(@"                    <p>uPlot</p>
                        </a>
                    </li>
                </ul>
            </li>
            <li class=""nav-item"">
                <a href=""#"" class=""nav-link"">
                    <i class=""nav-icon fas fa-tree""></i>
                    <p>
                        UI Elements
                        <i class=""fas fa-angle-left right""></i>
                    </p>
                </a>
                <ul class=""nav nav-treeview"">
                    <li class=""nav-item"">
                        <a href=""pages/UI/general.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>General</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/UI/icons.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Icons</p>
                ");
            WriteLiteral(@"        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/UI/buttons.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Buttons</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/UI/sliders.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Sliders</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/UI/modals.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Modals & Alerts</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/UI/navbar.html"" class=""nav-link"">");
            WriteLiteral(@"
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Navbar & Tabs</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/UI/timeline.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Timeline</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/UI/ribbons.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Ribbons</p>
                        </a>
                    </li>
                </ul>
            </li>
            <li class=""nav-item"">
                <a href=""#"" class=""nav-link"">
                    <i class=""nav-icon fas fa-edit""></i>
                    <p>
                        Forms
                        <i class=");
            WriteLiteral(@"""fas fa-angle-left right""></i>
                    </p>
                </a>
                <ul class=""nav nav-treeview"">
                    <li class=""nav-item"">
                        <a href=""pages/forms/general.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>General Elements</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/forms/advanced.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Advanced Elements</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/forms/editors.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Editors</p>
                        </a>
                    </li>
       ");
            WriteLiteral(@"             <li class=""nav-item"">
                        <a href=""pages/forms/validation.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Validation</p>
                        </a>
                    </li>
                </ul>
            </li>
            <li class=""nav-item"">
                <a href=""#"" class=""nav-link"">
                    <i class=""nav-icon fas fa-table""></i>
                    <p>
                        Tables
                        <i class=""fas fa-angle-left right""></i>
                    </p>
                </a>
                <ul class=""nav nav-treeview"">
                    <li class=""nav-item"">
                        <a href=""pages/tables/simple.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Simple Tables</p>
                        </a>
                    </li>
                    <li class=""nav-item");
            WriteLiteral(@""">
                        <a href=""pages/tables/data.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>DataTables</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/tables/jsgrid.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>jsGrid</p>
                        </a>
                    </li>
                </ul>
            </li>
            <li class=""nav-header"">EXAMPLES</li>
            <li class=""nav-item"">
                <a href=""pages/calendar.html"" class=""nav-link"">
                    <i class=""nav-icon far fa-calendar-alt""></i>
                    <p>
                        Calendar
                        <span class=""badge badge-info right"">2</span>
                    </p>
                </a>
            </li>
            <li class=""nav-i");
            WriteLiteral(@"tem"">
                <a href=""pages/gallery.html"" class=""nav-link"">
                    <i class=""nav-icon far fa-image""></i>
                    <p>
                        Gallery
                    </p>
                </a>
            </li>
            <li class=""nav-item"">
                <a href=""pages/kanban.html"" class=""nav-link"">
                    <i class=""nav-icon fas fa-columns""></i>
                    <p>
                        Kanban Board
                    </p>
                </a>
            </li>
            <li class=""nav-item"">
                <a href=""#"" class=""nav-link"">
                    <i class=""nav-icon far fa-envelope""></i>
                    <p>
                        Mailbox
                        <i class=""fas fa-angle-left right""></i>
                    </p>
                </a>
                <ul class=""nav nav-treeview"">
                    <li class=""nav-item"">
                        <a href=""pages/mailbox/mailbox.html"" class=""nav-lin");
            WriteLiteral(@"k"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Inbox</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/mailbox/compose.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Compose</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/mailbox/read-mail.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Read</p>
                        </a>
                    </li>
                </ul>
            </li>
            <li class=""nav-item"">
                <a href=""#"" class=""nav-link"">
                    <i class=""nav-icon fas fa-book""></i>
                    <p>
                        Pages
                        <i clas");
            WriteLiteral(@"s=""fas fa-angle-left right""></i>
                    </p>
                </a>
                <ul class=""nav nav-treeview"">
                    <li class=""nav-item"">
                        <a href=""pages/examples/invoice.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Invoice</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/examples/profile.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Profile</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/examples/e-commerce.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>E-commerce</p>
                        </a>
                    </li>
          ");
            WriteLiteral(@"          <li class=""nav-item"">
                        <a href=""pages/examples/projects.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Projects</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/examples/project-add.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Project Add</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/examples/project-edit.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Project Edit</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/examples/project-detail.html"" class=""nav-link"">
    ");
            WriteLiteral(@"                        <i class=""far fa-circle nav-icon""></i>
                            <p>Project Detail</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/examples/contacts.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Contacts</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/examples/faq.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>FAQ</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/examples/contact-us.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Contact us</p>
                        </a>
");
            WriteLiteral(@"                    </li>
                </ul>
            </li>
            <li class=""nav-item"">
                <a href=""#"" class=""nav-link"">
                    <i class=""nav-icon far fa-plus-square""></i>
                    <p>
                        Extras
                        <i class=""fas fa-angle-left right""></i>
                    </p>
                </a>
                <ul class=""nav nav-treeview"">
                    <li class=""nav-item"">
                        <a href=""#"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>
                                Login & Register v1
                                <i class=""fas fa-angle-left right""></i>
                            </p>
                        </a>
                        <ul class=""nav nav-treeview"">
                            <li class=""nav-item"">
                                <a href=""pages/examples/login.html"" class=""nav-link"">
         ");
            WriteLiteral(@"                           <i class=""far fa-circle nav-icon""></i>
                                    <p>Login v1</p>
                                </a>
                            </li>
                            <li class=""nav-item"">
                                <a href=""pages/examples/register.html"" class=""nav-link"">
                                    <i class=""far fa-circle nav-icon""></i>
                                    <p>Register v1</p>
                                </a>
                            </li>
                            <li class=""nav-item"">
                                <a href=""pages/examples/forgot-password.html"" class=""nav-link"">
                                    <i class=""far fa-circle nav-icon""></i>
                                    <p>Forgot Password v1</p>
                                </a>
                            </li>
                            <li class=""nav-item"">
                                <a href=""pages/examples/recover-password.h");
            WriteLiteral(@"tml"" class=""nav-link"">
                                    <i class=""far fa-circle nav-icon""></i>
                                    <p>Recover Password v1</p>
                                </a>
                            </li>
                        </ul>
                    </li>
                    <li class=""nav-item"">
                        <a href=""#"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>
                                Login & Register v2
                                <i class=""fas fa-angle-left right""></i>
                            </p>
                        </a>
                        <ul class=""nav nav-treeview"">
                            <li class=""nav-item"">
                                <a href=""pages/examples/login-v2.html"" class=""nav-link"">
                                    <i class=""far fa-circle nav-icon""></i>
                                    <p>Login v2</p>
               ");
            WriteLiteral(@"                 </a>
                            </li>
                            <li class=""nav-item"">
                                <a href=""pages/examples/register-v2.html"" class=""nav-link"">
                                    <i class=""far fa-circle nav-icon""></i>
                                    <p>Register v2</p>
                                </a>
                            </li>
                            <li class=""nav-item"">
                                <a href=""pages/examples/forgot-password-v2.html"" class=""nav-link"">
                                    <i class=""far fa-circle nav-icon""></i>
                                    <p>Forgot Password v2</p>
                                </a>
                            </li>
                            <li class=""nav-item"">
                                <a href=""pages/examples/recover-password-v2.html"" class=""nav-link"">
                                    <i class=""far fa-circle nav-icon""></i>
                          ");
            WriteLiteral(@"          <p>Recover Password v2</p>
                                </a>
                            </li>
                        </ul>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/examples/lockscreen.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Lockscreen</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/examples/legacy-user-menu.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Legacy User Menu</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/examples/language-menu.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Language Menu</p");
            WriteLiteral(@">
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/examples/404.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Error 404</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/examples/500.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Error 500</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/examples/pace.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Pace</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/examples/blan");
            WriteLiteral(@"k.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Blank Page</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""starter.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Starter Page</p>
                        </a>
                    </li>
                </ul>
            </li>
            <li class=""nav-item"">
                <a href=""#"" class=""nav-link"">
                    <i class=""nav-icon fas fa-search""></i>
                    <p>
                        Search
                        <i class=""fas fa-angle-left right""></i>
                    </p>
                </a>
                <ul class=""nav nav-treeview"">
                    <li class=""nav-item"">
                        <a href=""pages/search/simple.html"" class=""nav-link"">
                    ");
            WriteLiteral(@"        <i class=""far fa-circle nav-icon""></i>
                            <p>Simple Search</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""pages/search/enhanced.html"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Enhanced</p>
                        </a>
                    </li>
                </ul>
            </li>
            <li class=""nav-header"">MISCELLANEOUS</li>
            <li class=""nav-item"">
                <a href=""iframe.html"" class=""nav-link"">
                    <i class=""nav-icon fas fa-ellipsis-h""></i>
                    <p>Tabbed IFrame Plugin</p>
                </a>
            </li>
            <li class=""nav-item"">
                <a href=""https://adminlte.io/docs/3.1/"" class=""nav-link"">
                    <i class=""nav-icon fas fa-file""></i>
                    <p>Documentation</p>
                </a>
 ");
            WriteLiteral(@"           </li>
            <li class=""nav-header"">MULTI LEVEL EXAMPLE</li>
            <li class=""nav-item"">
                <a href=""#"" class=""nav-link"">
                    <i class=""fas fa-circle nav-icon""></i>
                    <p>Level 1</p>
                </a>
            </li>
            <li class=""nav-item"">
                <a href=""#"" class=""nav-link"">
                    <i class=""nav-icon fas fa-circle""></i>
                    <p>
                        Level 1
                        <i class=""right fas fa-angle-left""></i>
                    </p>
                </a>
                <ul class=""nav nav-treeview"">
                    <li class=""nav-item"">
                        <a href=""#"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Level 2</p>
                        </a>
                    </li>
                    <li class=""nav-item"">
                        <a href=""#"" class=""nav-link"">
 ");
            WriteLiteral(@"                           <i class=""far fa-circle nav-icon""></i>
                            <p>
                                Level 2
                                <i class=""right fas fa-angle-left""></i>
                            </p>
                        </a>
                        <ul class=""nav nav-treeview"">
                            <li class=""nav-item"">
                                <a href=""#"" class=""nav-link"">
                                    <i class=""far fa-dot-circle nav-icon""></i>
                                    <p>Level 3</p>
                                </a>
                            </li>
                            <li class=""nav-item"">
                                <a href=""#"" class=""nav-link"">
                                    <i class=""far fa-dot-circle nav-icon""></i>
                                    <p>Level 3</p>
                                </a>
                            </li>
                            <li class=""nav-item"">
  ");
            WriteLiteral(@"                              <a href=""#"" class=""nav-link"">
                                    <i class=""far fa-dot-circle nav-icon""></i>
                                    <p>Level 3</p>
                                </a>
                            </li>
                        </ul>
                    </li>
                    <li class=""nav-item"">
                        <a href=""#"" class=""nav-link"">
                            <i class=""far fa-circle nav-icon""></i>
                            <p>Level 2</p>
                        </a>
                    </li>
                </ul>
            </li>
            <li class=""nav-item"">
                <a href=""#"" class=""nav-link"">
                    <i class=""fas fa-circle nav-icon""></i>
                    <p>Level 1</p>
                </a>
            </li>
            <li class=""nav-header"">LABELS</li>
            <li class=""nav-item"">
                <a href=""#"" class=""nav-link"">
                    <i class=""nav-icon far");
            WriteLiteral(@" fa-circle text-danger""></i>
                    <p class=""text"">Important</p>
                </a>
            </li>
            <li class=""nav-item"">
                <a href=""#"" class=""nav-link"">
                    <i class=""nav-icon far fa-circle text-warning""></i>
                    <p>Warning</p>
                </a>
            </li>
            <li class=""nav-item"">
                <a href=""#"" class=""nav-link"">
                    <i class=""nav-icon far fa-circle text-info""></i>
                    <p>Informational</p>
                </a>
            </li>
        </ul>
    </nav>
    <!-- /.sidebar-menu -->
</div>");
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
