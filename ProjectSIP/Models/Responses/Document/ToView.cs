﻿using ProjectSIP.Models.Responses.Identity;

namespace ProjectSIP.Models.Responses.Document
{
    public class ToView
    {
        public int Id { get; set; }
        public string Departure { get; set; }
        public UserView User { get; set; }
    }
}