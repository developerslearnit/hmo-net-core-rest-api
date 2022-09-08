using System;

namespace AvonHMO.Application.ViewModels.Avon.Authentication;

public class UserRoleViewModel
{
    public Guid roleId { get; set; }
    public string roleName { get; set; }

    public string username { get; set; }
}