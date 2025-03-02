﻿
namespace ThinkTank.Application.DTO.Response
{
    public class FriendResponse
    {
        public int Id { get; set; }
        public bool? Status { get; set; }
        public int? AccountId1 { get; set; }
        public int AccountId2 { get; set; }
        public string UserName1 { get; set; }
        public string Avatar1 { get; set; }
        public string UserName2 { get; set; }
        public string Avatar2 { get; set; }
        public string UserCode1 { get; set; }
        public string UserCode2 { get; set; }
    }
}
