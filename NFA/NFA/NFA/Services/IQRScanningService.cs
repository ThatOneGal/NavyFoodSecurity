using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;



namespace NFA.Services
{
    interface IQRScanningService
    {
        Task<string> ScanAsync();

    }
}
