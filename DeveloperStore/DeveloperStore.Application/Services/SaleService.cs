using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperStore.Application.Interface;
using DeveloperStore.Data.Interface;
using DeveloperStore.Domain.Entity;
using DeveloperStore.Domain.Interface;
using DeveloperStore.Domain.ObjectValue;
using DeveloperStore.Infra;

namespace DeveloperStore.Application.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _repo;
        public SaleService(ISaleRepository repo)
        {
            _repo = repo;
        }

        #region Dispose
        private bool disposedValue = false; // Para detectar chamadas redundantes
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: descartar estado gerenciado (objetos gerenciados).
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion

        internal IContractResult ValidateSale(Sale sale)
        {
            var errors = new StringBuilder();
            var erro = string.Empty;
            var result = new ContractResult();
            if (sale.Dt_Sale > DateTime.UtcNow)
                errors.AppendLine ("The sale date cannot be in the future.");

            if (sale.Total <= 0)
                errors.AppendLine("The total amount must be greater than zero.");

            if (!sale.Product_Sales.Any())
                errors.AppendLine("At least one product must be included in the sale.");

            if (sale.Product_Sales.Any(p => p.Amount <= 0))
                errors.AppendLine("All products must have a quantity greater than zero.");

            if (sale.Product_Sales.Any(p => p.Price <= 0))
                errors.AppendLine("All products must have a price greater than zero.");
            erro = errors.ToString();

            if (string.IsNullOrEmpty(erro))
            {
                result = result.Valido();
            }
            else
            {
                result = result.InValido();
                result.Message = erro;
            }
            return result;
        }

        public async Task<IContractResult> Delete(int id)
        {
            var result = new ContractResult();
            try
            {
                var model = _repo.GetById(id);
                if (model == null)
                {
                    result.Valid = false;
                    result.Message = "Objeto não localizado.";
                }
                else
                {
                    result.Valid = _repo.Delete(id);
                    result.Message = "Excluido com Sucesso.";
                    result.Data = model;
                }
            }
            catch (Exception ex)
            {
                result.Valid = false;
                result.Message = ex.Message;
                LogSentry.EnviarExceptionSentry(ex);
            }

            return result;
        }

        public async Task<IContractResult> Delete(Guid id)
        {
            var result = new ContractResult();
            try
            {
                var model = _repo.GetById(id);
                if (model == null)
                {
                    result.Valid = false;
                    result.Message = "Objeto não localizado.";
                }
                else
                {
                    result.Valid = _repo.Delete(id);
                    result.Message = "Excluido com Sucesso.";
                    result.Data = model;
                }
            }
            catch (Exception ex)
            {
                result.Valid = false;
                result.Message = ex.Message;
                LogSentry.EnviarExceptionSentry(ex);
            }

            return result;
        }

        public async Task<IContractResult> GetById(int id)
        {
            var result = new ContractResult();
            try
            {
                var obj = _repo.GetById(id);
                if (obj == null)
                {
                    result.Valid = false;
                    result.Message = "Objeto não localizado.";
                }
                else
                {
                    result.Valid = true;
                    result.Message = "Sucesso.";
                    result.Data = obj;
                }
            }
            catch (Exception ex)
            {
                result.Valid = false;
                result.Message = ex.Message;
                LogSentry.EnviarExceptionSentry(ex);
            }

            return result;
        }

        public async Task<IContractResult> GetById(Guid id)
        {
            var result = new ContractResult();
            try
            {
                var obj = _repo.GetById(id);
                if (obj == null)
                {
                    result.Valid = false;
                    result.Message = "Objeto não localizado.";
                }
                else
                {
                    result.Valid = true;
                    result.Message = "Sucesso.";
                    result.Data = obj;
                }
            }
            catch (Exception ex)
            {
                result.Valid = false;
                result.Message = ex.Message;
                LogSentry.EnviarExceptionSentry(ex);
            }

            return result;
        }


        public async Task<IContractResult> Insert(Sale model)
        {
            var result = new ContractResult();
            try
            {
                result = (ContractResult)ValidateSale(model);
                if (!result.Valid)
                    return result;

                result.Valid = _repo.Add(model);
                result.Message = "Salvo com Sucesso.";
                result.Data = model;
            }
            catch (Exception ex)
            {
                result.Valid = false;
                result.Message = ex.Message;
                LogSentry.EnviarExceptionSentry(ex);
            }

            return result;
        }


        public async Task<IContractResult> ListAll()
        {
            var result = new ContractResult();
            try
            {
                var list = _repo.ListAll();
                result.Valid = true;
                result.Message = "Sucesso.";
                result.Data = list;
            }
            catch (Exception ex)
            {
                result.Valid = false;
                result.Message = ex.Message;
                LogSentry.EnviarExceptionSentry(ex);
            }

            return result;
        }

        public async Task<IContractResult> Update(Sale model)
        {
            var result = new ContractResult();
            try
            {
                result.Valid = _repo.Update(model);
                result.Message = "Atualizado com Sucesso.";
                result.Data = model;
            }
            catch (Exception ex)
            {
                result.Valid = false;
                result.Message = ex.Message;
                LogSentry.EnviarExceptionSentry(ex);
            }

            return result;
        }

    }
}
