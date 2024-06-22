using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppCore.GlobalSetting.Commands.Command;
using AppCore.HandleResponse;
using AppCore.Interfaces;
using AutoMapper;
using MediatR;

namespace AppCore.GlobalSetting.Commands.Handler
{
    public class SettingCommandHandler(IGlobalSetting globalSetting, IMapper mapper) :
    IRequestHandler<UpdateSettingCommand, ResponseResult<object>>
    {
        private readonly IGlobalSetting _globalSetting = globalSetting;
        private readonly IMapper _mapper = mapper;

        public Task<ResponseResult<object>> Handle(UpdateSettingCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        // public Task<ResponseResult<object>> Handle(UpdateSettingCommand request, CancellationToken cancellationToken)
        // {
        //     if(!)
        // }
    }
}