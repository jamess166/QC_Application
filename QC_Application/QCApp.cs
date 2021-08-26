#region Imported Namespaces

//.NET common used namespaces
//Revit.NET common used namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

#endregion

namespace QC_Application
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    class QCApp : IExternalApplication
    {
        public const string ribbonTab = "QC Application";
        public const string ribbonPanel = "General";

        /// <summary>
        /// Este metodo implementa la aplicación que sera invocada cuando Revit inicie 
        /// antes que cualquier archivo o plantilla sea cargado.
        /// </summary>
        /// <param name="application">Uun objeto que se pasa desde la aplicacion externa que contiene la aplicacion controlada.</param>
        /// <returns>Devuelve el resultado del estado de la aplicacion externa. Resultado Exitoso, la aplicación cargo correctamente. Resultado Cancelado, el usuario cancelo la carga del aplicativo.  Resultado False, la aplicación no cargo y el usuario debe hacer correcciones.</returns>
        public Result OnStartup(UIControlledApplication application)
        {
            RibbonPanel panel = InterfaceRibbon.CreateRibbonPanel(
                application, ribbonTab, ribbonPanel);

            //Agregar Boton
            panel.AddItem(CreatePushButtons.PushButton(
                "QC_Application.AvailabilityModelView"));

            return Result.Succeeded;
        }

        /// <summary>
        /// Este metodo implementa la aplicación que sera invocada cuando Revit este cerrandodse 
        /// Todos los documentos abiertos se cierran antes de invocar este metodo.
        /// </summary>
        /// <param name="application">Uun objeto que se pasa desde la aplicacion externa que contiene la aplicacion controlada.</param>
        /// <returns>Devuelve el resultado del estado de la aplicacion externa.</returns>
        public Result OnShutdown(UIControlledApplication application)
        {
            //TODO: Agrega tu codigo aqui
            return Result.Succeeded;
        }
    }
}
