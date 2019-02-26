using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskDropper.Core.Models;

namespace TaskDropper.Core.Interface
{
    public interface ITaskWebApiService
    {
        Task RefreshDataAsync(string email);

        Task SaveItemTaskAsync(ItemTask item, bool isNewItem);

        Task DeleteItemTaskAsync(string id);

    }
}
