using Exporty.Extensions;
using Exporty.Models;
using Exporty.Sample.Models;


namespace Exporty.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            var outputDirectory = Directory.GetCurrentDirectory();
            var user = new List<User>()
            {
                new User() {FirstName = "User1", LastName = "LastName1"},
                new User() {FirstName = "User2", LastName = "LastName2"}
            };

            var exporty = new Concrete.Exporty();

            var excelExportedFile = exporty.Export(ExportType.Excel, user.ToDataTable(), $"{outputDirectory}\\exportedFiles");
            var csvExportedFile = exporty.Export(ExportType.Csv, user.ToDataTable(), $"{outputDirectory}\\exportedFiles");
            var pdfExportedFile = exporty.Export(ExportType.Pdf, user.ToDataTable(), $"{outputDirectory}\\exportedFiles", $"Pdf_{Guid.NewGuid().ToString()}");

            Console.WriteLine($"Excel Exported file path: {excelExportedFile}");
            Console.WriteLine($"CSV Exported file path: {csvExportedFile}");
            Console.WriteLine($"PDF Exported file path: {pdfExportedFile}");
        }
    }
}

