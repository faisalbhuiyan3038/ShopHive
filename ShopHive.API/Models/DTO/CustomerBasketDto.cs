﻿using System.ComponentModel.DataAnnotations;

namespace ShopHive.API.Models.DTO
{
    public class CustomerBasketDto
    {
        [Required]
        public string Id { get; set; }
        public List<BasketItemDto> Items { get; set; }
    }
}
