using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace AngularMaterial.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
                "~/Scripts/vendors/angular-route.js",
                "~/Scripts/vendors/angular-cookies.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/spa").Include(
                "~/Scripts/spa/modules/common.core.js",
                "~/Scripts/spa/app.js",
                "~/Scripts/spa/layouts/sideNav.directive.js",
                "~/Scripts/spa/courses/index/courseCtrl.js",
                "~/Scripts/spa/courses/detail/courseDetailCtrl.js",
                "~/Scripts/spa/courses/add/courseAddCtrl.js",
                "~/Scripts/spa/settings/settingCtrl.js",
                "~/Scripts/spa/home/indexCtrl.js",
                "~/Scripts/spa/home/rootCtrl.js",
                "~/Scripts/spa/departments/index/departmentCtrl.js",
                "~/Scripts/spa/departments/detail/departmentDetailCtrl.js",
                "~/Scripts/spa/students/index/studentCtrl.js",
                "~/Scripts/spa/students/detail/studentDetailCtrl.js",
                "~/Scripts/spa/layouts/bottomSheetListTemplateCtrl.js",
                "~/Scripts/spa/students/add/studentAddCtrl.js"
                ));

            bundles.Add(new StyleBundle("~/Contents/css").Include(
                "~/Contents/css/site.css"
                ));

            BundleTable.EnableOptimizations = false;
        }
    }
}
