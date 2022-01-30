using System.Data;
using Exporty.Models;

namespace Exporty.Abstract
{
    public interface IExporty
    {
        string Export(ExportType exportType, DataTable dataTable, string fileOutputDirectory, string fileName = null);
    }
}