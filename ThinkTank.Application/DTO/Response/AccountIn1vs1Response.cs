﻿


using ThinkTank.Domain.Commons;

namespace ThinkTank.Application.DTO.Response
{
    public class AccountIn1vs1Response
    {
        public int Id { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? Coin { get; set; }
        public int? WinnerId { get; set; }
        public int? AccountId1 { get; set; }
        public int? AccountId2 { get; set; }
        [IntAttribute]
        public int? GameId { get; set; }
        public string? GameName { get; set; }
        public string? RoomOfAccountIn1vs1Id { get; set; }
        public string? Username1 { get; set; }
        public string? Username2 { get; set; }
    }
}
