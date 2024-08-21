import { listNhanVien } from '@/services/NhanVienService';
import { addNoiKhamBenh, checkEmailExists, checkSoDienThoaiExists } from '@/services/NoiKhamBenhService';
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom';

const ThemNoiKhamBenhComponent = () => {
    const [noiKhamBenh, setNoiKhamBenh] = useState({
        tenNoiKhamBenh: '',
        diaChi:'',
        email:'',
        sdt:'',
        ghiChu: '',
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
        setNoiKhamBenh({
            ...noiKhamBenh,
            [name]: type === 'checkbox' ? checked : value
        });
    };
    
    const handleSubmit = async (e) => {
        e.preventDefault();
        
        try {
            
            const existEmail = await checkEmailExists(noiKhamBenh.email);
            if (existEmail) {
                setError('Email của nơi khám bệnh đã tồn tại. Vui lòng chọn email khác.');
                return;
            }
            const existSDT = await checkSoDienThoaiExists(noiKhamBenh.sdt);
            if (existSDT) {
                setError('Số điện thoại của nơi khám bệnh đã tồn tại. Vui lòng chọn sđt khác.');
                return;
            }
            await addNoiKhamBenh(noiKhamBenh);
            navigate('/noi-kham-benh');
        } catch (error) {
            console.error("Error adding NoiKhamBenh:", error.response ? error.response.data : error.message);
            setError('Có lỗi xảy ra khi thêm nơi khám bệnh.');
        }
    };
    
    return (
    <div className="container mx-auto" style={{ minHeight:'calc(100vh - 130px)' }}>
            <div className="card bg-white shadow-md p-6 mt-6 mb-6 mx-auto w-full md:w-1/2 lg:w-1/2 rounded-lg">
                <h2 className="text-3xl font-bold text-center mb-6">Thêm mới Nơi Khám Bệnh</h2>
                <form onSubmit={handleSubmit}>
                    {error && <div className="bg-red-100 text-red-700 p-4 rounded mb-4">{error}</div>}
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Tên nơi khám bệnh</label>
                        <input 
                            type="text" 
                            className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            name="tenNoiKhamBenh"
                            value={noiKhamBenh.tenNoiKhamBenh} 
                            onChange={handleChange} 
                            required 
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Địa chỉ</label>
                        <textarea 
                            className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                            name="diaChi"
                            value={noiKhamBenh.diaChi} 
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
                            value={noiKhamBenh.email} 
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
                            value={noiKhamBenh.sdt} 
                            onChange={handleChange} 
                            required 
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Ghi chú</label>
                        <textarea 
                            className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                            name="ghiChu"
                            value={noiKhamBenh.ghiChu} 
                            onChange={handleChange} 
                            required 
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Người tạo</label>
                        <select 
                            className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                            name="nguoiTaoId"
                            value={noiKhamBenh.nguoiTaoId}
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
                            value={noiKhamBenh.nguoiCapNhatId}
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
                                checked={noiKhamBenh.isActive}
                                onChange={handleChange} 
                            />
                            <span className="text-gray-700 font-bold">Áp dụng</span>
                        </label>
                    </div>
                    <div className="flex justify-between">
                        <button type="submit" className="btn bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline">Lưu</button>
                        <button type="button" className="btn bg-gray-500 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" onClick={() => navigate('/noi-kham-benh')}>Hủy</button>
                    </div>
                </form>
            </div>
        </div>
    )
}

export default ThemNoiKhamBenhComponent