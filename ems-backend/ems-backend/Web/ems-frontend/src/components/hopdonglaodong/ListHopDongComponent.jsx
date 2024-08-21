import { deleteHopDong, listHopDong } from '@/services/HopDongService';
import { format } from 'date-fns';
import React, { useEffect, useState } from 'react'
import { Link, useNavigate } from 'react-router-dom';

const ListHopDongComponent = () => {
    const [hopDongs, setHopDongs] = useState([]);
    const [currentPage, setCurrentPage] = useState(1);
    const [totalRecords, setTotalRecords] = useState(0);
    const pageSize = 10;
    const navigate = useNavigate();

    useEffect(() => {
        const fetchHopDongs = () => {
            listHopDong(pageSize, currentPage)
                .then((response) => {
                    setHopDongs(response.data.data);
                    setTotalRecords(response.data.totalItems);
                })
                .catch((error) => {
                    console.error('Error fetching HopDongs:', error);
                });
        };
        fetchHopDongs();
    }, [currentPage]);

    // const themHopDong = () => navigate('/them-quyet-dinh');

    const handlePageChange = (page) => setCurrentPage(page);

    const handleDelete = (id) => {
        if (window.confirm('Bạn có chắc chắn muốn xóa hợp đồng này?')) {
            deleteHopDong(id)
                .then(() => {
                    setHopDongs(hopDongs.filter(hopDong => hopDong.id !== id));
                })
                .catch((error) => {
                    console.error('Error deleting HopDongs:', error.response ? error.response.data : error.message);
                });
        }
    };

    return (
        <div className="bg-gray-50 pt-5 pb-5">
            <div className="container" style={{ minHeight: 'calc(100vh - 190px)' }}>
                <h2 className="text-3xl font-bold text-center mb-2">Danh sách Hợp đồng</h2>
                {/* <div className="flex justify-between mb-4">
                    <button
                        className="inline-block mb-3 rounded-sm bg-gradient-to-r from-blue-500 to-purple-500 px-8 py-2.5 text-base font-semibold text-white shadow-lg transition duration-300 ease-in-out transform hover:scale-105 hover:from-blue-600 hover:to-purple-600 focus:outline-none focus:ring-4 focus:ring-blue-300 active:scale-95"
                        onClick={themQuyetDinh}
                    >
                        Thêm mới
                    </button>
                </div> */}
                <table className="mt-10 min-w-full bg-white border border-gray-200 rounded-lg overflow-hidden">
                    <thead className="bg-gray-200 text-gray-600">
                        <tr className="text-center">
                            {['Id', 'Loại hợp đồng', 'Nhân viên', 'Hồ sơ lương', 'Chi tiết hợp đồng','Ngày bắt đầu','Ngày kết thúc', 'Action'].map((header, index) => (
                                <th key={index} className="py-2 px-4 border-b">{header}</th>
                            ))}
                        </tr>
                    </thead>
                    <tbody>
                        {hopDongs.length > 0 ? (
                            hopDongs.map((hopDong) => (
                                <tr key={hopDong.id}>
                                    <td className="text-center py-2 px-4 border-b-2">{hopDong.id}</td>
                                    <td className="text-center py-2 px-4 border-b">{hopDong.tenLoaiHopDong}</td>
                                    <td className="text-center py-2 px-4 border-b">{hopDong.hoTenNhanVien}</td>
                                    <td className="text-center py-2 px-4 border-b">{hopDong.tenNhanVienKemChucDanh}</td>
                                    <td className="text-center py-2 px-4 border-b">{hopDong.chiTietHopDong}</td>
                                    <td className="text-center py-2 px-4 border-b">{format(new Date(hopDong.ngayBatDau), 'dd-MM-yyyy')}</td>
                                    <td className="text-center py-2 px-4 border-b">{format(new Date(hopDong.ngayKetThuc), 'dd-MM-yyyy')}</td>  
                                    <td className="flex justify-center py-2 px-4 border-b">
                                        <Link to={`/sua-hop-dong/${hopDong.id}`} className="btn bg-yellow-500 hover:bg-yellow-700 text-white font-medium py-1 px-3 rounded mr-2">Sửa</Link>
                                        <button
                                            onClick={() => handleDelete(hopDong.id)}
                                            className="btn bg-red-500 hover:bg-red-700 text-white font-bold py-1 px-3 rounded"
                                        >
                                            Xóa
                                        </button>
                                    </td>
                                </tr>
                            ))
                        ) : (
                            <tr>
                                <td colSpan="10" className="text-center py-4">Không có dữ liệu."Có thể F5 load lại trang ^ ^ ".</td>
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

export default ListHopDongComponent