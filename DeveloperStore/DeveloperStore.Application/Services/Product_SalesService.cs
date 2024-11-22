using System;
using System.Collections.Generic;
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
    public class Product_SalesService : IProduct_SalesService
    {
        private readonly IProduct_SalesRepository _repo;
        public Product_SalesService(IProduct_SalesRepository repo)
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


        public async Task<IContractResult> Insert(Product_Sale model)
        {
            var result = new ContractResult();
            try
            {
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

        public async Task<IContractResult> Update(Product_Sale model)
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
