using System;

namespace Exporty.Models
{
     public class ExportAttribute : Attribute
        {
            public string ColumnName { get; set; }
        }
}