import { listHoSoLuong } from '@/services/HoSoLuongService';
import { listNhanVien } from '@/services/NhanVienService';
import { getQuyetDinhById, updateQuyetDinh } from '@/services/QuyetDinhService';
import { formatISO } from 'date-fns';
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom';

const SuaQuyetDinhComponent = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const [quyetDinh, setQuyetDinh] = useState({
        nhanVienId: '',
        noiDung: '',
        ngayQuyetDinh: '',
        hoSoLuongId: '',
    });
    const [nhanViens, setNhanViens] = useState([]);
    const [hoSoLuongs, setHoSoLuongs] = useState([]);0
    useEffect(() => {
        getQuyetDinhById(id).then(response => {
            setQuyetDinh(response.data);
        }).catch(error => {
            console.error(error);
        });

        listNhanVien().then(response => {
            setNhanViens(response.data.data);
        }).catch(error => {
            console.error(error);
        });
        listHoSoLuong().then(response => {
            setHoSoLuongs(response.data.data);
        }).catch(error => {
            console.error(error);
        });
    }, [id]);

    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        setQuyetDinh({
            ...quyetDinh,
            [name]: type === 'checkbox' ? checked : value
        });
    }

    const handleSubmit = (e) => {
        e.preventDefault();
    
        const updatedQuyetDinh = {
            ...quyetDinh
        };
    
        updateQuyetDinh(id, updatedQuyetDinh).then(() => {
            navigate('/quyet-dinh');
        }).catch(error => {
            console.error("Error updating QuyetDinh:", error.response ? error.response.data : error.message);
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
                        <label className="block text-gray-700 text-sm font-bold mb-2">Nhân viên</label>
                        <select
                            className="form-select w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="nhanVienId"
                            value={quyetDinh.nhanVienId}
                            onChange={handleChange}
                            required
                        >
                            {nhanViens.map(nv => (
                                <option key={nv.id} value={nv.id}>{nv.hoTen}</option>
                            ))}
                        </select>
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2">Hồ sơ lương</label>
                        <select
                            className="form-select w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="hoSoLuongId"
                            value={quyetDinh.hoSoLuongId}
                            onChange={handleChange}
                            required
                        >
                            {hoSoLuongs.map(hsl => (
                                <option key={hsl.id} value={hsl.id}>{hsl.tenNhanVienKemChucDanh}</option>
                            ))}
                        </select>
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2">Ngày quyết định</label>
                        <input
                            type="date"
                            className="form-input w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="ngayQuyetDinh"
                            value={ConvertDate(quyetDinh.ngayQuyetDinh)}
                            onChange={handleChange}
                            required
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2">Nội dung quyết định</label>
                        <textarea
                            className="form-textarea w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="noiDung"
                            value={quyetDinh.noiDung}
                            onChange={handleChange}
                        ></textarea>
                    </div>
                   
                    <div className="flex justify-between">
                    <button type="submit" className="btn bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">Cập nhật</button>
                    <button type="button" className="btn bg-gray-500 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" onClick={() => navigate('/quyet-dinh')}>Hủy</button>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default SuaQuyetDinhComponent