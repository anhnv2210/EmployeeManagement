import { listQuanHuyenByTinhThanh } from '@/services/QuanHuyenService';
import { listQuocGia } from '@/services/QuocGiaService';
import { listTinhThanhByQuocGia } from '@/services/TinhThanhService';
import { getXaPhuongById, updateXaPhuong } from '@/services/XaPhuongService';
import React, { useEffect, useState } from 'react';
import { useNavigate, useParams } from 'react-router-dom';

const SuaXaPhuongComponent = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const [xaPhuong, setXaPhuong] = useState({
        tenXaPhuong: '',
        moTa: '',
        quocGiaId: '',
        tinhThanhId: '',
        quanHuyenId: ''
    });
    const [quocGias, setQuocGias] = useState([]);
    const [tinhThanhs, setTinhThanhs] = useState([]);
    const [quanHuyens, setQuanHuyens] = useState([]);
    const [error, setError] = useState('');

    useEffect(() => {
        listQuocGia()
            .then(response => {
                setQuocGias(response.data.data);
            })
            .catch(error => {
                console.error('Có lỗi xảy ra khi gọi API:', error);
            });

        getXaPhuongById(id)
            .then(response => {
                setXaPhuong(response.data);
            })
            .catch(error => {
                console.error('Có lỗi xảy ra khi lấy dữ liệu:', error);
            });
    }, [id]);

    useEffect(() => {
        if (xaPhuong.quocGiaId) {
            listTinhThanhByQuocGia(xaPhuong.quocGiaId)
                .then(response => {
                    setTinhThanhs(response.data);
                })
                .catch(error => {
                    console.error('Có lỗi xảy ra khi gọi API:', error);
                });
        } else {
            setTinhThanhs([]);
        }
    }, [xaPhuong.quocGiaId]);

    useEffect(() => {
        if (xaPhuong.tinhThanhId) {
            listQuanHuyenByTinhThanh(xaPhuong.tinhThanhId)
                .then(response => {
                    setQuanHuyens(response.data);
                })
                .catch(error => {
                    console.error('Có lỗi xảy ra khi gọi API:', error);
                });
        } else {
            setQuanHuyens([]);
        }
    }, [xaPhuong.tinhThanhId]);

    const handleChange = (e) => {
        const { name, value } = e.target;
        setXaPhuong({
            ...xaPhuong,
            [name]: value
        });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            await updateXaPhuong(id, xaPhuong);
            navigate('/xa-phuong');
        } catch (error) {
            console.error("Error updating XaPhuong:", error.response ? error.response.data : error.message);
            setError('Có lỗi xảy ra khi cập nhật xã phường.');
        }
    };

    return (
        <div className="container mx-auto" style={{ minHeight: 'calc(100vh - 130px)' }}>
            <div className="card bg-white shadow-md p-6 mt-6 mb-6 mx-auto w-full md:w-1/2 lg:w-1/2 rounded-lg">
                <h2 className="text-3xl font-bold text-center mb-6">Sửa Xã/Phường</h2>
                <form onSubmit={handleSubmit}>
                    {error && <div className="bg-red-100 text-red-700 p-4 rounded mb-4">{error}</div>}
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Tên xã phường</label>
                        <input
                            type="text"
                            className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            name="tenXaPhuong"
                            value={xaPhuong.tenXaPhuong}
                            onChange={handleChange}
                            required
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Mô tả</label>
                        <textarea
                            className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            name="moTa"
                            value={xaPhuong.moTa}
                            onChange={handleChange}
                            required
                        />
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Thuộc quốc gia</label>
                        <select
                            className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            name="quocGiaId"
                            value={xaPhuong.quocGiaId}
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
                            value={xaPhuong.tinhThanhId}
                            onChange={handleChange}
                            required
                        >
                            <option value="">Chọn tỉnh/thành</option>
                            {tinhThanhs.map(tinhThanh => (
                                <option key={tinhThanh.id} value={tinhThanh.id}>{tinhThanh.tenTinhThanh}</option>
                            ))}
                        </select>
                    </div>
                    <div className="mb-4">
                        <label className="block text-gray-700 font-bold mb-2">Thuộc quận/huyện</label>
                        <select
                            className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                            name="quanHuyenId"
                            value={xaPhuong.quanHuyenId}
                            onChange={handleChange}
                            required
                        >
                            <option value="">Chọn quận/huyện</option>
                            {quanHuyens.map(qh => (
                                <option key={qh.id} value={qh.id}>{qh.tenQuanHuyen}</option>
                            ))}
                        </select>
                    </div>
                    <div className="flex justify-between">
                        <button type="submit" className="btn bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline">Lưu</button>
                        <button type="button" className="btn bg-gray-500 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" onClick={() => navigate('/xa-phuong')}>Hủy</button>
                    </div>
                </form>
            </div>
        </div>
    );
}

export default SuaXaPhuongComponent;