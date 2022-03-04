using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Mechanical;

namespace RevitAPIUILibrary
{
    public class PipesUtils
    {
        public static List<PipingSystemType> GetPipeSystems(ExternalCommandData commandData)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;


            List<PipingSystemType> pipeSystemTypes = new FilteredElementCollector(doc)
                                                       .OfClass(typeof(PipingSystemType))
                                                       .Cast<PipingSystemType>()
                                                       .ToList();
            return pipeSystemTypes;
        }

    }
}
