import { deleteQuyetDinh, listQuyetDinh } from '@/services/QuyetDinhService';
import { format } from 'date-fns';
import React, { useEffect, useState } from 'react'
import { Link, useNavigate } from 'react-router-dom';

const ListQuyetDinhComponent = () => {
    const [quyetDinhs, setQuyetDinhs] = useState([]);
    const [currentPage, setCurrentPage] = useState(1);
    const [totalRecords, setTotalRecords] = useState(0);
    const pageSize = 10;
    const navigate = useNavigate();

    useEffect(() => {
        const fetchQuyetDinhs = () => {
            listQuyetDinh(pageSize, currentPage)
                .then((response) => {
                    setQuyetDinhs(response.data.data);
                    setTotalRecords(response.data.totalItems);
                })
                .catch((error) => {
                    console.error('Error fetching HopDongs:', error);
                });
        };
        fetchQuyetDinhs();
    }, [currentPage]);

    const themQuyetDinh = () => navigate('/them-quyet-dinh');

    const handlePageChange = (page) => setCurrentPage(page);

    const handleDelete = (id) => {
        if (window.confirm('Bạn có chắc chắn muốn xóa quyết định này?')) {
            deleteQuyetDinh(id)
                .then(() => {
                    setQuyetDinhs(quyetDinhs.filter(quyetDinh => quyetDinh.id !== id));
                })
                .catch((error) => {
                    console.error('Error deleting QuyetDinhs:', error.response ? error.response.data : error.message);
                });
        }
    };

    return (
        <div className="bg-gray-50 pt-5 pb-5">
            <div className="container" style={{ minHeight: 'calc(100vh - 190px)' }}>
                <h2 className="text-3xl font-bold text-center mb-2">Danh sách Quyết định</h2>
                <div className="flex justify-between mb-4">
                    <button
                        className="inline-block mb-3 rounded-sm bg-gradient-to-r from-blue-500 to-purple-500 px-8 py-2.5 text-base font-semibold text-white shadow-lg transition duration-300 ease-in-out transform hover:scale-105 hover:from-blue-600 hover:to-purple-600 focus:outline-none focus:ring-4 focus:ring-blue-300 active:scale-95"
                        onClick={themQuyetDinh}
                    >
                        Thêm mới
                    </button>
                </div>
                <table className="min-w-full bg-white border border-gray-200 rounded-lg overflow-hidden">
                    <thead className="bg-gray-200 text-gray-600">
                        <tr className="text-center">
                            {['Id', 'Nội dung', 'Ngày quyết định', 'Nhân viên', 'Hồ sơ lương', 'Action'].map((header, index) => (
                                <th key={index} className="py-2 px-4 border-b">{header}</th>
                            ))}
                        </tr>
                    </thead>
                    <tbody>
                        {quyetDinhs.length > 0 ? (
                            quyetDinhs.map((quyetDinh) => (
                                <tr key={quyetDinh.id}>
                                    <td className="text-center py-2 px-4 border-b-2">{quyetDinh.id}</td>
                                    <td className="text-center py-2 px-4 border-b">{quyetDinh.noiDung}</td>
                                    <td className="text-center py-2 px-4 border-b">{format(new Date(quyetDinh.ngayQuyetDinh), 'dd-MM-yyyy')}</td>
                                    <td className="text-center py-2 px-4 border-b">{quyetDinh.hoTenNhanVien}</td>
                                    <td className="text-center py-2 px-4 border-b">{quyetDinh.tenNhanVienKemChucDanh}</td>
                                    <td className="flex justify-center py-2 px-4 border-b">
                                        <Link to={`/sua-quyet-dinh/${quyetDinh.id}`} className="btn bg-yellow-500 hover:bg-yellow-700 text-white font-medium py-1 px-3 rounded mr-2">Sửa</Link>
                                        <button
                                            onClick={() => handleDelete(quyetDinh.id)}
                                            className="btn bg-red-500 hover:bg-red-700 text-white font-bold py-1 px-3 rounded"
                                        >
                                            Xóa
                                        </button>
                                        <Link to={`/them-hop-dong`} className="btn bg-green-500 hover:bg-green-700 text-white font-medium py-1 px-3 rounded ml-2">Thêm hợp đồng</Link>
                                    </td>
                                </tr>
                            ))
                        ) : (
                            <tr>
                                <td colSpan="10" className="text-center py-4">Không có dữ liệu.</td>
                            </tr>
                        )}
                    </tbody>
                </table>
                <div className="flex justify-center mt-4 mb-4">
                    {totalRecords > 0 && (
                        <div className="flex space-x-2">
                            {Array.from({ length: Math.max(Math.ceil(totalRecords / pageSize), 1) }, (_, index) => (
                                <button
                                    key={index}
                                    className={`mx-1 px-2 py-2 border rounded-sm transition-all duration-300 ${
                                        currentPage === index + 1
                                            ? 'bg-blue-500 text-white shadow-lg'
                                            : 'bg-white text-gray-700 hover:bg-blue-500 hover:text-white hover:shadow-lg'
                                    }`}
                                    onClick={() => handlePageChange(index + 1)}
                                >
                                    {index + 1}
                                </button>
                            ))}
                        </div>
                    )}
                </div>
            </div>
        </div>
    );
}

export default ListQuyetDinhComponent