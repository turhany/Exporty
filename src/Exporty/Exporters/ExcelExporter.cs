using System.Data;
using ClosedXML.Excel;

namespace Exporty.Exporters
{
    internal class ExcelExporter
    {
        public void Export(DataTable dataTable, string fullFilePath)
        {
            var workbook = new XLWorkbook();

            var worksheet = workbook.Worksheets.Add(dataTable, "Sheet1");

            worksheet.Table(0).ShowAutoFilter = false;

            worksheet
                .RangeUsed()
                .AddConditionalFormat()
                .WhenIsTrue("EVEN(ROW())=ROW()")
                .Fill
                .SetBackgroundColor(XLColor.White);

            worksheet
                .RangeUsed()
                .AddConditionalFormat()
                .WhenIsTrue("ODD(ROW())=ROW()")
                .Fill
                .SetBackgroundColor(XLColor.FromArgb(250, 250, 250));

            worksheet
                .Row(1)
                .Style
                .Font
                .SetFontColor(XLColor.SmokyBlack);

            workbook.SaveAs(fullFilePath);
        }
    }
}