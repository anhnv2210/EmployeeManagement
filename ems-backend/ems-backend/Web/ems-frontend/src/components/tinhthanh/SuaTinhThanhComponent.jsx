import { listQuocGia } from '@/services/QuocGiaService';
import { getTinhThanhById, updateTinhThanh } from '@/services/TinhThanhService';
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom';

const SuaTinhThanhComponent = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const [tinhThanh, setTinhThanh] = useState({
        tenTinhThanh:'',
        moTa:'',
        quocGiaId:'',
    });
    const [quocGias, setQuocGias] = useState([]);

    useEffect(() => {
        const fetchData = async () => {
            try {
                const tinhThanhResponse = await getTinhThanhById(id);
                setTinhThanh(tinhThanhResponse.data);
                
                const quocGiaResponse = await listQuocGia();
                setQuocGias(quocGiaResponse.data.data);
            } catch (error) {
                console.error('Có lỗi xảy ra khi gọi API:', error);
            }
        };
        fetchData();
    }, [id]);

    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        setTinhThanh({
            ...tinhThanh,
            [name]: type === 'checkbox' ? checked : value
        });
    }

    const handleSubmit = (e) => {
        e.preventDefault();
    
        const updatedTinhThanh = {
            ...tinhThanh
        };
    
        updateTinhThanh(id, updatedTinhThanh).then(() => {
            navigate('/tinh-thanh');
        }).catch(error => {
            console.error("Error updating tinh thanh:", error.response ? error.response.data : error.message);
        });
    }

    return (
        <div className="container mx-auto mt-5" style={{ minHeight:'calc(100vh - 130px)' }}>
            <div className="card p-4 mt-4 mb-3 w-1/2 mx-auto shadow-lg rounded-lg">
                <h2 className="text-3xl font-bold text-center mb-4">Sửa thông tin Tỉnh/Thành phố</h2>
                <form onSubmit={handleSubmit}>
                    <div className="mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2">Tên tỉnh thành</label>
                        <input
                            type="text"
                            className="form-input w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="tenTinhThanh"
                            value={tinhThanh.tenTinhThanh}
                            onChange={handleChange}
                            disabled
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2">Mô tả</label>
                        <textarea
                            className="form-textarea w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="moTa"
                            value={tinhThanh.moTa}
                            onChange={handleChange}
                        ></textarea>
                    </div>
                   
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Thuộc quốc gia</label>
                        <select
                            className="form-select w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="quocGiaId"
                            value={tinhThanh.quocGiaId}
                            onChange={handleChange}
                            disabled // This disables the select dropdown
                        >
                            <option value="">Chọn quốc gia</option>
                            {quocGias.map(quocGia => (
                                <option key={quocGia.id} value={quocGia.id}>{quocGia.tenQuocGia}</option>
                            ))}
                        </select>
                    </div>
                    
                    <div className="flex justify-between">
                    <button type="submit" className="btn bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">Cập nhật</button>
                    <button type="button" className="btn bg-gray-500 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" onClick={() => navigate('/tinh-thanh')}>Hủy</button>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default SuaTinhThanhComponent