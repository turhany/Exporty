using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using Exporty.Models;

namespace Exporty.Extensions
{
    public static class EnumerableExtensions
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            var properties = TypeDescriptor.GetProperties(typeof(T));

            var table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
            {
                if (IsPrimitiveType(prop.PropertyType))
                {
                    var exportSettingsAttribute = prop.Attributes.OfType<ExportAttribute>().FirstOrDefault();

                    string columnName;

                    if (exportSettingsAttribute != null)
                    {
                        columnName = exportSettingsAttribute.ColumnName;
                    }
                    else
                    {
                        columnName = prop.Name;
                    }

                    var propertyType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                    if (propertyType == typeof(DateTime) || propertyType == typeof(DateTime?))
                    {
                        propertyType = typeof(string);
                    }

                    table.Columns.Add(columnName, propertyType);
                }
            }

            foreach (var item in data)
            {
                var row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    if (IsPrimitiveType(prop.PropertyType))
                    {
                        var exportSettingsAttribute =
                            prop.Attributes.OfType<ExportAttribute>().FirstOrDefault();
                        object value = prop.GetValue(item) ?? DBNull.Value;

                        if ((prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?)) && value != DBNull.Value)
                        {
                            value = Convert.ToDateTime(value);
                        }

                        if (exportSettingsAttribute != null)
                        {
                            row[exportSettingsAttribute.ColumnName] = value;
                        }
                        else
                        {
                            row[prop.Name] = value;
                        }
                    }
                }

                table.Rows.Add(row);
            }

            return table;
        }

        private static bool IsPrimitiveType(Type type)
        {
            return type.IsPrimitive || type.IsValueType || (type == typeof(string));
        }
    }
}