using KASHOP.DAL.DTO.Request;
using KASHOP.DAL.DTO.Response;
using Microsoft.AspNetCore.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginRequest = KASHOP.DAL.DTO.Request.LoginRequest;
using RegisterRequest = KASHOP.DAL.DTO.Request.RegisterRequest;
using ResetPasswordRequest = KASHOP.DAL.DTO.Request.ResetPasswordRequest;

namespace KASHOP.BLL.Service
{
    public interface IAuthenticationService
    {
        Task<RegisterResponse> RegisterAsync(RegisterRequest request);
        Task<LoginResponse> LoginAsync(LoginRequest request);
        Task<bool> ConfirmEmailAsync(string token, string userId);
        Task<ForgetPasswordResponse> RequestPasswordResetAsync(ForgetPasswordRequest request);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPasswordRequest request);

    }
}
