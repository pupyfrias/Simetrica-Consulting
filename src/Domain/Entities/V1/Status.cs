﻿using SimetricaConsulting.Domain.Common;

namespace SimetricaConsulting.Domain.Entities.V1
{
    public class Status : EntityBase<int>
    {
        public override int Id { get; set; }
        public string Name { get; set; }
    }

}