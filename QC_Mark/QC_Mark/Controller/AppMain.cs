#region Imported Namespaces

//.NET common used namespaces
//Revit.NET common used namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
//QCLibrary.NET common used namespaces
using QCLibraryRevit;
using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

#endregion

namespace QC_Mark
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class AppMain : IExternalCommand
    {
        /// <summary>
        /// El unico metodo requerido por la interfaz IExternalCommand,
        /// Punto de entrada para el comando externo.
        /// </summary>
        /// <param name="commandData"></param>
        /// <param name="message"></param>
        /// <param name="elements"></param>
        /// <returns></returns>
        public Result Execute(
                ExternalCommandData commandData,
                ref string message,
                ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Application app = uiapp.Application;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //Verificar Licencia
            if (LicenseLocal.ActiveProduct(uiapp.Application.LoginUserId) == false)
                return Result.Cancelled;

            //variables estaticas
            RevitTools.doc = doc;
            RevitTools.app = app;
            RevitTools.uidoc = uidoc;
            RevitTools.sel = sel;

            //Abrir Ventana
            try
            {
                QCApp.thisApp.ShowForm();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Failed;
            }

            return Result.Succeeded;
        }
    }
}
