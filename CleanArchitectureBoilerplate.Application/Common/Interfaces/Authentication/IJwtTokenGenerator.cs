using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitectureBoilerplate.Domain.Entities;

namespace CleanArchitectureBoilerplate.Application.Common.Interfaces.Authentication
{
public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
}