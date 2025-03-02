﻿
using System.ComponentModel.DataAnnotations;
using ThinkTank.Domain.Commons;

namespace ThinkTank.Application.DTO.Response
{
    public class ContestResponse
    {
        [Key]
        public int Id { get; set; }
        [StringAttribute]
        public string? Name { get; set; }
        public string? Thumbnail { get; set; }
        [DateRangeAttribute]
        public DateTime? StartTime { get; set; }
        [DateRangeAttribute]
        public DateTime? EndTime { get; set; }
        public bool? Status { get; set; }
        [IntAttribute]
        public int? GameId { get; set; }
        public decimal? PlayTime { get; set; }
        public string?  GameName { get; set; }
        public int? AmoutPlayer { get; set; }
        public int? CoinBetting { get; set; }
        public virtual ICollection<AssetOfContestResponse> AssetOfContests { get; set; }

    }
}
