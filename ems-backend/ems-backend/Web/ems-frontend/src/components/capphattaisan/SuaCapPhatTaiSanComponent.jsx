import { getCapPhatTaiSanById, updateCapPhatTaiSan } from '@/services/CapPhatTaiSanService';
import { listNhanVien } from '@/services/NhanVienService';
import { listTaiSan } from '@/services/TaiSanService';
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom';

const SuaCapPhatTaiSanComponent = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const [capPhatTaiSan, setCapPhatTaiSan] = useState({
        nhanVienId: '',
        taiSanId: '',
        ngayCapPhat: '',
        ngaTraLai: '',
        tinhTrang: '',
    });
    const [nhanViens, setNhanViens] = useState([]);
    const [taiSans, setTaiSans] = useState([]);
    const [error, setError] = useState('');

    useEffect(() => {
        getCapPhatTaiSanById(id).then(response => {
                setCapPhatTaiSan(response.data);
            })
            .catch(error => {
                console.error('Có lỗi xảy ra khi gọi API:', error);
            });
        listNhanVien()
            .then(response => {
                setNhanViens(response.data.data);
            })
            .catch(error => {
                console.error('Có lỗi xảy ra khi gọi API:', error);
            });
        listTaiSan()
            .then(response => {
                setTaiSans(response.data.data);
            })
            .catch(error => {
                console.error('Có lỗi xảy ra khi gọi API:', error);
            });
    }, []);

    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        setCapPhatTaiSan({
            ...capPhatTaiSan,
            [name]: type === 'checkbox' ? checked : value
        });
    }

    const handleSubmit = (e) => {
        e.preventDefault();
    
        const updatedCapPhat = {
            ...capPhatTaiSan
        };
    
        updateCapPhatTaiSan(id, updatedCapPhat).then(() => {
            navigate('/cap-phat');
        }).catch(error => {
            console.error("Error updating capphat:", error.response ? error.response.data : error.message);
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
        <div className="container mx-auto">
            <div className="card bg-white shadow-md p-6 mt-6 mb-6 mx-auto w-full md:w-1/2 lg:w-1/3 rounded-lg">
                <h2 className="text-2xl font-bold text-center mb-6">Thêm mới cấp phát tài sản</h2>
                <form onSubmit={handleSubmit}>
                    {error && <div className="bg-red-100 text-red-700 p-4 rounded mb-4">{error}</div>}
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Nhân viên</label>
                        <select 
                            className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                            name="nhanVienId"
                            value={capPhatTaiSan.nhanVienId}
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
                        <label className="block text-gray-700 font-bold mb-2">Tài sản</label>
                        <select 
                            className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                            name="taiSanId"
                            value={capPhatTaiSan.taiSanId}
                            onChange={handleChange} 
                            required
                        >
                            <option value="">Chọn tài sản</option>
                            {taiSans.map(taisan => (
                                <option key={taisan.id} value={taisan.id}>{taisan.tenTaiSan}</option>
                            ))}
                        </select>
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Ngày cấp phát</label>
                        <input 
                            type="date" 
                            className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            name="ngayCapPhat"
                            value={ConvertDate(capPhatTaiSan.ngayCapPhat)} 
                            onChange={handleChange} 
                            required 
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Ngày trả</label>
                        <input 
                            type="date" 
                            className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            name="ngayTraLai"
                            value={ConvertDate(capPhatTaiSan.ngayTraLai)} 
                            onChange={handleChange} 
                            required 
                        />
                    </div>
                    
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Tình trạng</label>
                        <input 
                            type="text" 
                            className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            name="tinhTrang"
                            value={capPhatTaiSan.tinhTrang} 
                            onChange={handleChange} 
                            required 
                        />
                    </div>
                    <div className="flex justify-between">
                        <button type="submit" className="btn bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline">Lưu</button>
                        <button type="button" className="btn bg-gray-500 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" onClick={() => navigate('/chuc-danh')}>Hủy</button>
                    </div>
                </form>
            </div>
        </div>
    )
}

export default SuaCapPhatTaiSanComponent