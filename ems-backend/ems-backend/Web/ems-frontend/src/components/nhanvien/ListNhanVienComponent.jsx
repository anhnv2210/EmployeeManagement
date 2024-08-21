import { listNhanVien } from '@/services/NhanVienService';
import { format } from 'date-fns';
import React, { useEffect, useState } from 'react';
import { Link, useNavigate } from 'react-router-dom';

const ListNhanVienComponent = () => {
    const [nhanViens, setNhanViens] = useState([]);
    const [statusFilter, setStatusFilter] = useState('');
    const [isDropdownOpen, setIsDropdownOpen] = useState(false);
    const [currentPage, setCurrentPage] = useState(1);
    const [totalRecords, setTotalRecords] = useState(0);
    const pageSize = 10;
    const navigate = useNavigate();

    useEffect(() => {
        const fetchNhanViens = () => {
            listNhanVien(statusFilter, pageSize, currentPage)
                .then((response) => {
                    setNhanViens(response.data.data);
                    setTotalRecords(response.data.totalItems);
                })
                .catch((error) => {
                    console.error('Error fetching NhanViens:', error);
                });
        };
        fetchNhanViens();
    }, [statusFilter, currentPage]);

    const themNhanVien = () => navigate('/them-nhan-vien');

    const toggleDropdown = () => setIsDropdownOpen(!isDropdownOpen);

    const handleFilterClick = (filter) => {
        setStatusFilter(filter);
        setCurrentPage(1);
        setIsDropdownOpen(false);
    };

    const handlePageChange = (page) => setCurrentPage(page);

    return (
        <div className="bg-gray-50 pt-5 pb-5">
            <div className="mx-5" style={{ minHeight: 'calc(100vh - 190px)' }}>
                <h2 className="text-3xl font-bold text-center mb-2">Danh sách Hồ sơ nhân viên</h2>
                <div className="flex justify-between mb-4">
                    <button
                        className="inline-block mb-3 rounded-sm bg-gradient-to-r from-blue-500 to-purple-500 px-8 py-2.5 text-base font-semibold text-white shadow-lg transition duration-300 ease-in-out transform hover:scale-105 hover:from-blue-600 hover:to-purple-600 focus:outline-none focus:ring-4 focus:ring-blue-300 active:scale-95"
                        onClick={themNhanVien}
                    >
                        Thêm mới
                    </button>
                    <div className="relative inline-block text-left ml-4">
                        <button
                            className="inline-flex w-full justify-center rounded-md border border-gray-300 bg-white px-4 py-2 text-base font-medium text-gray-700 shadow-sm ring-1 ring-gray-300 hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-blue-500"
                            onClick={toggleDropdown}
                        >
                            {statusFilter === '' ? 'Trạng Thái' : statusFilter}
                            <svg className="-mr-1 ml-2 h-5 w-5" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20" fill="currentColor" aria-hidden="true">
                                <path fillRule="evenodd" d="M6.293 9.293a1 1 0 011.414 0L10 10.586l2.293-2.293a1 1 0 111.414 1.414l-3 3a1 1 0 01-1.414 0l-3-3a1 1 0 010-1.414z" clipRule="evenodd" />
                            </svg>
                        </button>
                        {isDropdownOpen && (
                            <div className="absolute right-0 z-10 mt-2 w-44 origin-top-right rounded-md bg-white shadow-lg ring-1 ring-black ring-opacity-5 focus:outline-none">
                                <div className="p-1">
                                    {['', 'Đã làm việc', 'Không còn làm việc'].map((filter, index) => (
                                        <button
                                            key={index}
                                            className="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100 w-full text-left"
                                            onClick={() => handleFilterClick(filter)}
                                        >
                                            {filter === '' ? 'Tất cả' : filter}
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
                            {['Id', 'Tên nhân viên', 'Giới tính', 'Ngày sinh', 'Email', 'Số điện thoại','Phòng ban','Chức danh', 'Trạng thái', 'Action'].map((header, index) => (
                                <th key={index} className="py-2 px-4 border-b">{header}</th>
                            ))}
                        </tr>
                    </thead>
                    <tbody>
                        {nhanViens.length > 0 ? (
                            nhanViens.map((nhanVien) => (
                                <tr key={nhanVien.id}>
                                    <td className="text-center py-2 px-4 border-b-2">{nhanVien.id}</td>
                                    <td className="text-center py-2 px-4 border-b">{nhanVien.hoTen}</td>
                                    <td className="text-center py-2 px-4 border-b">{nhanVien.gioiTinh ? "Nam" : "Nữ"}</td>
                                    <td className="text-center py-2 px-4 border-b">{format(new Date(nhanVien.ngaySinh), 'dd-MM-yyyy')}</td>
                                    <td className="text-center py-2 px-4 border-b">{nhanVien.email}</td>
                                    <td className="text-center py-2 px-4 border-b">{nhanVien.soDienThoai}</td>
                                    <td className="text-center py-2 px-4 border-b">{nhanVien.tenPhongBan}</td>
                                    <td className="text-center py-2 px-4 border-b">{nhanVien.tenChucDanh}</td>
                                    <td className="text-center py-2 px-4 border-b">{nhanVien.trangThai}</td>
                                    <td className="flex justify-center py-2 px-4 border-b">
                                        <Link to={`/thong-tin-nhan-vien/${nhanVien.id}`} className="btn bg-cyan-500 hover:bg-cyan-700 text-white font-medium py-1 px-3 rounded mr-2">Xem chi tiết</Link>
                                        <Link to={`/sua-nhan-vien/${nhanVien.id}`} className="btn bg-yellow-500 hover:bg-yellow-700 text-white font-medium py-1 px-3 rounded mr-2">Sửa</Link>
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
};

export default ListNhanVienComponent;
