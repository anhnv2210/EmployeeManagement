import { getChiNhanhNganHangById, updateChiNhanhNganHang } from '@/services/ChiNhanhNganHangService';
import { listNganHang } from '@/services/NganHangService';
import { listNhanVien } from '@/services/NhanVienService';
import { formatISO } from 'date-fns';
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom';

const SuaChiNhanhNganHangComponent = () => {
    const { id } = useParams();
    const navigate = useNavigate();
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

    useEffect(() => {
        getChiNhanhNganHangById(id).then(response => {
            console.log(response.data)
            setChiNhanhNganHang(response.data);
        }).catch(error => {
            console.error(error);
        });

        listNhanVien().then(response => {
            setNhanViens(response.data.data);
        }).catch(error => {
            console.error(error);
        });

        listNganHang().then(response => {
            setNganHangs(response.data.data);
        }).catch(error => {
            console.error(error);
        });

    }, [id]);

    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        setChiNhanhNganHang({
            ...chiNhanhNganHang,
            [name]: type === 'checkbox' ? checked : value
        });
    }

    const handleSubmit = (e) => {
        e.preventDefault();
    
        const updatedChiNhanhNganHang = {
            ...chiNhanhNganHang,
            ngayCapNhat: formatISO(new Date()) 
        };
    
        updateChiNhanhNganHang(id, updatedChiNhanhNganHang).then(() => {
            navigate('/chi-nhanh-ngan-hang');
        }).catch(error => {
            console.error("Error updating chi nhanh ngan hang:", error.response ? error.response.data : error.message);
        });
    }

    return (
        <div className="container mx-auto mt-5" style={{ minHeight:'calc(100vh - 130px)' }}>
            <div className="card p-4 mt-4 mb-3 w-1/2 mx-auto shadow-lg rounded-lg">
                <h2 className="text-3xl font-bold text-center mb-4">Sửa thông tin Chi nhánh Ngân hàng</h2>
                <form onSubmit={handleSubmit}>
                    <div className="mb-4">
                        <label className="block text-gray-700 text-base font-bold mb-2">Tên chi nhánh ngân hàng</label>
                        <input
                            type="text"
                            className="form-input w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="tenChiNhanhNganHang"
                            value={chiNhanhNganHang.tenChiNhanhNganHang}
                            onChange={handleChange}
                            required
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 text-base font-bold mb-2">Địa chỉ</label>
                        <textarea
                            className="form-textarea w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="diaChi"
                            value={chiNhanhNganHang.diaChi}
                            onChange={handleChange}
                            required
                        ></textarea>
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 text-base font-bold mb-2">Email</label>
                        <input
                            type="text"
                            className="form-input w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="email"
                            value={chiNhanhNganHang.email}
                            onChange={handleChange}
                            disabled
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 text-base font-bold mb-2">Số điện thoại</label>
                        <input
                            type="text"
                            className="form-input w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="soDienThoai"
                            value={chiNhanhNganHang.soDienThoai}
                            onChange={handleChange}
                            disabled
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 text-base font-bold mb-2">Mô tả</label>
                        <textarea
                            className="form-textarea w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="moTa"
                            value={chiNhanhNganHang.moTa}
                            onChange={handleChange}
                            required
                        ></textarea>
                    </div> 
                    <div className="mb-4">
                            <label className="block text-gray-700 font-bold mb-2">Ngân hàng</label>
                            <select 
                                className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                                name="nganHangId"
                                value={chiNhanhNganHang.nganHangId}
                                onChange={handleChange} 
                                disabled
                            >
                                {nganHangs.map(nganHang => (
                                    <option key={nganHang.id} value={nganHang.id}>{nganHang.tenNganHang}</option>
                                ))}
                            </select>
                    </div>
                    
                    <div className="mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2">Người tạo</label>
                        <select
                            className="form-select w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="nguoiTaoId"
                            value={chiNhanhNganHang.nguoiTaoId}
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
                            value={chiNhanhNganHang.nguoiCapNhatId}
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
                            checked={chiNhanhNganHang.isActive}
                            onChange={handleChange}
                        />
                        <label className="ml-2 text-gray-700 text-sm">Áp dụng</label>
                    </div>
                    <div className="flex justify-between">
                    <button type="submit" className="btn bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">Cập nhật</button>
                    <button type="button" className="btn bg-gray-500 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" onClick={() => navigate('/chi-nhanh-ngan-hang')}>Hủy</button>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default SuaChiNhanhNganHangComponent