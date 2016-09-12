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
                "~/Scripts/vendors/angular-route.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/spa").Include(
                "~/Scripts/spa/modules/common.core.js",
                "~/Scripts/spa/app.js",
                "~/Scripts/spa/students/index/studentCtrl.js"
                ));

            bundles.Add(new StyleBundle("~/Contents/css").Include(
                "~/Contents/css/site.css"
                ));

            BundleTable.EnableOptimizations = false;
        }
    }
}
