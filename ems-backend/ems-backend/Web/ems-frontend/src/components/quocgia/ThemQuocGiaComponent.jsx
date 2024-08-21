import { addQuocGia, checkTenQuocGiaExists } from '@/services/QuocGiaService';
import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom';

const ThemQuocGiaComponent = () => {
    const [quocGia, setQuocGia] = useState({
        tenQuocGia: '',
        moTa: '',
    });
    
    const [error, setError] = useState('');
    const navigate = useNavigate();
    
    
    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        setQuocGia({
            ...quocGia,
            [name]: type === 'checkbox' ? checked : value
        });
    };
    
    const handleSubmit = async (e) => {
        e.preventDefault();
        
        try {
            
            const existTen = await checkTenQuocGiaExists(quocGia.tenQuocGia);
            if (existTen) {
                setError('tên quốc gia đã tồn tại. Vui lòng chọn tên khác.');
                return;
            }
            await addQuocGia(quocGia);
            navigate('/quoc-gia');
        } catch (error) {
            console.error("Error adding QuocGia:", error.response ? error.response.data : error.message);
            setError('Có lỗi xảy ra khi thêm quốc gia.');
        }
    };
    
    return (
    <div className="container mx-auto" style={{ minHeight:'calc(100vh - 150px)' }}>
            <div className="card bg-white shadow-md p-6 mt-10 mb-6 mx-auto w-full md:w-1/2 lg:w-1/2 rounded-lg border">
                <h2 className="text-3xl font-bold text-center mb-6">Thêm mới Quốc Gia</h2>
                <form onSubmit={handleSubmit}>
                    {error && <div className="bg-red-100 text-red-700 p-4 rounded mb-4">{error}</div>}
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Tên quốc gia</label>
                        <input 
                            type="text" 
                            className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            name="tenQuocGia"
                            value={quocGia.tenQuocGia} 
                            onChange={handleChange} 
                            required 
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Mô tả</label>
                        <textarea 
                            className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                            name="moTa"
                            value={quocGia.moTa} 
                            onChange={handleChange} 
                            required 
                        />
                    </div>
                    <div className="flex justify-between">
                        <button type="submit" className="btn bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline">Lưu</button>
                        <button type="button" className="btn bg-gray-500 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" onClick={() => navigate('/quoc-gia')}>Hủy</button>
                    </div>
                </form>
            </div>
        </div>
    )
}

export default ThemQuocGiaComponent