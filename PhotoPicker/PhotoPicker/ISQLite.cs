using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoPicker
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}
