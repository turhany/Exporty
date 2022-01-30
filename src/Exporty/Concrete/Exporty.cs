using System;
using System.Data;
using System.IO;
using Exporty.Abstract;
using Exporty.Exporters;
using Exporty.Models;

namespace Exporty.Concrete
{
    public class Exporty : IExporty
    {
        private readonly ExcelExporter _excelExporter;
        private readonly CsvExporter _csvExporter;
        private readonly PdfExporter _pdfExporter;
        
        public Exporty()
        {
            _excelExporter = new ExcelExporter();
            _csvExporter = new CsvExporter();
            _pdfExporter = new PdfExporter();
        }
        
        public string Export(ExportType exportType, DataTable dataTable, string fileOutputDirectory, string fileName = null)
        {
            if (string.IsNullOrWhiteSpace(fileOutputDirectory))
                throw new ArgumentNullException(nameof(fileOutputDirectory));
            
            if (!Directory.Exists(fileOutputDirectory))
                Directory.CreateDirectory(fileOutputDirectory);

            if (string.IsNullOrWhiteSpace(fileName))
                fileName = Guid.NewGuid().ToString();

            string fullFilePath;
            
            switch (exportType)
            {
                case ExportType.Excel:
                    fullFilePath = Path.Combine(fileOutputDirectory, fileName + ".xlsx");
                    _excelExporter.Export(dataTable, fullFilePath);
                    break;
                case ExportType.Csv:
                    fullFilePath = Path.Combine(fileOutputDirectory, fileName + ".csv");
                    _csvExporter.Export(dataTable, fullFilePath);
                    break;
                case ExportType.Pdf:
                    fullFilePath = Path.Combine(fileOutputDirectory, fileName + ".pdf");
                    _pdfExporter.Export(dataTable, fullFilePath);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(exportType), exportType, null);
            }

            return fullFilePath;
        }
    }
}