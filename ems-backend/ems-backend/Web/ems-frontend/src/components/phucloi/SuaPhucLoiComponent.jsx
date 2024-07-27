import { listNhanVien } from '@/services/NhanVienService';
import { getPhucLoiById, updatePhucLoi } from '@/services/PhucLoiService';
import { formatISO } from 'date-fns';
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom';

const SuaPhucLoiComponent = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const [phucLoi, setPhucLoi] = useState({
        tenPhucLoi: '',
        moTa: '',
        nguoiTaoId: '',
        nguoiCapNhatId: '',
        isActive: true,
    });
    const [nhanViens, setNhanViens] = useState([]);

    useEffect(() => {
        getPhucLoiById(id).then(response => {
            setPhucLoi(response.data);
        }).catch(error => {
            console.error(error);
        });

        listNhanVien().then(response => {
            setNhanViens(response.data);
        }).catch(error => {
            console.error(error);
        });
    }, [id]);

    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        setPhucLoi({
            ...phucLoi,
            [name]: type === 'checkbox' ? checked : value
        });
    }

    const handleSubmit = (e) => {
        e.preventDefault();
    
        const updatedPhucLoi = {
            ...phucLoi,
            ngayCapNhat: formatISO(new Date()) 
        };
    
        updatePhucLoi(id, updatedPhucLoi).then(() => {
            navigate('/phuc-loi');
        }).catch(error => {
            console.error("Error updating PhucLoi:", error.response ? error.response.data : error.message);
        });
    }

    return (
        <div className="container mx-auto mt-5">
            <div className="card p-4 mt-4 mb-3 w-1/2 mx-auto shadow-lg rounded-lg">
                <h2 className="text-3xl font-bold text-center mb-4">Sửa Phúc Lợi</h2>
                <form onSubmit={handleSubmit}>
                    <div className="mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2">Tên phúc lợi</label>
                        <input
                            type="text"
                            className="form-input w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="tenPhucLoi"
                            value={phucLoi.tenPhucLoi}
                            onChange={handleChange}
                            disabled
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2">Mô tả</label>
                        <textarea
                            className="form-textarea w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="moTa"
                            value={phucLoi.moTa}
                            onChange={handleChange}
                        ></textarea>
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2">Người tạo</label>
                        <select
                            className="form-select w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="nguoiTaoId"
                            value={phucLoi.nguoiTaoId}
                            onChange={handleChange}
                            disabled
                        >
                            {nhanViens.map(nv => (
                                <option key={nv.id} value={nv.id}>{nv.hoTen}</option>
                            ))}
                        </select>
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2">Người cập nhật</label>
                        <select
                            className="form-select w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="nguoiCapNhatId"
                            value={phucLoi.nguoiCapNhatId}
                            onChange={handleChange}
                            required
                        >
                            <option value="">Chọn người cập nhật</option>
                            {nhanViens.map(nv => (
                                <option key={nv.id} value={nv.id}>{nv.hoTen}</option>
                            ))}
                        </select>
                    </div>
                    <div className="mb-4">
                        <input
                            type="checkbox"
                            className="form-checkbox text-blue-500"
                            name="isActive"
                            checked={phucLoi.isActive}
                            onChange={handleChange}
                        />
                        <label className="ml-2 text-gray-700 text-sm">Áp dụng</label>
                    </div>
                    <div className="flex justify-between">
                    <button type="submit" className="btn bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">Cập nhật</button>
                    <button type="button" className="btn bg-gray-500 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" onClick={() => navigate('/phuc-loi')}>Hủy</button>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default SuaPhucLoiComponent