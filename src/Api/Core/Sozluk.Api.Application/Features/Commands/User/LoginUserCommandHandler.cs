using AutoMapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using Sozluk.Api.Application.Interfaces.Repositories;
using Sozluk.Common.Infrastructure;
using Sozluk.Common.Infrastructure.Exceptions;
using Sozluk.Common.ViewModels.Queries;
using Sozluk.Common.ViewModels.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sozluk.Api.Application.Features.Commands.User;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand,LoginUserViewModel>
{
    private readonly IUserRepository userRepository;

    private readonly IMapper mapper;

    private readonly IConfiguration configration;

    public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, IConfiguration configration)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
        this.configration = configration;
    }

    public async Task<LoginUserViewModel> Handle(LoginUserCommand request, CancellationToken cancellation)
    {

        var dbUser = await userRepository.GetSingleAsync(i => i.EmailAddress == request.EmailAdress);
        if (dbUser == null)
            throw new DatabaseValidationException("User not found.!");

        var pass= PasswordEncrytor.Encrypt(request.Password);

        if(dbUser.Password != pass)
            throw new DatabaseValidationException("Password is wrong.!");

        if (!dbUser.EmailConfirmed)
            throw new DatabaseValidationException("Email adress is not confirmed.!");

        var result = mapper.Map<LoginUserViewModel>(dbUser);
    }
}
