using Autofac;
using DataImporter.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataImporter.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ReCaptchaSettings>().As<IReCaptchaSettings>()
                .InstancePerLifetimeScope();
            builder.RegisterType<GooglereCaptchaService>().As<IGooglereCaptchaService>()
             .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}

//< !--
//@section Scripts
//{
//    < partial name = "_ValidationScriptsPartial" />
 
//     < script src = "https://www.google.com/recaptcha/api.js?render=@GooglereCaptcha.Value.ReCAPTCHA_Site_Key" ></ script >
  
//      < script >
//          function onClick(e) {
//        e.preventDefault();
//        grecaptcha.ready(function() {
//            grecaptcha.execute('@GooglereCaptcha.Value.ReCAPTCHA_Site_Key', { action: 'submit' }).then(function(token) {
//                // Add your logic to submit to your backend server here.
//                console.log(token);
//            });
//        });
//    }
//    </ script >
//}
//-->

