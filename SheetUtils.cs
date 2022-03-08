using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace RevitAPIUILibrary
{
    public class SheetUtils
    {
        public static List<ElementType> GetTitleBlocks(Document doc)
        {
            var titleblock = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_TitleBlocks)
                .WhereElementIsElementType()
                .Cast<ElementType>()
                .ToList();

            return titleblock;
        }
    }
}
