using System.Collections.Generic;
using Api.Models;

namespace Api.DataAccess {
    public interface IDataAccess {
        List<FundDetails> GetData();
    }
}
