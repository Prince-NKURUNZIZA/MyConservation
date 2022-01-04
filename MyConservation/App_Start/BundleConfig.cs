using System.Web;
using System.Web.Optimization;

namespace MyConservation
{
    public class BundleConfig
    {
        // Pour plus d’informations sur le Bundling, accédez à l’adresse http://go.microsoft.com/fwlink/?LinkId=254725 (en anglais)
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour développer et apprendre. Puis, lorsque vous êtes
            // prêt pour la production, utilisez l’outil de génération sur http://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
            bundles.Add(new StyleBundle("~/Assets/css").Include(
                "~/Assets/css/bootstrap.css",
                "~/Assets/css/fontawesome.css",
                "~/Assets/css/datepicker.css",
                "~/Assets/css/all.css",
                "~/Assets/css/styles.css"
                ));
            bundles.Add(new ScriptBundle("~/Assets/js").Include(
            "~/Assets/js/jquery-1.11.1.js",
             "~/Assets/js/bootstrap.js",
            "~/Assets/js/chart.js",
            "~/Assets/js/chart-data.js",
            "~/Assets/js/easypiechart.js",
            "~/Assets/js/easypiechart-data.js",
            "~/Assets/js/bootstrap-datepicker.js",
            "~/Assets/js/custom.js"));
            bundles.Add(new ScriptBundle("~/Assets2/css").Include(
                "~/Assets2/css/bootstrap.css",
                "~/Assets2/css/bootstrap-theme.css",
                "~/Assets2/css/font-awesome.css",
                "~/Assets2/css/main.css"
                
                ));
            bundles.Add(new ScriptBundle("~/Assets2/js").Include(
                "~/Assets2/js/headroom.js",
                "~/Assets2/js/jQuery.headroom.js",
                "~/Assets2/js/template.js",
                "~/Assets2/js/Script.js"
                ));
            bundles.Add(new StyleBundle("~/Assets3/css").Include(
               "~/Assets2/css/bootstrap.css",
               "~/Assets2/css/Style.css"
              
               ));
           

        }
    }
}