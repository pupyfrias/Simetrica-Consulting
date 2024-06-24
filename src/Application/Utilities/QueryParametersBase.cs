using SimetricaConsulting.Application.Contracts;

namespace SimetricaConsulting.Application.Utilities
{
    public abstract class QueryParametersBase : IQueryParametersBase
    {
        public string? SortBy { get; set; }
        public bool Descending { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; } = 30;
    }
}