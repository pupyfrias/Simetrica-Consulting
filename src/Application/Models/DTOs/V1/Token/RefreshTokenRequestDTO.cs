﻿namespace SimetricaConsulting.Application.Models.Dtos.V1.Token
{
    public class RefreshTokenRequestDto
    {
        public string AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}