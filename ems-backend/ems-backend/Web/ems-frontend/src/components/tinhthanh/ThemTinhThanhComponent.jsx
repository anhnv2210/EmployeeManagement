import { listQuocGia } from '@/services/QuocGiaService';
import { addTInhThanh, checkTenTinhThanhExists } from '@/services/TinhThanhService';
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom';

const ThemTinhThanhComponent = () => {
    const [tinhThanh, setTinhThanh] = useState({
        tenTinhThanh: '',
        moTa:'',
        quocGiaId: '',
    });
    const [quocGias, setQuocGias] = useState([]);
    
    const [error, setError] = useState('');
    const navigate = useNavigate();
    
    useEffect(() => {
        listQuocGia()
            .then(response => {
                setQuocGias(response.data.data);
            })
            .catch(error => {
                console.error('Có lỗi xảy ra khi gọi API:', error);
            });
    }, []);
    
    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        setTinhThanh({
            ...tinhThanh,
            [name]: type === 'checkbox' ? checked : value
        });
    };
    
    const handleSubmit = async (e) => {
        e.preventDefault();
        
        try {
            
            const existTen = await checkTenTinhThanhExists(tinhThanh.tenTinhThanh);
            if (existTen) {
                setError('tên tỉnh thành đã tồn tại. Vui lòng chọn tên khác.');
                return;
            }
            await addTInhThanh(tinhThanh);
            navigate('/tinh-thanh');
        } catch (error) {
            console.error("Error adding TInhThanh:", error.response ? error.response.data : error.message);
            setError('Có lỗi xảy ra khi thêm tỉnh thành.');
        }
    };
    
    return (
    <div className="container mx-auto" style={{ minHeight:'calc(100vh - 130px)' }}>
            <div className="card bg-white shadow-md p-6 mt-6 mb-6 mx-auto w-full md:w-1/2 lg:w-1/2 rounded-lg">
                <h2 className="text-3xl font-bold text-center mb-6">Thêm mới Tỉnh/Thành phố</h2>
                <form onSubmit={handleSubmit}>
                    {error && <div className="bg-red-100 text-red-700 p-4 rounded mb-4">{error}</div>}
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Tên tỉnh thành</label>
                        <input 
                            type="text" 
                            className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            name="tenTinhThanh"
                            value={tinhThanh.tenTinhThanh} 
                            onChange={handleChange} 
                            required 
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Mô tả</label>
                        <textarea 
                            className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                            name="moTa"
                            value={tinhThanh.moTa} 
                            onChange={handleChange} 
                            required 
                        />
                    </div>
                   
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Thuộc quốc gia</label>
                        <select 
                            className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                            name="quocGiaId"
                            value={tinhThanh.quocGiaId}
                            onChange={handleChange} 
                            required
                        >
                            <option value="">Chọn quốc gia</option>
                            {quocGias.map(quocGia => (
                                <option key={quocGia.id} value={quocGia.id}>{quocGia.tenQuocGia}</option>
                            ))}
                        </select>
                    </div>
                    <div className="flex justify-between">
                        <button type="submit" className="btn bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline">Lưu</button>
                        <button type="button" className="btn bg-gray-500 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" onClick={() => navigate('/tinh-thanh')}>Hủy</button>
                    </div>
                </form>
            </div>
        </div>
    )
}

export default ThemTinhThanhComponent