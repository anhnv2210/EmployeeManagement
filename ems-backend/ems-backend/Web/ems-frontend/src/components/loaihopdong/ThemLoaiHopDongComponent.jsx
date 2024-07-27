import { addLoaiHopDong, checkTenLoaiHopDongExists } from '@/services/LoaiHopDongService';
import { listNhanVien } from '@/services/NhanVienService';
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom';

const ThemLoaiHopDongComponent = () => {
    const [loaiHopDong, setLoaiHopDong] = useState({
        tenLoaiHopDong: '',
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
                setNhanViens(response.data);
            })
            .catch(error => {
                console.error('Có lỗi xảy ra khi gọi API:', error);
            });
    }, []);

    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        setLoaiHopDong({
            ...loaiHopDong,
            [name]: type === 'checkbox' ? checked : value
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        
        try {
            const exists = await checkTenLoaiHopDongExists(loaiHopDong.tenLoaiHopDong);
            if (exists) {
                setError('Tên loại hợp đồng này đã tồn tại. Vui lòng chọn tên khác.');
                return;
            }
            await addLoaiHopDong(loaiHopDong);
            navigate('/loai-hop-dong');
        } catch (error) {
            console.error("Error adding LoaiHopDong:", error.response ? error.response.data : error.message);
            setError('Có lỗi xảy ra khi thêm loại hợp đồng.');
        }
    };

  return (
    <div className="container mx-auto">
            <div className="card bg-white shadow-md p-6 mt-6 mb-6 mx-auto w-full md:w-1/2 lg:w-1/3 rounded-lg">
                <h2 className="text-3xl font-bold text-center mb-6">Thêm mới Loại Hợp Đồng</h2>
                <form onSubmit={handleSubmit}>
                    {error && <div className="bg-red-100 text-red-700 p-4 rounded mb-4">{error}</div>}
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Tên loại hợp đồng</label>
                        <input 
                            type="text" 
                            className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            name="tenLoaiHopDong"
                            value={loaiHopDong.tenLoaiHopDong} 
                            onChange={handleChange} 
                            required 
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Mô tả</label>
                        <textarea 
                            className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                            name="moTa"
                            value={loaiHopDong.moTa} 
                            onChange={handleChange} 
                            required 
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Người tạo</label>
                        <select 
                            className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                            name="nguoiTaoId"
                            value={loaiHopDong.nguoiTaoId}
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
                            value={loaiHopDong.nguoiCapNhatId}
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
                                checked={loaiHopDong.isActive}
                                onChange={handleChange} 
                            />
                            <span className="text-gray-700 font-bold">Áp dụng</span>
                        </label>
                    </div>
                    <div className="flex justify-between">
                        <button type="submit" className="btn bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline">Lưu</button>
                        <button type="button" className="btn bg-gray-500 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" onClick={() => navigate('/loai-hop-dong')}>Hủy</button>
                    </div>
                </form>
            </div>
        </div>
  )
}

export default ThemLoaiHopDongComponent