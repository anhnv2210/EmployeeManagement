import { addNganHang, checkEmailExists, checkSoDienThoaiExists, checkTenNganHangExists } from '@/services/NganHangService';
import { listNhanVien } from '@/services/NhanVienService';
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom';

const ThemNganHangComponent = () => {
  const [nganHang, setNganHang] = useState({
    tenNganHang: '',
    diaChi:'',
    email:'',
    sdt:'',
    moTa: '',
    nguoiTaoId: '',
    nguoiCapNhatId: '',
    isActive: true,
});
const [nhanViens, setNhanViens] = useState([]);

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
}, []);

const handleChange = (e) => {
    const { name, value, type, checked } = e.target;
    setNganHang({
        ...nganHang,
        [name]: type === 'checkbox' ? checked : value
    });
};

const handleSubmit = async (e) => {
    e.preventDefault();
    
    try {
        const existTen = await checkTenNganHangExists(nganHang.tenNganHang);
        if (existTen) {
            setError('Tên ngân hàng đã tồn tại. Vui lòng chọn tên khác.');
            return;
        }
        const existEmail = await checkEmailExists(nganHang.email);
        if (existEmail) {
            setError('Email của ngân hàng đã tồn tại. Vui lòng chọn email khác.');
            return;
        }
        const existSDT = await checkSoDienThoaiExists(nganHang.sdt);
        if (existSDT) {
            setError('Số điện thoại của ngân hàng đã tồn tại. Vui lòng chọn sđt khác.');
            return;
        }
        await addNganHang(nganHang);
        navigate('/ngan-hang');
    } catch (error) {
        console.error("Error adding NganHang:", error.response ? error.response.data : error.message);
        setError('Có lỗi xảy ra khi thêm ngân hàng.');
    }
};

return (
<div className="container mx-auto" style={{ minHeight:'calc(100vh - 130px)' }}>
        <div className="card bg-white shadow-md p-6 mt-6 mb-6 mx-auto w-full md:w-1/2 lg:w-1/2 rounded-lg">
            <h2 className="text-3xl font-bold text-center mb-6">Thêm mới Ngân Hàng</h2>
            <form onSubmit={handleSubmit}>
                {error && <div className="bg-red-100 text-red-700 p-4 rounded mb-4">{error}</div>}
                <div className="mb-4">
                    <label className="block text-gray-700 font-bold mb-2">Tên ngân hàng</label>
                    <input 
                        type="text" 
                        className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        name="tenNganHang"
                        value={nganHang.tenNganHang} 
                        onChange={handleChange} 
                        required 
                    />
                </div>
                <div className="mb-4">
                    <label className="block text-gray-700 font-bold mb-2">Địa chỉ</label>
                    <textarea 
                        className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                        name="diaChi"
                        value={nganHang.diaChi} 
                        onChange={handleChange} 
                        required 
                    />
                </div>
                <div className="mb-4">
                    <label className="block text-gray-700 font-bold mb-2">Email</label>
                    <input 
                        type="text" 
                        className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        name="email"
                        value={nganHang.email} 
                        onChange={handleChange} 
                        required 
                    />
                </div>
                <div className="mb-4">
                    <label className="block text-gray-700 font-bold mb-2">Số điện thoại</label>
                    <input 
                        type="text" 
                        className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                        name="sdt"
                        value={nganHang.sdt} 
                        onChange={handleChange} 
                        required 
                    />
                </div>
                <div className="mb-4">
                    <label className="block text-gray-700 font-bold mb-2">Mô tả</label>
                    <textarea 
                        className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                        name="moTa"
                        value={nganHang.moTa} 
                        onChange={handleChange} 
                        required 
                    />
                </div>
                <div className="mb-4">
                    <label className="block text-gray-700 font-bold mb-2">Người tạo</label>
                    <select 
                        className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                        name="nguoiTaoId"
                        value={nganHang.nguoiTaoId}
                        onChange={handleChange} 
                        required
                    >
                        <option value="">Chọn người tạo</option>
                        {nhanViens.map(nhanVien => (
                            <option key={nhanVien.id} value={nhanVien.id}>{nhanVien.hoTen}</option>
                        ))}
                    </select>
                </div>
                <div className="mb-4">
                    <label className="block text-gray-700 font-bold mb-2">Người cập nhật</label>
                    <select 
                        className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                        name="nguoiCapNhatId"
                        value={nganHang.nguoiCapNhatId}
                        onChange={handleChange} 
                        required
                    >
                        <option value="">Chọn người cập nhật</option>
                        {nhanViens.map(nhanVien => (
                            <option key={nhanVien.id} value={nhanVien.id}>{nhanVien.hoTen}</option>
                        ))}
                    </select>
                </div>
                <div className="mb-4">
                    <label className="flex items-center">
                        <input 
                            type="checkbox" 
                            className="form-check-input mr-2 leading-tight"
                            name="isActive"
                            checked={nganHang.isActive}
                            onChange={handleChange} 
                        />
                        <span className="text-gray-700 font-bold">Áp dụng</span>
                    </label>
                </div>
                <div className="flex justify-between">
                    <button type="submit" className="btn bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline">Lưu</button>
                    <button type="button" className="btn bg-gray-500 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" onClick={() => navigate('/ngan-hang')}>Hủy</button>
                </div>
            </form>
        </div>
    </div>
)
}

export default ThemNganHangComponent