using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Media.Imaging;

namespace AppExternalUIRevit
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class Application : IExternalApplication
    {
        //  UIControlledApplication : acceso a ciertos eventos de revit
        //  y permite la personalizacion de los paneles y controles de la cinta


        // // Implemente este método para anular el registro de los eventos suscritos cuando finalice Revit
        public Result OnShutdown(UIControlledApplication application)
        {
            // unregister events
            return Result.Succeeded;
        }
        // // Implemente el método OnStartup para registrar eventos cuando se inicia Revit.
        public Result OnStartup(UIControlledApplication app)
        {
            // Crear Tab del Navegador
            RibbonPanel panel = app.CreateRibbonPanel("New Ribbon Panel");
            AddPushButton(panel);
            return Result.Succeeded;
        }
        private void AddPushButton(RibbonPanel panel)
        {
            // location : GetViaAppDomain
            // //: D:\Software\DynamicAssemblyLoad\DynamicAssemblyLoad\bin\Debug\
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;
            PushButton pushButton = panel.AddItem(new PushButtonData("HelloWorld",
                "HelloWorld", thisAssemblyPath, "HelloWorld.CsHelloWorld")) as PushButton;

            // Cuerpo
            pushButton.ToolTip = "Say Hello World";

            // Set the large image shown on button
            Uri uri = new Uri(@"C:\Users\josel\source\repos\AppExternalUIRevit\AppExternalUIRevit\bin\Debug\dj.ico");
            BitmapImage bitmapImage = new BitmapImage(uri);
            pushButton.LargeImage = bitmapImage;


        }

    }
}
