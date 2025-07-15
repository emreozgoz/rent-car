using Microsoft.AspNetCore.Http;
using RentCarServer.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RentCarServer.Infrastructure.Services
{
    internal sealed class UserContex(IHttpContextAccessor httpContextAccessor) : IUserContext
    {
        public Guid GetUserId()
        {
            var httpContext = httpContextAccessor.HttpContext;
            var claims = httpContext.User.Claims;
            string? userId = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            if (userId is null)
            {
                throw new ArgumentNullException("Kullanici bilgisi bulunamadı");
            }
            try
            {
                Guid id = Guid.Parse(userId);
                return id;
            }
            catch (Exception)
            {
                throw new ArgumentException("Guid parse edilemedi");
            }
        }
    }
}
