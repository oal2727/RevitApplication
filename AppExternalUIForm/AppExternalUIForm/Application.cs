using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AppExternalUIForm
{
    //require transaction for execution
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    public class Application : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            throw new NotImplementedException();
        }

        public Result OnStartup(UIControlledApplication app)
        {
            //create tab 
            RibbonPanel panel = app.CreateRibbonPanel("Ribbon Form ui");
            string thisAssemblyPath = Assembly.GetExecutingAssembly().Location;
            PushButton pushButton = panel.AddItem(new PushButtonData("AppExternalUIForm",
                "AppExternalUIForm", thisAssemblyPath, "AppExternalUIForm.Command")) as PushButton;
            // Cuerpo
            pushButton.ToolTip = "Form Body";
            return Result.Succeeded;
        }

    }
}
