#region Imported Namespaces

//Revit.NET common used namespaces
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

#endregion


namespace QC_Application
{
    /// <summary>
    /// Clase para indicar la disponibilidad del boton solo en planos
    /// </summary>
    public class AvailabilityViewSheet : IExternalCommandAvailability
    {
        public bool IsCommandAvailable(UIApplication a, CategorySet selectedCategories)
        {
            if (a.ActiveUIDocument == null) { return false; }

            if (a.ActiveUIDocument.Document
            .ActiveView.ViewType == ViewType.DrawingSheet)
            { return true; }

            else
            { return false; }
        }
    }

    /// <summary>
    /// Clase para indicar la disponibilidad del boton solo en planos
    /// </summary>
    public class AvailabilitySchedule : IExternalCommandAvailability
    {
        public bool IsCommandAvailable(UIApplication a, CategorySet selectedCategories)
        {
            if (a.ActiveUIDocument == null) { return false; }

            if (a.ActiveUIDocument.Document
            .ActiveView.ViewType == ViewType.Schedule)
            { return true; }

            else
            { return false; }
        }
    }

    /// <summary>
    /// Clase para indicar la disponibilidad del boton solo en dibujos
    /// </summary>
    public class AvailabilityModelView : IExternalCommandAvailability
    {
        public bool IsCommandAvailable(UIApplication a, CategorySet selectedCategories)
        {
            if (a.ActiveUIDocument == null) { return false; }

            if (a.ActiveUIDocument.Document
                .ActiveView.ViewType == ViewType.ThreeD)
            { return true; }

            else if (a.ActiveUIDocument.Document
           .ActiveView.ViewType == ViewType.Section)
            { return true; }

            else if (a.ActiveUIDocument.Document
            .ActiveView.ViewType == ViewType.FloorPlan)
            { return true; }

            else if (a.ActiveUIDocument.Document
            .ActiveView.ViewType == ViewType.EngineeringPlan)
            { return true; }

            else if (a.ActiveUIDocument.Document
            .ActiveView.ViewType == ViewType.Detail)
            { return true; }

            else if (a.ActiveUIDocument.Document
           .ActiveView.ViewType == ViewType.EngineeringPlan)
            { return true; }

            else
            { return false; }
        }
    }
}
