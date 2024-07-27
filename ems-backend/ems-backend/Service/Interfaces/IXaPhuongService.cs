﻿using ems_backend.Models.RequestModel.QuanHuyenRequest;
using ems_backend.Models.RequestModel.XaPhuongRequest;
using ems_backend.Models.ResponseModels.DataQuanHuyen;
using ems_backend.Models.ResponseModels.DataXaPhuong;

namespace ems_backend.Service.Interfaces
{
    public interface IXaPhuongService
    {
        Task<IEnumerable<DataResponseXaPhuong>> LayTatCaXaPhuong();
        Task<DataResponseXaPhuong> LayXaPhuongTheoId(int id);
        Task<DataResponseXaPhuong> ThemXaPhuong(Request_ThemXaPhuong request);
        Task<DataResponseXaPhuong> SuaXaPhuong(int id, Request_SuaXaPhuong request);
        Task<bool> XoaXaPhuong(int id);
    }
}
