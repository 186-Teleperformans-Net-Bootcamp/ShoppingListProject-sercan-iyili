﻿namespace Teleperformance.Bootcamp.Application.DTOs.User
{
    public class UserCreateDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
