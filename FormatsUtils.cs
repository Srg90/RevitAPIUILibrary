using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RevitAPIUILibrary
{
    public class FormatsUtils
    {
        public static List<string> GetFormat(ExternalCommandData commandData)
        {
            var Value = new List<string>();
            string[] format = new string[4] { "DWG", "IFC", "NWC", "JPG" };
            
            foreach (string i in format)
            {
                Value.Add(i);
            }
            return Value;
        }        
    }   
}
