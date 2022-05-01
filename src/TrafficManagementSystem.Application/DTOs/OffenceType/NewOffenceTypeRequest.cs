﻿namespace TrafficManagementSystem.Application.DTOs.OffenceType
{
    public class NewOffenceTypeRequest
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
        public Int16 Point { get; set; }
        public string? Category { get; set; }
        public decimal FineAmount { get; set; }

    }
}
