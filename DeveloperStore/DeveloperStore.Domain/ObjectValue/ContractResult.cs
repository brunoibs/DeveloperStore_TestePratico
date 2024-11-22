using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperStore.Domain.Interface;

namespace DeveloperStore.Domain.ObjectValue
{
    public class ContractResult : IContractResult
    {
        public bool Valid { get; set; } = false;
        public string Message { get; set; }
        public object Data { get; set; }
        public Exception Exception { get; set; }

        public ContractResult Valido()
        {
            var model = new ContractResult();
            model.Valid = true;
            model.Message = "Sucesso";
            return model;
        }

        public ContractResult InValido()
        {
            var model = new ContractResult();
            model.Valid = false;
            model.Message = "Erro";
            return model;
        }
    }
}
