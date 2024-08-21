    import { addChiNhanhNganHang, checkEmailExists, checkSoDienThoaiExists } from '@/services/ChiNhanhNganHangService';
    import { listNganHang } from '@/services/NganHangService';
    import { listNhanVien } from '@/services/NhanVienService';
    import React, { useEffect, useState } from 'react'
    import { useNavigate } from 'react-router-dom';

    const ThemChiNhanhNganHangComponent = () => {
        const [chiNhanhNganHang, setChiNhanhNganHang] = useState({
            tenChiNhanhNganHang: '',
            diaChi:'',
            email:'',
            soDienThoai:'',
            moTa: '',
            nganHangId:'',
            nguoiTaoId: '',
            nguoiCapNhatId: '',
            isActive: true,
        });
        const [nhanViens, setNhanViens] = useState([]);

        const [nganHangs, setNganHangs] = useState([]);

        const [error, setError] = useState('');
        const navigate = useNavigate();
        
        useEffect(() => {
            listNhanVien().then(response => {
                    setNhanViens(response.data.data);
                }).catch(error => {
                    console.error('Có lỗi xảy ra khi gọi API:', error);
                });
            
            listNganHang().then(response => {
                setNganHangs(response.data.data);
            }).catch(error => {
                console.error('Có lỗi xảy ra khi gọi API:', error);
            });
        }, []);
        
        const handleChange = (e) => {
            const { name, value, type, checked } = e.target;
            setChiNhanhNganHang({
                ...chiNhanhNganHang,
                [name]: type === 'checkbox' ? checked : value
            });
        };
        
        const handleSubmit = async (e) => {
            e.preventDefault();
            
            try {
                const existEmail = await checkEmailExists(chiNhanhNganHang.email);
                if (existEmail) {
                    setError('Email của chi nhánh ngân hàng đã tồn tại. Vui lòng chọn email khác.');
                    return;
                }
                const existSDT = await checkSoDienThoaiExists(chiNhanhNganHang.sdt);
                if (existSDT) {
                    setError('Số điện thoại của chi nhánh ngân hàng đã tồn tại. Vui lòng chọn sđt khác.');
                    return;
                }
                await addChiNhanhNganHang(chiNhanhNganHang);
                navigate('/chi-nhanh-ngan-hang');
            } catch (error) {
                console.error("Error adding ChiNhanhNganHang:", error.response ? error.response.data : error.message);
                setError('Có lỗi xảy ra khi thêm chi nhánh ngân hàng.');
            }
        };
        
        return (
        <div className="container mx-auto" style={{ minHeight:'calc(100vh - 130px)' }}>
                <div className="card bg-white shadow-md p-6 mt-6 mb-6 mx-auto w-full md:w-1/2 lg:w-1/2 rounded-lg">
                    <h2 className="text-3xl font-bold text-center mb-6">Thêm mới Chi nhánh Ngân Hàng</h2>
                    <form onSubmit={handleSubmit}>
                        {error && <div className="bg-red-100 text-red-700 p-4 rounded mb-4">{error}</div>}
                        <div className="mb-4">
                            <label className="block text-gray-700 font-bold mb-2">Tên chi nhánh ngân hàng</label>
                            <input 
                                type="text" 
                                className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                                name="tenChiNhanhNganHang"
                                value={chiNhanhNganHang.tenChiNhanhNganHang} 
                                onChange={handleChange} 
                                required 
                            />
                        </div>
                        <div className="mb-4">
                            <label className="block text-gray-700 font-bold mb-2">Địa chỉ</label>
                            <textarea 
                                className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                                name="diaChi"
                                value={chiNhanhNganHang.diaChi} 
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
                                value={chiNhanhNganHang.email} 
                                onChange={handleChange} 
                                required 
                            />
                        </div>
                        <div className="mb-4">
                            <label className="block text-gray-700 font-bold mb-2">Số điện thoại</label>
                            <input 
                                type="text" 
                                className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                                name="soDienThoai"
                                value={chiNhanhNganHang.soDienThoai} 
                                onChange={handleChange} 
                                required 
                            />
                        </div>
                        <div className="mb-4">
                            <label className="block text-gray-700 font-bold mb-2">Mô tả</label>
                            <textarea 
                                className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                                name="moTa"
                                value={chiNhanhNganHang.moTa} 
                                onChange={handleChange} 
                                required 
                            />
                        </div>
                        <div className="mb-4">
                            <label className="block text-gray-700 font-bold mb-2">Ngân hàng</label>
                            <select 
                                className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                                name="nganHangId"
                                value={chiNhanhNganHang.nganHangId}
                                onChange={handleChange} 
                                required
                            >
                                <option value="">Chọn ngân hàng</option>
                                {nganHangs.map(nganHang => (
                                    <option key={nganHang.id} value={nganHang.id}>{nganHang.tenNganHang}</option>
                                ))}
                            </select>
                        </div>
                        <div className="mb-4">
                            <label className="block text-gray-700 font-bold mb-2">Người tạo</label>
                            <select 
                                className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                                name="nguoiTaoId"
                                value={chiNhanhNganHang.nguoiTaoId}
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
                                value={chiNhanhNganHang.nguoiCapNhatId}
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
                                    checked={chiNhanhNganHang.isActive}
                                    onChange={handleChange} 
                                />
                                <span className="text-gray-700 font-bold">Áp dụng</span>
                            </label>
                        </div>
                        <div className="flex justify-between">
                            <button type="submit" className="btn bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline">Lưu</button>
                            <button type="button" className="btn bg-gray-500 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" onClick={() => navigate('/chi-nhanh-ngan-hang')}>Hủy</button>
                        </div>
                    </form>
                </div>
            </div>
        )
    }

    export default ThemChiNhanhNganHangComponent