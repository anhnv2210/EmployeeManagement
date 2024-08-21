import { getQuocGiaById, updateQuocGia } from '@/services/QuocGiaService';
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom';

const SuaQuocGiaComponent = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const [quocGia, setQuocGia] = useState({
        tenQuocGia: '',
        moTa: '',
    });

    useEffect(() => {
        getQuocGiaById(id).then(response => {
            setQuocGia(response.data);
        }).catch(error => {
            console.error(error);
        });
    }, [id]);

    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        setQuocGia({
            ...quocGia,
            [name]: type === 'checkbox' ? checked : value
        });
    }

    const handleSubmit = (e) => {
        e.preventDefault();
    
        const updatedQuocGia= {
            ...quocGia
        };
    
        updateQuocGia(id, updatedQuocGia).then(() => {
            navigate('/quoc-gia');
        }).catch(error => {
            console.error("Error updating quoc gia:", error.response ? error.response.data : error.message);
        });
    }

    return (
        <div className="container mx-auto mt-5" style={{ minHeight:'calc(100vh - 130px)' }}>
            <div className="card p-4 mt-4 mb-3 w-1/2 mx-auto shadow-lg rounded-lg">
                <h2 className="text-3xl font-bold text-center mb-4">Sửa thông tin Quốc gia</h2>
                <form onSubmit={handleSubmit}>
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
                    <button type="submit" className="btn bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">Cập nhật</button>
                    <button type="button" className="btn bg-gray-500 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" onClick={() => navigate('/quoc-gia')}>Hủy</button>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default SuaQuocGiaComponent