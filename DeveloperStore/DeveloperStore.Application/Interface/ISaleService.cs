﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperStore.Domain.Entity;
using DeveloperStore.Domain.Interface;

namespace DeveloperStore.Application.Interface
{
    public interface ISaleService : IDisposable
    {
        Task<IContractResult> Delete(int id);
        Task<IContractResult> Delete(Guid id);
        Task<IContractResult> Insert(Sale model);
        Task<IContractResult> Update(Sale model);
        IContractResult ListAll();
        Task<IContractResult> GetById(int id);
        Task<IContractResult> GetById(Guid id);
    }
}
