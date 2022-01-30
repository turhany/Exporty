using System.Data;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace Exporty.Exporters
{
    internal class CsvExporter
    {
        public void Export(DataTable dataTable, string fullFilePath)
        {
            using var textWriter = new StreamWriter(fullFilePath, false, System.Text.Encoding.Unicode);
            using var csv = new CsvWriter(textWriter, CultureInfo.CurrentCulture);

            foreach (DataColumn column in dataTable.Columns)
            {
                csv.WriteField(column.ColumnName);
            }

            csv.NextRecord();
                
            foreach (DataRow row in dataTable.Rows)
            {
                for (var i = 0; i < dataTable.Columns.Count; i++) csv.WriteField(row[i]);
                csv.NextRecord();
            }
        }
    }
}