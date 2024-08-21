import { listHoSoLuong } from '@/services/HoSoLuongService';
import { listNhanVien } from '@/services/NhanVienService';
import { addQuyetDinh } from '@/services/QuyetDinhService';
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom';

const ThemQuyetDinhComponent = () => {
    const [quyetDinh, setQuyetDinh] = useState({
        nhanVienId:'',
        hoSoLuongId:'',
        noiDung: '',
        ngayQuyetDinh: '',
    });
    const [nhanViens, setNhanViens] = useState([]);
    const [hoSoLuongs, setHoSoLuongs] = useState([]);
    
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
    }, []);

    
    
    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        setQuyetDinh({
            ...quyetDinh,
            [name]: type === 'checkbox' ? checked : value
        });
    };
    
    const handleSubmit = async (e) => {
        e.preventDefault();
        
        try {
            addQuyetDinh(quyetDinh);
            navigate('/quyet-dinh');
        } catch (error) {
            console.error("Error adding QuyetDinh:", error.response ? error.response.data : error.message);
            setError('Có lỗi xảy ra khi thêm quyết định.');
        }
    };
    
    return (
    <div className="container mx-auto" style={{ minHeight:'calc(100vh - 130px)' }}>
            <div className="card bg-white shadow-md p-6 mt-6 mb-6 mx-auto w-full md:w-1/2 lg:w-1/2 rounded-lg">
                <h2 className="text-3xl font-bold text-center mb-6">Thêm mới Quyết Định</h2>
                <form onSubmit={handleSubmit}>
                    {error && <div className="bg-red-100 text-red-700 p-4 rounded mb-4">{error}</div>}
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Nhân viên</label>
                        <select 
                            className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                            name="nhanVienId"
                            value={quyetDinh.nhanVienId}
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
                            value={quyetDinh.hoSoLuongId}
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
                        <label className="block text-gray-700 font-bold mb-2">Nội dung</label>
                        <textarea 
                            className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                            name="noiDung"
                            value={quyetDinh.noiDung} 
                            onChange={handleChange} 
                            required 
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Ngày quyết định</label>
                        <input 
                            type="date" 
                            className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            name="ngayQuyetDinh"
                            value={quyetDinh.ngayQuyetDinh} 
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
    );
}

export default ThemQuyetDinhComponent