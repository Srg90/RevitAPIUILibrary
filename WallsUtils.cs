﻿using System;
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
    public class WallsUtils
    {
        public static List<WallType> GetWallTypes(ExternalCommandData commandData)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            var wallTypes = new FilteredElementCollector(doc)
                                                       .OfClass(typeof(WallType))
                                                       .Cast<WallType>()
                                                       .ToList();
                      
            return wallTypes;
        }
    }
}
