﻿using MyInvest.Domain.Entities;
using MyInvest.Domain.Interfaces.Services;

namespace MyInvest.Application
{
    public class TipoInstituicaoFinanceiraAppService : AppServiceBase<TipoInstituicaoFinanceira>
    {
        public TipoInstituicaoFinanceiraAppService(IServiceBase<TipoInstituicaoFinanceira> serviceBase) 
            : base(serviceBase)
        {
        }
    }
}
