using Exporty.Models;

namespace Exporty.Sample.Models;

public class User
{
    [Export(ColumnName = "First Name")]
    public string FirstName { get; set; }
    [Export(ColumnName = "Last Name")]
    public string LastName { get; set; }
}