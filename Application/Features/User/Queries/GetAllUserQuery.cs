using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umb.Application.Features.User.Dtos;
using Umb.Application.Services.User;

namespace Umb.Application.Features.User.Queries
{
    public class GetAllUserQuery : IRequest<List<Umb.Domain.User>>
    {
        public class GetAllTenantQueryHandler : IRequestHandler<GetAllUserQuery, List<Umb.Domain.User>>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            public GetAllTenantQueryHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }
            public async Task<List<Umb.Domain.User>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
            {
                List<Umb.Domain.User> users = await _userRepository.GetAll();

                //List<GetUserDto> mappedTenants = _mapper.Map<List<Umb.Domain.User>, List<GetUserDto>>(users);


                return users;
            }

        }
    }
}
