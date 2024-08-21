import { getNganHangById, updateNganHang } from '@/services/NganHangService';
import { listNhanVien } from '@/services/NhanVienService';
import { formatISO } from 'date-fns';
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom';

const SuaNganHangComponent = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const [nganHang, setNganHang] = useState({
        tenNganHang: '',
        diaChi: '',
        email: '',
        sdt: '',
        moTa: '',
        nguoiTaoId: '',
        nguoiCapNhatId: '',
        isActive: true,
    });
    const [nhanViens, setNhanViens] = useState([]);

    useEffect(() => {
        getNganHangById(id).then(response => {
            setNganHang(response.data);
        }).catch(error => {
            console.error(error);
        });

        listNhanVien().then(response => {
            setNhanViens(response.data.data);
        }).catch(error => {
            console.error(error);
        });
    }, [id]);

    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        setNganHang({
            ...nganHang,
            [name]: type === 'checkbox' ? checked : value
        });
    }

    const handleSubmit = (e) => {
        e.preventDefault();
    
        const updatedNganHang = {
            ...nganHang,
            ngayCapNhat: formatISO(new Date()) 
        };
    
        updateNganHang(id, updatedNganHang).then(() => {
            navigate('/ngan-hang');
        }).catch(error => {
            console.error("Error updating ngan hang:", error.response ? error.response.data : error.message);
        });
    }

    return (
        <div className="container mx-auto mt-5" style={{ minHeight:'calc(100vh - 130px)' }}>
            <div className="card p-4 mt-4 mb-3 w-1/2 mx-auto shadow-lg rounded-lg">
                <h2 className="text-3xl font-bold text-center mb-4">Sửa thông tin Ngân hàng</h2>
                <form onSubmit={handleSubmit}>
                    <div className="mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2">Tên ngân hàng</label>
                        <input
                            type="text"
                            className="form-input w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="tenNganHang"
                            value={nganHang.tenNganHang}
                            onChange={handleChange}
                            disabled
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2">Địa chỉ</label>
                        <textarea
                            className="form-textarea w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="diaChi"
                            value={nganHang.diaChi}
                            onChange={handleChange}
                        ></textarea>
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2">Email</label>
                        <input
                            type="text"
                            className="form-input w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="email"
                            value={nganHang.email}
                            onChange={handleChange}
                            disabled
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2">Số điện thoại</label>
                        <input
                            type="text"
                            className="form-input w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="sdt"
                            value={nganHang.sdt}
                            onChange={handleChange}
                            disabled
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2">Mô tả</label>
                        <textarea
                            className="form-textarea w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="moTa"
                            value={nganHang.moTa}
                            onChange={handleChange}
                        ></textarea>
                    </div> 
                    <div className="mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2">Người tạo</label>
                        <select
                            className="form-select w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="nguoiTaoId"
                            value={nganHang.nguoiTaoId}
                            onChange={handleChange}
                            disabled
                        >
                            {nhanViens.map(nv => (
                                <option key={nv.id} value={nv.id}>{nv.hoten}</option>
                            ))}
                        </select>
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2">Người cập nhật</label>
                        <select
                            className="form-select w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="nguoiCapNhatId"
                            value={nganHang.nguoiCapNhatId}
                            onChange={handleChange}
                            required
                        >
                            <option value="">Chọn người cập nhật</option>
                            {nhanViens.map(nv => (
                                <option key={nv.id} value={nv.id}>{nv.hoten}</option>
                            ))}
                        </select>
                    </div>
                    <div className="mb-4">
                        <input
                            type="checkbox"
                            className="form-checkbox text-blue-500"
                            name="isActive"
                            checked={nganHang.isActive}
                            onChange={handleChange}
                        />
                        <label className="ml-2 text-gray-700 text-sm">Áp dụng</label>
                    </div>
                    <div className="flex justify-between">
                    <button type="submit" className="btn bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">Cập nhật</button>
                    <button type="button" className="btn bg-gray-500 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" onClick={() => navigate('/ngan-hang')}>Hủy</button>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default SuaNganHangComponent