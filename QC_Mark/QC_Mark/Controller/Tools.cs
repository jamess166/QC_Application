#region Imported Namespaces

//.NET common used namespaces
//Revit.NET common used namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.ExtensibleStorage;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
//QCLibrary.NET common used namespaces
using QCLibraryRevit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;


#endregion

namespace QC_Mark
{
    /// <summary>
    /// Class Alternate
    /// </summary>
    class Alternate
    {
        /// <summary>
        /// Asignar numero de plano a refuerzos
        /// </summary>
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Class divide
    /// </summary>
    class Divide
    {
        /// <summary>
        /// Asignar numero de plano a refuerzos
        /// </summary>
        public static void Execute()
        {

        }
    }

    /// <summary>
    /// Herramientas para obtner elementos
    /// </summary>
    class RevitTools
    {
        public static ExternalCommandData commandData { get; set; }
        public static UIDocument uidoc { get; internal set; }
        public static Application app { get; set; }
        public static Document doc { get; set; }
        public static Selection sel { get; set; }
    }

    /// <summary>
    /// Clase de herramientas de vista
    /// </summary>
    class ViewTools
    {
        public static int selOption { get; set; }
        public static bool isGroupByRebarNumber { get; set; }
        public static bool isModifiableParameters { get; set; }
    }
}
