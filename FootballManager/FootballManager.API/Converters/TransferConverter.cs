using FootballManager.API.DTOs;
using FootballManager.API.Models;

namespace FootballManager.API.Converters
{
    public static class TransferConverter
    {
        public static Transfer ToDatabaseModel(this TransferDto transferDto)
        {
            return new Transfer
            {
                PlayerId = transferDto.PlayerId,
                SourceTeamId = transferDto.SourceTeamId,
                TargetTeamId = transferDto.TargetTeamId,
            };
        }
        public static TransferDto ToDto(this Transfer transfer)
        {
            return new TransferDto
            {
                Id = transfer.Id,
                PlayerId = transfer.PlayerId,
                SourceTeamId = transfer.SourceTeamId,
                TargetTeamId = transfer.TargetTeamId,
            };
        }
    }
}
