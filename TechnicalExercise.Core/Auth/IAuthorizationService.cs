using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalExercise.Core.AuthModel;

namespace TechnicalExercise.Core.Auth
{
    public interface IAuthorizationService
    {
        Task<dynamic> Login(LoginModel model);

        Task Register([FromBody] RegisterModel model);

        Task RegisterAdmin([FromBody] RegisterModel model);
    }
}
