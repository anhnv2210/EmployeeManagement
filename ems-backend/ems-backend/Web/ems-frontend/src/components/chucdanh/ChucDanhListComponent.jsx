import React, { useEffect, useState } from 'react';
import { deleteChucDanh, listChucDanh } from '../../services/ChucDanhService';
import { format } from 'date-fns';
import { Link, useNavigate } from 'react-router-dom';

const ChucDanhListComponent = () => {
    const [chucDanhs, setChucDanhs] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        listChucDanh().then((response) => {
            setChucDanhs(response.data);
        }).catch(error => {
            console.error(error);
        });
    }, []);

    const handleDelete = (id) => {
        if (window.confirm("Bạn có chắc chắn muốn xóa chức danh này?")) {
            deleteChucDanh(id).then(() => {
                setChucDanhs(chucDanhs.filter(cd => cd.id !== id));
            }).catch(error => {
                console.error("Error deleting ChucDanh:", error.response ? error.response.data : error.message);
            });
        }
    };

    const themChucDanh = () => {
        navigate('/them-chuc-danh');
    };

    return (
        <div className="container mx-auto mt-5 min-h-screen">
            <h2 className="text-3xl font-bold text-center mb-6">Danh sách Chức Danh</h2>
            <button className="inline-block mb-3 rounded-sm bg-gradient-to-r from-blue-500 to-purple-500 px-8 py-2.5 text-base font-semibold text-white shadow-lg transition duration-300 ease-in-out transform hover:scale-105 hover:from-blue-600 hover:to-purple-600 focus:outline-none focus:ring-4 focus:ring-blue-300 active:scale-95" onClick={themChucDanh}>Thêm mới</button>
            <table className="min-w-full bg-white border border-gray-200 rounded-lg overflow-hidden">
                <thead className="bg-gray-200 text-gray-600">
                    <tr className="text-center">
                        <th className="py-2 px-4 border-b">Id</th>
                        <th className="py-2 px-4 border-b">Tên chức danh</th>
                        <th className="py-2 px-4 border-b">Mô tả</th>
                        <th className="py-2 px-4 border-b">Người tạo</th>
                        <th className="py-2 px-4 border-b">Ngày tạo</th>
                        <th className="py-2 px-4 border-b">Người cập nhật</th>
                        <th className="py-2 px-4 border-b">Ngày cập nhật</th>
                        <th className="py-2 px-4 border-b">Trạng thái</th>
                        <th className="py-2 px-4 border-b">Action</th>
                    </tr>
                </thead>
                <tbody>
                    {chucDanhs.map(chucDanh => (
                        <tr key={chucDanh.id}>
                            <td className="text-center py-2 px-4 border-b">{chucDanh.id}</td>
                            <td className="py-2 px-4 border-b">{chucDanh.tenChucDanh}</td>
                            <td className="py-2 px-4 border-b">{chucDanh.moTa}</td>
                            <td className="py-2 px-4 border-b">{chucDanh.nguoiTaoHoTen}</td>
                            <td className="text-center py-2 px-4 border-b">{format(new Date(chucDanh.ngayTao), 'dd-MM-yyyy')}</td>
                            <td className="py-2 px-4 border-b">{chucDanh.nguoiCapNhatHoTen}</td>
                            <td className="text-center py-2 px-4 border-b">{format(new Date(chucDanh.ngayCapNhat), 'dd-MM-yyyy')}</td>
                            <td className="py-2 px-4 border-b">{chucDanh.isActive ? "Áp dụng" : "Ngưng áp dụng"}</td>
                            <td className="flex justify-center py-2 px-4 border-b">
                                <Link to={`/sua-chuc-danh/${chucDanh.id}`} className="btn bg-yellow-500 hover:bg-yellow-700 text-white font-bold py-1 px-3 rounded mr-2">Sửa</Link>
                                <button
                                    onClick={() => handleDelete(chucDanh.id)}
                                    className="btn bg-red-500 hover:bg-red-700 text-white font-bold py-1 px-3 rounded"
                                >
                                    Xóa
                                </button>
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>
        </div>
    );
};

export default ChucDanhListComponent;
