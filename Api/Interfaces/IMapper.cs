using Api.DataFiles;
using System.Collections.Generic;

namespace Api.Interfaces
{
    public interface IMapper
    {
        List<FundDetails> MapFunds(List<FundDetailsDTO> fundsDTO);
    }
}