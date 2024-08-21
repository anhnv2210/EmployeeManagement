import { addQuanHuyen } from '@/services/QuanHuyenService';
import { listQuocGia } from '@/services/QuocGiaService';
import { listTinhThanh, listTinhThanhByQuocGia } from '@/services/TinhThanhService';
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom';

const ThemQuanHuyenComponent = () => {
    const [quanHuyen, setQuanHuyen] = useState({
        tenQuanHuyen:'',
        moTa:'',
        quocGiaId: '',
        tinhThanhId: '',
    });
    const [quocGias, setQuocGias] = useState([]);
    const [tinhThanhs, setTinhThanhs] = useState([]);
    
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

    useEffect(() => {
        if (quanHuyen.quocGiaId) {
            listTinhThanhByQuocGia(quanHuyen.quocGiaId)
                .then(response => {
                    setTinhThanhs(response.data);
                    setQuanHuyen(prevState => ({ ...prevState, tinhThanhId: '' }));
                })
                .catch(error => {
                    console.error('Có lỗi xảy ra khi gọi API:', error);
                });
        } else {
            setTinhThanhs([]);
            setQuanHuyen(prevState => ({ ...prevState, tinhThanhId: ''}));
        }
    }, [quanHuyen.quocGiaId]);
    
    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        setQuanHuyen({
            ...quanHuyen,
            [name]: type === 'checkbox' ? checked : value
        });
    };
    
    const handleSubmit = async (e) => {
        e.preventDefault();
        
        try {
            await addQuanHuyen(quanHuyen);
            navigate('/quan-huyen');
        } catch (error) {
            console.error("Error adding QuanHuyen:", error.response ? error.response.data : error.message);
            setError('Có lỗi xảy ra khi thêm quận huyện.');
        }
    };
    
    return (
    <div className="container mx-auto" style={{ minHeight:'calc(100vh - 130px)' }}>
            <div className="card bg-white shadow-md p-6 mt-6 mb-6 mx-auto w-full md:w-1/2 lg:w-1/2 rounded-lg">
                <h2 className="text-3xl font-bold text-center mb-6">Thêm mới Quận/Huyện</h2>
                <form onSubmit={handleSubmit}>
                    {error && <div className="bg-red-100 text-red-700 p-4 rounded mb-4">{error}</div>}
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Tên quận huyện</label>
                        <input 
                            type="text" 
                            className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            name="tenQuanHuyen"
                            value={quanHuyen.tenQuanHuyen} 
                            onChange={handleChange} 
                            required 
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Mô tả</label>
                        <textarea 
                            className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                            name="moTa"
                            value={quanHuyen.moTa} 
                            onChange={handleChange} 
                            required 
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Thuộc quốc gia</label>
                        <select 
                            className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                            name="quocGiaId"
                            value={quanHuyen.quocGiaId}
                            onChange={handleChange} 
                            required
                        >
                            <option value="">Chọn quốc gia</option>
                            {quocGias.map(quocGia => (
                                <option key={quocGia.id} value={quocGia.id}>{quocGia.tenQuocGia}</option>
                            ))}
                        </select>
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Thuộc tỉnh/thành phố</label>
                        <select 
                            className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                            name="tinhThanhId"
                            value={quanHuyen.tinhThanhId}
                            onChange={handleChange} 
                            required
                        >
                            <option value="">Chọn tỉnh thành</option>
                            {tinhThanhs.map(tinhThanh => (
                                <option key={tinhThanh.id} value={tinhThanh.id}>{tinhThanh.tenTinhThanh}</option>
                            ))}
                        </select>
                    </div>
                    <div className="flex justify-between">
                        <button type="submit" className="btn bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline">Lưu</button>
                        <button type="button" className="btn bg-gray-500 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" onClick={() => navigate('/quan-huyen')}>Hủy</button>
                    </div>
                </form>
            </div>
        </div>
    )
}

export default ThemQuanHuyenComponent