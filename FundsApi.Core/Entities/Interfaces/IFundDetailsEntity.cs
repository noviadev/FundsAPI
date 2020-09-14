namespace FundsApi.Core.Entities.Interfaces
{
    public interface IFundDetailsEntity
    {
        string Code { get; set; }
        bool Active { get; set; }
        string FundManager { get; set; }
        string Name { get; set; }
        decimal CurrentUnitPrice { get; set; }
    }
}