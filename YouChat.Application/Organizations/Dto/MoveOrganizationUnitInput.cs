using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace YouChat.Organizations.Dto
{
    public class MoveOrganizationUnitInput : IInputDto
    {
        [Range(1, long.MaxValue)]
        public long Id { get; set; }

        public long? NewParentId { get; set; }
    }
}