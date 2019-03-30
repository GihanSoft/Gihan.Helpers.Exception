using System.IO;

namespace Gihan.Helpers.Exception
{
    public delegate void ErrorEventHandler<in TSender>(TSender sender, ErrorEventArgs e);
}
