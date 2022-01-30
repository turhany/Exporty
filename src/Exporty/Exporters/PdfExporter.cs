using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;
using System.IO;

namespace Exporty.Exporters
{
    internal class PdfExporter
    {
        public void Export(DataTable dataTable, string fullFilePath)
        {
              var document = new Document();
                document.SetPageSize(PageSize.A4.Rotate());

                PdfWriter.GetInstance(document, new FileStream(fullFilePath, FileMode.Create));

                document.Open();

                var table = new PdfPTable(dataTable.Columns.Count);

                for (var i = 0; i < dataTable.Columns.Count; i++)
                {
                    var cellText = dataTable.Columns[i].ColumnName;

                    var cell = new PdfPCell
                    {
                        Phrase = new Phrase(cellText, new Font(Font.HELVETICA, 9, 0)),
                        VerticalAlignment = Element.ALIGN_MIDDLE,
                        BorderColorBottom = new BaseColor(61, 61, 61),
                        BorderWidthLeft = 0f,
                        BorderWidthRight = 0f,
                        BorderWidthTop = 0f,
                        BorderWidthBottom = 0.3f
                    };

                    table.AddCell(cell);
                }

                var helveticaTurkishFont = BaseFont.CreateFont("Helvetica", "CP1254", BaseFont.NOT_EMBEDDED);
                var helveticaTurkishFontStyled = new iTextSharp.text.Font(helveticaTurkishFont, 9, Font.NORMAL);

                for (var i = 0; i < dataTable.Rows.Count; i++)
                    for (var j = 0; j < dataTable.Columns.Count; j++)
                    {
                        var cellText = dataTable.Rows[i][j].ToString();

                        var rowColor = i % 2 == 0
                            ? new BaseColor(255, 255, 255)
                            : new BaseColor(250, 250, 250);

                        var cell = new PdfPCell
                        {
                            Phrase = new Phrase(cellText, helveticaTurkishFontStyled),
                            VerticalAlignment = Element.ALIGN_MIDDLE,
                            BackgroundColor = rowColor,
                            BorderColorBottom = new BaseColor(179, 212, 252),
                            BorderWidthLeft = 0f,
                            BorderWidthRight = 0f,
                            BorderWidthTop = 0f,
                            BorderWidthBottom = 0.5f
                        };
                        table.AddCell(cell);
                    }

                document.Add(table);
                document.Close();
        }
    }
}