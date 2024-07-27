import { deletePhucLoi, listPhucLoi } from '@/services/PhucLoiService';
import { format } from 'date-fns';
import React, { useEffect, useState } from 'react'
import { Link, useNavigate } from 'react-router-dom';

const ListPhucLoiComponent = () => {
    const [phucLois, setPhucLois] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        listPhucLoi().then((response) => {
            setPhucLois(response.data);
        }).catch(error => {
            console.error(error);
        });
    }, []);

    const handleDelete = (id) => {
        if (window.confirm("Bạn có chắc chắn muốn xóa phúc lợi này?")) {
            deletePhucLoi(id).then(() => {
                setPhucLois(phuCaps.filter(pl => pl.id !== id));
            }).catch(error => {
                console.error("Error deleting PhucLoi:", error.response ? error.response.data : error.message);
            });
        }
    };

    const themPhucLoi = () => {
        navigate('/them-phuc-loi');
    };

    return (
        <div className="container mx-auto mt-5 min-h-screen">
            <h2 className="text-3xl font-bold text-center mb-6">Danh sách Phúc Lợi</h2>
            <button className="inline-block mb-3 rounded-sm bg-gradient-to-r from-blue-500 to-purple-500 px-8 py-2.5 text-base font-semibold text-white shadow-lg transition duration-300 ease-in-out transform hover:scale-105 hover:from-blue-600 hover:to-purple-600 focus:outline-none focus:ring-4 focus:ring-blue-300 active:scale-95" onClick={themPhucLoi}>Thêm mới</button>
            <table className="min-w-full bg-white border border-gray-200 rounded-lg overflow-hidden">
                <thead className="bg-gray-200 text-gray-600">
                    <tr className="text-center">
                        <th className="py-2 px-4 border-b">Id</th>
                        <th className="py-2 px-4 border-b">Tên phúc lợi</th>
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
                    {phucLois.map(phucLoi => (
                        <tr key={phucLoi.id}>
                            <td className="text-center py-2 px-4 border-b">{phucLoi.id}</td>
                            <td className="text-center py-2 px-4 border-b">{phucLoi.tenPhucLoi}</td>
                            <td className="py-2 px-4 border-b">{phucLoi.moTa}</td>
                            <td className="text-center py-2 px-4 border-b">{phucLoi.nguoiTaoHoTen}</td>
                            <td className="text-center py-2 px-4 border-b">{format(new Date(phucLoi.ngayTao), 'dd-MM-yyyy')}</td>
                            <td className="text-center py-2 px-4 border-b">{phucLoi.nguoiCapNhatHoTen}</td>
                            <td className="text-center py-2 px-4 border-b">{format(new Date(phucLoi.ngayCapNhat), 'dd-MM-yyyy')}</td>
                            <td className="py-2 px-4 border-b">{phucLoi.isActive ? "Áp dụng" : "Ngưng áp dụng"}</td>
                            <td className="flex justify-center py-2 px-4 border-b">
                                <Link to={`/sua-phuc-loi/${phucLoi.id}`} className="btn bg-yellow-500 hover:bg-yellow-700 text-white font-bold py-1 px-3 rounded mr-2">Sửa</Link>
                                <button
                                    onClick={() => handleDelete(phucLoi.id)}
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
}

export default ListPhucLoiComponent