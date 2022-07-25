using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo2.Data;
using WebApiDemo2.Models;
using AutoMapper;

namespace WebApiDemo2.Repository
{
    public class PortRepository : IPortRepository
    {
        private readonly PortDbContext _Context;
        private readonly IMapper _mapper;

        public PortRepository(PortDbContext Context,IMapper mapper)
        {
            this._Context = Context;
            this._mapper = mapper;
        }

        //public async Task<List<Portuser>> GetAllPortusersAsync()
        //{
        //    var record = await _Context.Portusers.Select(x => new Portuser()

        //    {
        //        Id = x.Id,
        //        Name = x.Name,
        //        Email = x.Email,
        //        Phone = x.Phone,
        //        Cost = x.Cost,
        //        Startdate = x.Startdate,
        //        Endtime = x.Endtime,
        //        Usertype = x.Usertype,

        //    }).ToListAsync();
        //    return record;
        //}

        

        //public async Task<Portuser> GetPortusersByIdAsync(int PortId)
        //{
        //    var record = await _Context.Portusers.Where(x => x.Id == PortId).Select(x => new Portuser()
        //    {
        //        Id = x.Id,
        //        Name = x.Name,
        //        Email = x.Email,
        //        Phone = x.Phone,
        //        Cost = x.Cost,
        //        Startdate = x.Startdate,
        //        Endtime = x.Endtime,
        //        Usertype = x.Usertype,

        //    }).FirstOrDefaultAsync();
        //    return record;
        //}

        //public async Task<int> AddPortusersAsync(Portuser PortuserModel)
        //{
        //    var Port = new Portuser()
        //    {

        //        Name = PortuserModel.Name,
        //        Email = PortuserModel.Email,
        //        Phone = PortuserModel.Phone,
        //        Cost = PortuserModel.Cost,
        //        Startdate = PortuserModel.Startdate,
        //        Endtime = PortuserModel.Endtime,
        //        Usertype = PortuserModel.Usertype,

        //    };
        //    _Context.Portusers.Add(Port);
        //    await _Context.SaveChangesAsync();
        //    return Port.Id;
        //}

        public async Task<Portuser> AddPortusersAsync(Portuser usersModel)
        {
            if (usersModel.Usertype == "SL")
            {
                var user = new Portuser()
                {
                    Name = usersModel.Name,
                    Email = usersModel.Email,
                    Phone = usersModel.Phone,
                    Usertype = usersModel.Usertype,
                    Startdate = usersModel.Startdate,
                    Endtime = usersModel.Endtime,
                    Cost = usersModel.Cost,
                    Id = usersModel.Id,
                };
                _Context.Portusers.Add(user);
                await _Context.SaveChangesAsync();
                var slot = new Portslot()
                {
                    Status = "Y",
                    SluserId = user.Id,
                    Ruid = 0
                };
                _Context.Portslots.Add(slot);
                await _Context.SaveChangesAsync();
                return _mapper.Map<Portuser>(user);
            }

            else
            {
                var user = new Portuser()
                {
                    Id = usersModel.Id,
                    Name = usersModel.Name,
                    Email = usersModel.Email,
                    Phone = usersModel.Phone,
                    Usertype = usersModel.Usertype,
                };
                _Context.Portusers.Add(user);
                await _Context.SaveChangesAsync();
                return _mapper.Map<Portuser>(user);
            };

        }

        //public async Task UpdatePortusersAsync(int PortId, Portuser PortuserClass)
        //{
        //    var Port = await _Context.Portusers.FindAsync(PortId);
        //    if (Port != null)
        //    {
        //        Port.Id = PortuserClass.Id;
        //        Port.Name = PortuserClass.Name;
        //        Port.Email = PortuserClass.Email;
        //        Port.Phone = PortuserClass.Phone;
        //        Port.Cost = PortuserClass.Cost;
        //        Port.Startdate = PortuserClass.Startdate;
        //        Port.Endtime = PortuserClass.Endtime;
        //        Port.Usertype = PortuserClass.Usertype;
        //        await _Context.SaveChangesAsync();
        //    }
        //}
        //public async Task DeletePortusersAsync(int PortId)
        //{
        //    var Port = new Portuser()
        //    {
        //        Id = PortId
        //    };
        //    if (Port != null)
        //    {
        //        _Context.Portusers.Remove(Port);
        //        await _Context.SaveChangesAsync();
        //    }
        //}

        public async Task<List<Portslot>> GetAvalSlotsAsync()
        {
            var records = await _Context.Portslots.Where(x => x.Status == "Y").Select(x => new Portslot()
            {
                SlotId = x.SlotId,
                SluserId=x.SluserId,
                Status = x.Status


            }).ToListAsync();
            return records;
        }

        public async Task UpdateSlot(int slotId, Portslot slotsModel)
        {
            var slot = await _Context.Portslots.FindAsync(slotId);
            if (slot != null)
            {
                slot.Ruid = slotsModel.Ruid;
                slot.Status = "N";
                slot.Cost = slot.Cost + slotsModel.Cost;
                slot.Startdate = slotsModel.Startdate;
                slot.Enddate = slotsModel.Enddate;
                await _Context.SaveChangesAsync();
            }
        }

    }
}
