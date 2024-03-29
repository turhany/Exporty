![alt tag](/img/exporty.png)  

Simple excel, csv, pdf data table export library.

[![NuGet version](https://badge.fury.io/nu/Exporty.svg)](https://badge.fury.io/nu/Exporty)  ![Nuget](https://img.shields.io/nuget/dt/Exporty)

#### Features:
- Excel export
- CSV export
- Pdf export

#### Usages:

DI Registration:

```cs
  public void ConfigureServices(IServiceCollection services)
  {
      services.AddScoped<IExporty, Concrete.Exporty>();
  }
```

Sample Code

```cs
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

public class User
{
    [Export(ColumnName = "First Name")]
    public string FirstName { get; set; }
    [Export(ColumnName = "Last Name")]
    public string LastName { get; set; }
}
```

![alt tag](/img/sample.jpg)  

### Release Notes

#### 1.0.4
* ClosedXML version updated to 0.102.0
* iTextSharp.LGPLv2.Core version updated to 3.4.3

#### 1.0.3
* CsvHelper version updated to 30.0.1
* iTextSharp.LGPLv2.Core version updated to 2.0.0

#### 1.0.2
* ClosedXML version updated to 0.97.0
* CsvHelper version updated to 30.0.0
* iTextSharp.LGPLv2.Core version updated to 1.8.0

#### 1.0.1
* ClosedXML version updated to 0.96.0
* CsvHelper version updated to 28.0.1
* iTextSharp.LGPLv2.Core version updated to 1.9.2

#### 1.0.0
* Base Release
