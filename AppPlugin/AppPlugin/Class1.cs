using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPlugin
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Class1:IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData,ref string message,ElementSet elements)
        {
            // 1.acceso aplicacion obtener documentos y objetos
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
           //2.Definir ferente a objeto , cuando se selecciona un elemento
            Reference pickedref = null;
            //3.Seleccionar Grupo
            Selection sel = uiapp.ActiveUIDocument.Selection;
            pickedref = sel.PickObject(ObjectType.Element, "Select Group");
            Element elem = doc.GetElement(pickedref);
            Group group = elem as Group;
            //4.Seleccionar punto
            XYZ point = sel.PickPoint("Please pick a point to group");
            //5.Lugar del grupo
            Transaction trans = new Transaction(doc);
            trans.Start("Lab");
            doc.Create.PlaceGroup(point, group.GroupType);
            trans.Commit();

            return Result.Succeeded;

        }
    }
}
