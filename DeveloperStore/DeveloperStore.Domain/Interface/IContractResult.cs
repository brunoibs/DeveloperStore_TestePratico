using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperStore.Domain.Interface
{
    public interface IContractResult
    {
        bool Valid { get; set; }
        string Message { get; set; }
        object Data { get; set; }
        Exception Exception { get; set; }
    }
}
