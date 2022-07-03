﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.DTOs.ShoppingList;
using Teleperformance.Bootcamp.Application.Features.Commands.User.UserCreate;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;
using Teleperformance.Bootcamp.Domain.Common.Response;

namespace Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppingListCreate
{
    public class ShoppingListCreateCommandHandler : IRequestHandler<ShoppingListCreateCommandRequest, BaseResponse>
    {

        private readonly IMapper _mapper;
        private readonly IShoppingListRepository _shoppingListRepsitory;
        public ShoppingListCreateCommandHandler(IShoppingListRepository shoppingListRepsitory, IMapper mapper)
        {
            _shoppingListRepsitory = shoppingListRepsitory;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(ShoppingListCreateCommandRequest request, CancellationToken cancellationToken)
        {

            var result =  _mapper.Map<Teleperformance.Bootcamp.Domain.Entities.ShoppingList>(request.CreateShoppingListDto);
            
            if (result != null)
            {
                await _shoppingListRepsitory.AddAsync(result);
                return new BaseResponse("Liste başarıyla eklendi", true);
            }
            else
                return new BaseResponse("Liste ekleme başarısız", false);

        }
    }
}
