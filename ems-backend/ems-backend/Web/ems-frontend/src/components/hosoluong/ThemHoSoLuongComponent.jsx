import { listChucDanh } from '@/services/ChucDanhService';
import { addHoSoLuong } from '@/services/HoSoLuongService';
import { listNhanVien } from '@/services/NhanVienService';
import { listPhongBan } from '@/services/PhongBanService';
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom';

const ThemHoSoLuongComponent = () => {
    const [hoSoLuong, setHoSoLuong] = useState({
        nhanVienId: '',
        phongBanId: '',
        chucDanhId: '',
        thangLuong: '',
        bacLuong: '',
        luongMin:'',
        luongMax:''
    });
    const [nhanViens, setNhanViens] = useState([]);
    const [phongBans, setPhongBans] = useState([]);
    const [chucDanhs, setChucDanhs] = useState([]);

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

        listPhongBan()
            .then(response => {
                setPhongBans(response.data.data);
            })
            .catch(error => {
                console.error('Có lỗi xảy ra khi gọi API:', error);
            });

        listChucDanh()
            .then(response => {
                setChucDanhs(response.data.data);
            })
            .catch(error => {
                console.error('Có lỗi xảy ra khi gọi API:', error);
            });
    }, []);

    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        setHoSoLuong({
            ...hoSoLuong,
            [name]: type === 'checkbox' ? checked : value
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        
        try {
            await addHoSoLuong(hoSoLuong);
            navigate('/ho-so-luong');
        } catch (error) {
            console.error("Error adding HoSoLuongs:", error.response ? error.response.data : error.message);
            setError('Có lỗi xảy ra khi thêm hồ sơ lương.');
        }
    };

    return (
        <div className="container mx-auto">
            <div className="card bg-white shadow-md p-6 mt-6 mb-6 mx-auto w-full md:w-1/2 lg:w-2/5 rounded-lg">
                <h2 className="text-2xl font-bold text-center mb-6">Thêm mới hồ sơ lương</h2>
                <form onSubmit={handleSubmit}>
                    {error && <div className="bg-red-100 text-red-700 p-4 rounded mb-4">{error}</div>}
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Thang lương</label>
                        <input 
                            type="text" 
                            className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            name="thangLuong"
                            value={hoSoLuong.thangLuong} 
                            onChange={handleChange} 
                            required 
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Bậc lương</label>
                        <input 
                            type="text" 
                            className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            name="bacLuong"
                            value={hoSoLuong.bacLuong} 
                            onChange={handleChange} 
                            required 
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Lương tối thiểu</label>
                        <input 
                            type="text" 
                            className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            name="luongMin"
                            value={hoSoLuong.luongMin} 
                            onChange={handleChange} 
                            required 
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Lương tối đa</label>
                        <input 
                            type="text" 
                            className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            name="luongMax"
                            value={hoSoLuong.luongMax} 
                            onChange={handleChange} 
                            required 
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Nhân viên</label>
                        <select 
                            className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                            name="nhanVienId"
                            value={hoSoLuong.nhanVienId}
                            onChange={handleChange} 
                            required
                        >
                            <option value="">Chọn nhân viên</option>
                            {nhanViens.map(nhanVien => (
                                <option key={nhanVien.id} value={nhanVien.id}>{nhanVien.hoTen}</option>
                            ))}
                        </select>
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Phòng ban</label>
                        <select 
                            className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                            name="phongBanId"
                            value={hoSoLuong.phongBanId}
                            onChange={handleChange} 
                            required
                        >
                            <option value="">Chọn phòng ban</option>
                            {phongBans.map(phongBan => (
                                <option key={phongBan.id} value={phongBan.id}>{phongBan.tenPhongBan}</option>
                            ))}
                        </select>
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Chức danh</label>
                        <select 
                            className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                            name="chucDanhId"
                            value={hoSoLuong.chucDanhId}
                            onChange={handleChange} 
                            required
                        >
                            <option value="">Chọn chức danh</option>
                            {chucDanhs.map(chucDanh => (
                                <option key={chucDanh.id} value={chucDanh.id}>{chucDanh.tenChucDanh}</option>
                            ))}
                        </select>
                    </div>
                    <div className="flex justify-between">
                        <button type="submit" className="btn bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline">Lưu</button>
                        <button type="button" className="btn bg-gray-500 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" onClick={() => navigate('/ho-so-luong')}>Hủy</button>
                    </div>
                </form>
            </div>
        </div>
    )
}

export default ThemHoSoLuongComponent