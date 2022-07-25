using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiDemo2.Data;
using WebApiDemo2.Models;

namespace WebApiDemo2.Repository
{
    public interface IPortRepository
    {
        //Task<List<Portuser>> GetAllPortusersAsync();
        //Task<Models.Portuser> GetPortusersByIdAsync(int PortId);
        Task<Portuser> AddPortusersAsync(Portuser PortuserModel);
        //Task UpdatePortusersAsync(int PortId, Portuser PortuserClass);
        //Task DeletePortusersAsync(int PortId);
        Task<List<Portslot>> GetAvalSlotsAsync();
        //Task<Portslot> GetAvalSlotsByIdAsync(int AvalSlotId);

        Task UpdateSlot(int slotId, Portslot slotsModel);
    }
}
