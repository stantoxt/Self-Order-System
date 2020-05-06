﻿using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstantPOS.Application.CQRS.ProductType.Command;
using InstantPOS.Application.Interfaces.DatabaseServices;
using MediatR;

namespace InstantPOS.Application.CQRS.ProductType.CommandHandler
{
    public class UpdateProductTypeCommandHandler : BaseProductTypeHandler,IRequestHandler<UpdateProductTypeCommand, bool>
    {
        private readonly IMapper _mapper;
        public UpdateProductTypeCommandHandler(IProductTypeDataService productTypeDataService, IMapper mapper) : base(productTypeDataService)
        {
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateProductTypeCommand updateProductTypeCommandRequest, CancellationToken cancellationToken)
        {
            var request = _mapper.Map<UpdateProductTypeCommand,
                InstantPOS.Domain.Entities.ProductType>(updateProductTypeCommandRequest);
            var result = await base._productTypeDataService.UpdateProductType(request);
            return result;
        }
    }
}
