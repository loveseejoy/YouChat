﻿using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using YouChat.Authorization.Users;
using YouChat.MultiTenancy;

namespace YouChat.Web.Models.TenantRegistration
{
    public class TenantRegistrationViewModel : IInputDto
    {
        [Required]
        [StringLength(Tenant.MaxTenancyNameLength)]
        public string TenancyName { get; set; }

        [Required]
        [StringLength(User.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(User.MaxEmailAddressLength)]
        public string AdminEmailAddress { get; set; }

        [StringLength(User.MaxPlainPasswordLength)]
        public string AdminPassword { get; set; }
    }
}