import React, { useEffect,useState } from 'react'
import { useNavigate } from 'react-router-dom';
import { listNhanVien } from '../../services/NhanVienService';
import { addChucDanh, checkTenChucDanhExists } from '../../services/ChucDanhService';

const ThemChucDanhComponent = () => {
    const [chucDanh, setChucDanh] = useState({
        tenChucDanh: '',
        moTa: '',
        nguoiTaoId: '',
        nguoiCapNhatId: '',
        isActive: true,
    });
    const [nhanViens, setNhanViens] = useState([]);

    const [error, setError] = useState('');
    const navigate = useNavigate();

    useEffect(() => {
        // Gọi API để lấy danh sách nhân viên
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
        setChucDanh({
            ...chucDanh,
            [name]: type === 'checkbox' ? checked : value
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        
        try {
            // Kiểm tra tên chức danh đã tồn tại
            const exists = await checkTenChucDanhExists(chucDanh.tenChucDanh);
            if (exists) {
                setError('Tên chức danh đã tồn tại. Vui lòng chọn tên khác.');
                return;
            }
            
            // Nếu tên không tồn tại, thực hiện thêm chức danh
            await addChucDanh(chucDanh);
            navigate('/chucdanh');
        } catch (error) {
            console.error("Error adding ChucDanh:", error.response ? error.response.data : error.message);
            setError('Có lỗi xảy ra khi thêm chức danh.');
        }
    };

  return (
    <div className='container'>
        <div className='card p-4 mt-4 mb-3 w-50 card-them'>
            <h2 className='text-center mb-4'>Thêm mới chức danh</h2>
                <form onSubmit={handleSubmit}>
                {error && <div className="alert alert-danger">{error}</div>}
                    <div className='mb-3'>
                        <label className='form-label'>Tên chức danh</label>
                        <input 
                            type='text' 
                            className='form-control'
                            name='tenChucDanh'
                            value={chucDanh.tenChucDanh} 
                            onChange={handleChange} 
                            required 
                        />
                    </div>
                    <div className='mb-3'>
                        <label className='form-label'>Mô tả</label>
                        <textarea 
                            className='form-control' 
                            name='moTa'
                            value={chucDanh.moTa} 
                            onChange={handleChange} 
                            required 
                        />
                    </div>
                    <div className='mb-3'>
                        <label className='form-label'>Người tạo</label>
                        <select 
                            className='form-select' 
                            name='nguoiTaoId'
                            value={chucDanh.nguoiTaoId}
                            onChange={handleChange} 
                            required
                        >
                            <option value=''>Chọn người tạo</option>
                            {nhanViens.map(nhanVien => (
                                <option key={nhanVien.id} value={nhanVien.id}>{nhanVien.hoTen}</option>
                            ))}
                        </select>
                    </div>
                    <div className='mb-3'>
                        <label className='form-label'>Người cập nhật</label>
                        <select 
                            className='form-select' 
                            name='nguoiCapNhatId'
                            value={chucDanh.nguoiCapNhatId}
                            onChange={handleChange} 
                            required
                        >
                            <option value=''>Chọn người cập nhật</option>
                            {nhanViens.map(nhanVien => (
                                <option key={nhanVien.id} value={nhanVien.id}>{nhanVien.hoTen}</option>
                            ))}
                        </select>
                    </div>
                    <div className='form-check mb-3'>
                        <input 
                            className='form-check-input' 
                            type='checkbox' 
                            name='isActive'
                            checked={chucDanh.isActive}
                            onChange={handleChange} 
                        />
                        <label className='form-check-label'>Áp dụng</label>
                    </div>
                    <button type='submit' className='btn btn-primary'>Lưu</button>
                    <button type='button' className='btn btn-secondary ms-2' onClick={() => navigate('/chucdanh')}>Hủy</button>
                </form>
        </div>
    </div>
  )
}

export default ThemChucDanhComponent