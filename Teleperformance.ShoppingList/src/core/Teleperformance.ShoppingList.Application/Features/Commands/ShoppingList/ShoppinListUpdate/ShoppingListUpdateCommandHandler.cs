﻿using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teleperformance.Bootcamp.Application.Interfaces.Repositories;
using Teleperformance.Bootcamp.Domain.Common.Response;

namespace Teleperformance.Bootcamp.Application.Features.Commands.ShoppingList.ShoppinListUpdate
{
    public class ShoppingListUpdateCommandHandler : IRequestHandler<ShoppingListUpdateCommandRequest, BaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IShoppingListRepository _shoppingListRepsitory;
        private readonly ICategoryRepository _categoryRepository;
        public ShoppingListUpdateCommandHandler(IShoppingListRepository shoppingListRepsitory, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _shoppingListRepsitory = shoppingListRepsitory;
            _categoryRepository = categoryRepository;
        }

        public async Task<BaseResponse> Handle(ShoppingListUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var entity = await _shoppingListRepsitory.GetByIdAsync(request.UpdateShoppingListDto.Id);

            entity = _mapper.Map(request.UpdateShoppingListDto, entity);

            var category = await _categoryRepository.GetByIdAsync(request.UpdateShoppingListDto.CategoryId);

            entity.Category = category;



            if (entity != null)
            {
                _shoppingListRepsitory.Update(entity);
                return new BaseResponse("Liste başarıyla eklendi", true);
            }
            else
                return new BaseResponse("Liste ekleme başarısız", false);        
           
        }
    }
}
