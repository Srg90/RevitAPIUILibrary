using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB.Mechanical;

namespace RevitAPIUILibrary
{
    public class FurnitureUtils
    {
        public static List<FamilySymbol> GetFurnitureTypes(ExternalCommandData commandData)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
           
            var furnSymbols = new FilteredElementCollector(doc)
                      .OfCategory(BuiltInCategory.OST_Furniture)
                      .OfClass(typeof(FamilySymbol))
                      .Cast<FamilySymbol>()
                      .ToList();
           
            return furnSymbols;

        }
    }
}
