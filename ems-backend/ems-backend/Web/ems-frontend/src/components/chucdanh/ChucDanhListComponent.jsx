import React, { useEffect, useState } from 'react';
import { deleteChucDanh, listChucDanh } from '../../services/ChucDanhService';
import { format } from 'date-fns';
import { Link, useNavigate } from 'react-router-dom';

const ChucDanhListComponent = () => {
    const [chucDanhs, setChucDanhs] = useState([]);
    const [statusFilter, setStatusFilter] = useState('');
    const [isDropdownOpen, setIsDropdownOpen] = useState(false);
    const [currentPage, setCurrentPage] = useState(1);
    const [totalRecords, setTotalRecords] = useState(0);
    const pageSize = 10;
    const navigate = useNavigate(); 

    useEffect(() => {
        const fetchChucDanhs = () => {
            listChucDanh(statusFilter, pageSize, currentPage)
                .then((response) => {
                    setChucDanhs(response.data.data);
                    setTotalRecords(response.data.totalItems);
                })
                .catch((error) => {
                    console.error('Error fetching ChucDanhs:', error);
                });
        };
        fetchChucDanhs();
    }, [statusFilter, currentPage]);

    const handleDelete = (id) => {
        if (window.confirm('Bạn có chắc chắn muốn xóa chức danh này?')) {
            deleteChucDanh(id)
                .then(() => {
                    setChucDanhs(chucDanhs.filter(chucDanh => chucDanh.id !== id));
                })
                .catch((error) => {
                    console.error('Error deleting ChucDanh:', error.response ? error.response.data : error.message);
                });
        }
    };

    const themChucDanh = () => navigate('/them-chuc-danh');

    const toggleDropdown = () => setIsDropdownOpen(!isDropdownOpen);

    const handleFilterClick = (filter) => {
        setStatusFilter(filter);
        setCurrentPage(1);
        setIsDropdownOpen(false);
    };

    const handlePageChange = (page) => setCurrentPage(page);

    return (
        <div className="container mx-auto mt-5" style={{ minHeight: 'calc(100vh - 190px)' }}>
            <h2 className="text-3xl font-bold text-center mb-6">Danh sách Chức Danh</h2>
            <div className="flex justify-between mb-4">
                <button
                    className="inline-block mb-3 rounded-sm bg-gradient-to-r from-blue-500 to-purple-500 px-8 py-2.5 text-base font-semibold text-white shadow-lg transition duration-300 ease-in-out transform hover:scale-105 hover:from-blue-600 hover:to-purple-600 focus:outline-none focus:ring-4 focus:ring-blue-300 active:scale-95"
                    onClick={themChucDanh}
                >
                    Thêm mới
                </button>
                <div className="relative inline-block text-left ml-4">
                    <button 
                        className="inline-flex w-full justify-center rounded-md border border-gray-300 bg-white px-4 py-2 text-base font-medium text-gray-700 shadow-sm ring-1 ring-gray-300 hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-blue-500"
                        onClick={toggleDropdown}
                    >
                        {statusFilter === '' ? 'Tất cả' : statusFilter === 'True' ? 'Áp dụng' : 'Ngưng áp dụng'}
                        <svg className="-mr-1 ml-2 h-5 w-5" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                            <path fillRule="evenodd" d="M6.293 9.293a1 1 0 011.414 0L10 10.586l2.293-2.293a1 1 0 111.414 1.414l-3 3a1 1 0 01-1.414 0l-3-3a1 1 0 010-1.414z" clipRule="evenodd" />
                        </svg>
                    </button>
                    {isDropdownOpen && (
                        <div className="absolute right-0 z-10 mt-2 w-36 origin-top-right rounded-md bg-white shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none">
                            <div className="p-1">
                                {['', 'True', 'False'].map((filter, index) => (
                                    <button 
                                        key={index}
                                        className="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100 w-full text-left"
                                        onClick={() => handleFilterClick(filter)}
                                    >
                                        {filter === '' ? 'Tất cả' : filter === 'True' ? 'Áp dụng' : 'Ngưng áp dụng'}
                                    </button>
                                ))}
                            </div>
                        </div>
                    )}
                </div>
            </div>
            <table className="min-w-full bg-white border border-gray-200 rounded-lg overflow-hidden">
                <thead className="bg-gray-200 text-gray-600">
                    <tr className="text-center">
                        {['Id', 'Tên chức danh', 'Mô tả', 'Người tạo', 'Ngày tạo', 'Người cập nhật', 'Ngày cập nhật', 'Trạng thái', 'Action'].map((header, index) => (
                            <th key={index} className="py-2 px-4 border-b">{header}</th>
                        ))}
                    </tr>
                </thead>
                <tbody>
                    {chucDanhs.length > 0 ? chucDanhs.map((chucDanh) => (
                        <tr key={chucDanh.id}>
                            <td className="text-center py-2 px-4 border-b-2">{chucDanh.id}</td>
                            <td className="py-2 px-4 border-b">{chucDanh.tenChucDanh}</td>
                            <td className="py-2 px-4 border-b">{chucDanh.moTa}</td>
                            <td className="text-center py-2 px-4 border-b">{chucDanh.nguoiTaoHoTen}</td>
                            <td className="text-center py-2 px-4 border-b">{format(new Date(chucDanh.ngayTao), 'dd-MM-yyyy')}</td>
                            <td className="text-center py-2 px-4 border-b">{chucDanh.nguoiCapNhatHoTen}</td>
                            <td className="text-center py-2 px-4 border-b">{format(new Date(chucDanh.ngayCapNhat), 'dd-MM-yyyy')}</td>
                            <td className="text-center py-2 px-4 border-b">{chucDanh.isActive ? 'Áp dụng' : 'Ngưng áp dụng'}</td>
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
    );
};

export default ChucDanhListComponent;
