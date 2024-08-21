import { getHopDongById, updateHopDong } from '@/services/HopDongService';
import { listHoSoLuong } from '@/services/HoSoLuongService';
import { listLoaiHopDong } from '@/services/LoaiHopDongService';
import { listNhanVien } from '@/services/NhanVienService';
import { listQuyetDinh } from '@/services/QuyetDinhService';
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom';

const SuaHopDongComponent = () => {
    const { id } = useParams();
    const navigate = useNavigate();
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
    const [loaiHopDongs, setLoaiHopDongs] = useState([]);
    const [quyetDinhs, setQuyetDinhs] = useState([]);
    useEffect(() => {
        getHopDongById(id).then(response => {
            setHopDong(response.data);
        }).catch(error => {
            console.error(error);
        });

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
    }, [id]);

    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        setHopDong({
            ...hopDong,
            [name]: type === 'checkbox' ? checked : value
        });
    }

    const handleSubmit = (e) => {
        e.preventDefault();
    
        const updatedHopDong = {
            ...hopDong
        };
    
        updateHopDong(id, updatedHopDong).then(() => {
            navigate('/hop-dong');
        }).catch(error => {
            console.error("Error updating HopDong:", error.response ? error.response.data : error.message);
        });
    }

    const ConvertDate = (stringDate) => {
        const dateObject = new Date(stringDate);
        const day = String(dateObject.getDate()).padStart(2, '0'); 
        const month = String(dateObject.getMonth() + 1).padStart(2, '0');
        const year = dateObject.getFullYear();
        return `${year}-${month}-${day}`;
    };

    return (
        <div className="container mx-auto mt-5">
            <div className="card p-4 mt-4 mb-3 w-1/2 mx-auto shadow-lg rounded-lg">
                <h2 className="text-2xl font-bold text-center mb-4">Sửa quyết định</h2>
                <form onSubmit={handleSubmit}>
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
                        disabled
                    >
                        <option value="">Chọn quyết định</option>
                        {quyetDinhs.map(qd => (
                            <option key={qd.id} value={qd.id}>{qd.tenNhanVienKemChucDanh}</option>
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
                        value={ConvertDate(hopDong.ngayBatDau)} 
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
                        value={ConvertDate(hopDong.ngayKetThuc)} 
                        onChange={handleChange} 
                        required 
                    />
                </div>
                    <div className="flex justify-between">
                    <button type="submit" className="btn bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">Cập nhật</button>
                    <button type="button" className="btn bg-gray-500 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" onClick={() => navigate('/hop-dong')}>Hủy</button>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default SuaHopDongComponent