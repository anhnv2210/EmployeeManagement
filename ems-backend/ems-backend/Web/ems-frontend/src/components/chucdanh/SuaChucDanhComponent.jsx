import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { getChucDanhById, updateChucDanh } from '../../services/ChucDanhService';
import { listNhanVien } from '../../services/NhanVienService';
import { formatISO } from 'date-fns';

const SuaChucDanhComponent = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const [chucDanh, setChucDanh] = useState({
        tenChucDanh: '',
        moTa: '',
        nguoiTaoId: '',
        nguoiCapNhatId: '',
        isActive: true,
    });
    const [nhanViens, setNhanViens] = useState([]);

    useEffect(() => {
        getChucDanhById(id).then(response => {
            setChucDanh(response.data);
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
        setChucDanh({
            ...chucDanh,
            [name]: type === 'checkbox' ? checked : value
        });
    }

    const handleSubmit = (e) => {
        e.preventDefault();
    
        const updatedChucDanh = {
            ...chucDanh,
            ngayCapNhat: formatISO(new Date()) 
        };
    
        updateChucDanh(id, updatedChucDanh).then(() => {
            navigate('/chucdanh');
        }).catch(error => {
            console.error("Error updating ChucDanh:", error.response ? error.response.data : error.message);
        });
    }

    return (
        <div className='container'>
            <div className='card p-4 mt-4 mb-3 w-50 card-them'>
                <h2 className='text-center mb-4'>Sửa chức danh</h2>
                <form onSubmit={handleSubmit}>
                    <div className='mb-3'>
                        <label className='form-label'>Tên chức danh</label>
                        <input
                            type='text'
                            className='form-control'
                            name='tenChucDanh'
                            value={chucDanh.tenChucDanh}
                            onChange={handleChange}
                            disabled
                        />
                    </div>
                    <div className='mb-3'>
                        <label className='form-label'>Mô tả</label>
                        <textarea
                            className='form-control'
                            name='moTa'
                            value={chucDanh.moTa}
                            onChange={handleChange}
                        ></textarea>
                    </div>
                    <div className='mb-3'>
                        <label className='form-label'>Người tạo</label>
                        <select
                            className='form-control'
                            name='nguoiTaoId'
                            value={chucDanh.nguoiTaoId}
                            onChange={handleChange}
                            disabled
                        >
                            {nhanViens.map(nv => (
                                <option key={nv.id} value={nv.id}>{nv.hoTen}</option>
                            ))}
                        </select>
                    </div>
                    <div className='mb-3'>
                        <label className='form-label'>Người cập nhật</label>
                        <select
                            className='form-control'
                            name='nguoiCapNhatId'
                            value={chucDanh.nguoiCapNhatId}
                            onChange={handleChange}
                            required
                        >
                            <option value=''>Chọn người cập nhật</option>
                            {nhanViens.map(nv => (
                                <option key={nv.id} value={nv.id}>{nv.hoTen}</option>
                            ))}
                        </select>
                    </div>
                    <div className='mb-3 form-check'>
                        <input
                            type='checkbox'
                            className='form-check-input'
                            name='isActive'
                            checked={chucDanh.isActive}
                            onChange={handleChange}
                        />
                        <label className='form-check-label'>Áp dụng</label>
                    </div>
                    <button type='submit' className='btn btn-primary'>Cập nhật</button>
                </form>
            </div>
        </div>
    );
}

export default SuaChucDanhComponent;
