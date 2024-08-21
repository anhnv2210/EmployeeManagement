import { listHoSoLuong } from '@/services/HoSoLuongService';
import React, { useEffect, useState } from 'react'
import { Link, useNavigate } from 'react-router-dom';

const ListHoSoLuongComponent = () => {
    const [hoSoLuongs, setHoSoLuongs] = useState([]);
    const [currentPage, setCurrentPage] = useState(1);
    const [totalRecords, setTotalRecords] = useState(0);
    const pageSize = 10;
    const navigate = useNavigate(); 

    useEffect(() => {
        const fetchHoSoLuongs = () => {
            listHoSoLuong(pageSize, currentPage)
                .then((response) => {
                    setHoSoLuongs(response.data.data);
                    setTotalRecords(response.data.totalItems);
                })
                .catch((error) => {
                    console.error('Error fetching HoSoLuongs:', error);
                });
        };
        fetchHoSoLuongs();
    }, [currentPage]);

    const themHoSoLuong = () => navigate('/them-ho-so-luong');

    const handlePageChange = (page) => setCurrentPage(page);

    return (
        <div className='bg-gray-100'>
            <div className="container mx-auto pt-16" style={{ minHeight: 'calc(100vh - 150px)' }}>
                <h2 className="text-3xl font-bold text-center mb-6">Danh sách Hồ sơ lương</h2>
                <div className="flex justify-between mb-4">
                    <button
                        className="inline-block mb-3 rounded-sm bg-gradient-to-r from-blue-500 to-purple-500 px-8 py-2.5 text-base font-semibold text-white shadow-lg transition duration-300 ease-in-out transform hover:scale-105 hover:from-blue-600 hover:to-purple-600 focus:outline-none focus:ring-4 focus:ring-blue-300 active:scale-95"
                        onClick={themHoSoLuong}
                    >
                        Thêm mới
                    </button>
                </div>
                <table className="min-w-full bg-white border border-gray-200 rounded-lg overflow-hidden">
                    <thead className="bg-gray-200 text-gray-600">
                        <tr className="text-center">
                            {['Id', 'Tên nhân viên', 'Thuộc phòng ban', 'Chức danh', 'Thang lương', 'Bậc lương', 'Dải lương', 'Action'].map((header, index) => (
                                <th key={index} className="py-2 px-4 border-b">{header}</th>
                            ))}
                        </tr>
                    </thead>
                    <tbody>
                        {hoSoLuongs.length > 0 ? hoSoLuongs.map((hoSoLuong) => (
                            <tr key={hoSoLuong.id}>
                                <td className="text-center py-2 px-4 border-b-2">{hoSoLuong.id}</td>
                                <td className="text-center py-2 px-4 border-b">{hoSoLuong.hoTenNhanVien}</td>
                                <td className="text-center py-2 px-4 border-b">{hoSoLuong.tenPhongBan}</td>
                                <td className="text-center py-2 px-4 border-b">{hoSoLuong.tenChucDanh}</td>
                                <td className="text-center py-2 px-4 border-b">{hoSoLuong.thangLuong}</td>
                                <td className="text-center py-2 px-4 border-b">{hoSoLuong.bacLuong}</td>
                                <td className="text-center py-2 px-4 border-b">{hoSoLuong.luongMin} - {hoSoLuong.luongMax}</td>
                                <td className="text-center py-2 px-4 border-b">
                                    <Link to={`/ho-so-luong-phu-cap/${hoSoLuong.id}`} className="btn bg-green-500 hover:bg-green-700 text-white font-bold py-1 px-3 rounded mr-2">
                                        Phụ cấp đi kèm
                                    </Link>
                                    <Link to={`/ho-so-luong-phuc-loi/${hoSoLuong.id}`} className="btn bg-blue-500 hover:bg-blue-700 text-white font-bold py-1 px-3 rounded mr-2">
                                        Phúc lợi đi kèm
                                    </Link>
                                </td>
                            </tr>
                        )) : (
                            <tr>
                                <td colSpan="9" className="text-center py-4">Không có dữ liệu.</td>
                            </tr>
                        )}
                    </tbody>
                </table>
                <div className="flex justify-center mt-4">
                    {totalRecords > 0 ? (
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
                    ) : (
                        <p className="text-gray-500 text-lg">Không có trang nào để hiển thị</p>
                    )}
                </div>
            </div>
        </div>
    );
}

export default ListHoSoLuongComponent