import { getQuanHuyenById, updateQuanHuyen } from '@/services/QuanHuyenService';
import { listQuocGia } from '@/services/QuocGiaService';
import { listTinhThanhByQuocGia } from '@/services/TinhThanhService';
import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';

const SuaQuanHuyenComponent = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const [quanHuyen, setQuanHuyen] = useState({
        tenQuanHuyen: '',
        moTa: '',
        quocGiaId: '',
        tinhThanhId: ''
    });
    const [quocGias, setQuocGias] = useState([]);
    const [tinhThanhs, setTinhThanhs] = useState([]);
    const [error, setError] = useState('');

    useEffect(() => {
        // Fetch QuocGia data
        listQuocGia()
            .then(response => {
                setQuocGias(response.data.data);
            })
            .catch(error => {
                console.error('Có lỗi xảy ra khi gọi API:', error);
                setError('Có lỗi xảy ra khi tải danh sách quốc gia.');
            });

        // Fetch QuanHuyen data
        getQuanHuyenById(id)
            .then(response => {
                setQuanHuyen(response.data);
            })
            .catch(error => {
                console.error('Có lỗi xảy ra khi lấy dữ liệu:', error);
                setError('Có lỗi xảy ra khi tải thông tin quận huyện.');
            });
    }, [id]);

    useEffect(() => {
        if (quanHuyen.quocGiaId) {
            listTinhThanhByQuocGia(quanHuyen.quocGiaId)
                .then(response => {
                    setTinhThanhs(response.data);
                })
                .catch(error => {
                    console.error('Có lỗi xảy ra khi gọi API:', error);
                    setError('Có lỗi xảy ra khi tải danh sách tỉnh thành.');
                });
        } else {
            setTinhThanhs([]);
        }
    }, [quanHuyen.quocGiaId]);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setQuanHuyen({
            ...quanHuyen,
            [name]: value
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setError(''); // Reset error message
        try {
            await updateQuanHuyen(id, quanHuyen);
            navigate('/quan-huyen');
        } catch (error) {
            console.error("Error updating QuanHuyen:", error.response ? error.response.data : error.message);
            setError('Có lỗi xảy ra khi cập nhật quận huyện.');
        }
    };

    return (
        <div className="container mx-auto mt-5" style={{ minHeight: 'calc(100vh - 130px)' }}>
            <div className="card p-4 mt-4 mb-3 w-1/2 mx-auto shadow-lg rounded-lg">
                <h2 className="text-3xl font-bold text-center mb-4">Sửa thông tin Quận/Huyện</h2>
                {error && <div className="mb-4 p-2 bg-red-100 text-red-700 rounded-md">{error}</div>}
                <form onSubmit={handleSubmit}>
                    <div className="mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2">Tên quận huyện</label>
                        <input
                            type="text"
                            className="form-input w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="tenQuanHuyen"
                            value={quanHuyen.tenQuanHuyen}
                            onChange={handleChange}
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 text-sm font-bold mb-2">Mô tả</label>
                        <textarea
                            className="form-textarea w-full px-3 py-2 border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring focus:ring-blue-500"
                            name="moTa"
                            value={quanHuyen.moTa}
                            onChange={handleChange}
                        ></textarea>
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Thuộc quốc gia</label>
                        <select
                            className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            name="quocGiaId"
                            value={quanHuyen.quocGiaId}
                            onChange={handleChange}
                            disabled
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
                            <option value="">Chọn tỉnh/thành</option>
                            {tinhThanhs.map(tinhThanh => (
                                <option key={tinhThanh.id} value={tinhThanh.id}>{tinhThanh.tenTinhThanh}</option>
                            ))}
                        </select>
                    </div>
                    <div className="flex justify-between">
                        <button type="submit" className="btn bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">Cập nhật</button>
                        <button type="button" className="btn bg-gray-500 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" onClick={() => navigate('/quan-huyen')}>Hủy</button>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default SuaQuanHuyenComponent;
