using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPIUILibrary
{
    public class SelectionUtils
    {
        public static Element PickObject(ExternalCommandData commandData, string message = "Выберете элемент")
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            var selectedObject = uidoc.Selection.PickObject(ObjectType.Element, message);
            var oElement = doc.GetElement(selectedObject);
            return oElement;
        }

        public static T GetObject<T>(ExternalCommandData commandData, string promptMessage)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
            Reference selectedObj = null;
            T elem;

            try 
            {
                selectedObj = uidoc.Selection.PickObject(ObjectType.Element, promptMessage);
            }
            catch (Exception)
            {
                return default(T);
            }
            elem = (T)(object)doc.GetElement(selectedObj.ElementId);
            return elem;
        }

        public static List<Element> PickObjects(ExternalCommandData commandData, string message = "Выберете элементы")
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            var selectedObjects = uidoc.Selection.PickObjects(ObjectType.Element, message);
            List<Element> elementList = selectedObjects.Select(selectedObject => doc.GetElement(selectedObject)).ToList();
            return elementList;
        }

        public static List<XYZ> GetPoints(ExternalCommandData commandData,
            string promtMessage, ObjectSnapTypes objectSnapTypes)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;

            List<XYZ> points = new List<XYZ>();

            while (true)
            {
                XYZ pickedPoint = null;
                try 
                {
                    pickedPoint = uidoc.Selection.PickPoint(objectSnapTypes, promtMessage);
                }
                catch (Autodesk.Revit.Exceptions.OperationCanceledException)
                {
                    break;
                }
                points.Add(pickedPoint);
            }
            return points;
        }

        public static List<string> GetCount(ExternalCommandData commandData)
        {
            var Value = new List<string>();
            //int[] number = Enumerable.Range(1, 10).ToArray();
            int[] number = new int[10] {1,2,3,4,5,6,7,8,9,10};
            //for (int i = 1; i <= 10; i++)
            //    number[i] = i + 1;
            
            foreach (int i in number)
            {
                Value.Add(i.ToString());
            }
            return Value;
        }

        public static double GetLenght (ExternalCommandData commandData, XYZ p1, XYZ p2)
        {
            var vX = p2.X - p1.X;
            var vY = p2.Y - p1.Y;
            var vZ = p2.Z - p1.Z; 
            var lenghtVec = (double)Math.Sqrt(vX * vX + vY * vY + vZ * vZ);
            return lenghtVec;
        }
    }
}
