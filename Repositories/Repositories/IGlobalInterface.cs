using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Repositories
{
   public interface IGlobalInterface
    {
        string convert(string table, int id);
        List<string> getAllFiles(string tableName);
        int? convertNameToId(string table, string name);
    }
}
