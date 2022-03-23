using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MudBlazor;

namespace BlazoredAirlinesDemo.Components
{
    public interface IPaginatedHttpClient<TEntity>
    {
        public Task<TableData<TEntity>> Paginate(TableState state);

    }
}