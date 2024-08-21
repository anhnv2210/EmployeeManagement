import { addHopDong } from '@/services/HopDongService';
import { listHoSoLuong } from '@/services/HoSoLuongService';
import { listLoaiHopDong } from '@/services/LoaiHopDongService';
import { listNhanVien } from '@/services/NhanVienService';
import { listQuyetDinh } from '@/services/QuyetDinhService';
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom';

const ThemHopDongLaoDongComponent = () => {
  const [hopDong, setHopDong] = useState({
    nhanVienId:'',
    hoSoLuongId:'',
    loaiHopDongId:'',
    quyetDinhId:'',
    chiTietHopDong: '',
    ngayBatDau: '',
    ngayKetThuc: '',
});
const [nhanViens, setNhanViens] = useState([]);
const [hoSoLuongs, setHoSoLuongs] = useState([]);
const [loaiHopDongs, setLoaiHopDongs] = useState([])
const [quyetDinhs, setQuyetDinhs] = useState([])
const [error, setError] = useState('');
const navigate = useNavigate();

useEffect(() => {
    listNhanVien()
        .then(response => {
            setNhanViens(response.data.data);
        })
        .catch(error => {
            console.error('Có lỗi xảy ra khi gọi API:', error);
        });
    listHoSoLuong()
        .then(response => {
            setHoSoLuongs(response.data.data);
        })
        .catch(error => {
            console.error('Có lỗi xảy ra khi gọi API:', error);
        });
    listLoaiHopDong()
        .then(response => {
            setLoaiHopDongs(response.data.data);
        })
        .catch(error => {
            console.error('Có lỗi xảy ra khi gọi API:', error);
        });
    listQuyetDinh()
        .then(response => {
            setQuyetDinhs(response.data.data);
        })
        .catch(error => {
            console.error('Có lỗi xảy ra khi gọi API:', error);
        });
}, []);



const handleChange = (e) => {
    const { name, value, type, checked } = e.target;
    setHopDong({
        ...hopDong,
        [name]: type === 'checkbox' ? checked : value
    });
};

const handleSubmit = async (e) => {
    e.preventDefault();
    
    try {
        addHopDong(hopDong);
        navigate('/hop-dong');
    } catch (error) {
        console.error("Error adding HopDong:", error.response ? error.response.data : error.message);
        setError('Có lỗi xảy ra khi thêm hợp đồng.');
    }
};

return (
<div className="container mx-auto" style={{ minHeight:'calc(100vh - 130px)' }}>
        <div className="card bg-white shadow-md p-6 mt-6 mb-6 mx-auto w-full md:w-1/2 lg:w-1/2 rounded-lg">
            <h2 className="text-3xl font-bold text-center mb-6">Thêm mới Hợp đồng</h2>
            <form onSubmit={handleSubmit}>
                {error && <div className="bg-red-100 text-red-700 p-4 rounded mb-4">{error}</div>}
                <div className="mb-4">
                    <label className="block text-gray-700 font-bold mb-2">Nhân viên</label>
                    <select 
                        className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                        name="nhanVienId"
                        value={hopDong.nhanVienId}
                        onChange={handleChange} 
                        required
                    >
                        <option value="">Chọn nhân viên</option>
                        {nhanViens.map(nv => (
                            <option key={nv.id} value={nv.id}>{nv.hoTen}</option>
                        ))}
                    </select>
                </div>
                <div className="mb-4">
                    <label className="block text-gray-700 font-bold mb-2">Hồ sơ lương</label>
                    <select 
                        className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                        name="hoSoLuongId"
                        value={hopDong.hoSoLuongId}
                        onChange={handleChange} 
                        required
                    >
                        <option value="">Chọn hồ sơ lương</option>
                        {hoSoLuongs.map(hsl => (
                            <option key={hsl.id} value={hsl.id}>{hsl.tenNhanVienKemChucDanh}</option>
                        ))}
                    </select>
                </div>
                <div className="mb-4">
                    <label className="block text-gray-700 font-bold mb-2">Loại hợp đồng</label>
                    <select 
                        className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                        name="loaiHopDongId"
                        value={hopDong.loaiHopDongId}
                        onChange={handleChange} 
                        required
                    >
                        <option value="">Chọn loại hợp đồng</option>
                        {loaiHopDongs.map(x => (
                            <option key={x.id} value={x.id}>{x.tenLoaiHopDong}</option>
                        ))}
                    </select>
                </div>
                <div className="mb-4">
                    <label className="block text-gray-700 font-bold mb-2">Quyết định</label>
                    <select 
                        className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                        name="quyetDinhId"
                        value={hopDong.quyetDinhId}
                        onChange={handleChange} 
                        required
                    >
                        <option value="">Chọn quyết định</option>
                        {quyetDinhs.map(x => (
                            <option key={x.id} value={x.id}>{x.tenNhanVienKemChucDanh}</option>
                        ))}
                    </select>
                </div>
                <div className="mb-4">
                    <label className="block text-gray-700 font-bold mb-2">Chi tiết hợp đồng</label>
                    <textarea 
                        className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                        name="chiTietHopDong"
                        value={hopDong.chiTietHopDong} 
                        onChange={handleChange} 
                        required 
                    />
                </div>
                <div className="mb-4">
                    <label className="block text-gray-700 font-bold mb-2">Ngày bắt đầu</label>
                    <input 
                        type="date" 
                        className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        name="ngayBatDau"
                        value={hopDong.ngayBatDau} 
                        onChange={handleChange} 
                        required 
                    />
                </div>
                <div className="mb-4">
                    <label className="block text-gray-700 font-bold mb-2">Ngày kết thúc</label>
                    <input 
                        type="date" 
                        className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        name="ngayKetThuc"
                        value={hopDong.ngayKetThuc} 
                        onChange={handleChange} 
                        required 
                    />
                </div>
                <div className="flex justify-between">
                    <button type="submit" className="btn bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline">Lưu</button>
                    <button type="button" className="btn bg-gray-500 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" onClick={() => navigate('/quyet-dinh')}>Hủy</button>
                </div>
            </form>
        </div>
    </div>
)
}

export default ThemHopDongLaoDongComponent