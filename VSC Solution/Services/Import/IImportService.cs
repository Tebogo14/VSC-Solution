using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSC_Solution.Services.Import
{
    public interface IImportService
    {
        public string ImportData(string filePath);
    }
}
