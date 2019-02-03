using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ExperimentsApp.Service.Extensions
{
    public static class UserExtensions
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            var stringId = user.Identity.Name;
            var id = -1;
            if (!string.IsNullOrEmpty(stringId))
            {
                int.TryParse(stringId, out id);
            }

            return id;
        }
    }
}
