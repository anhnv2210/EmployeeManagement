import { deleteChiNhanhNganHang, listChiNhanhNganHang } from '@/services/ChiNhanhNganHangService';
import { listNganHang } from '@/services/NganHangService';
import { format } from 'date-fns';
import React, { useEffect, useState } from 'react'
import { Link, useNavigate } from 'react-router-dom';

const ListChiNhanhNganHangComponent = () => {
    const [chiNhanhNganHangs, setChiNhanhNganHangs] = useState([]);
    const [nganHangs, setNganHangs] = useState([]);
    const [statusFilter, setStatusFilter] = useState('');
    const [isDropdownOpen, setIsDropdownOpen] = useState(false);
    const [currentPage, setCurrentPage] = useState(1);
    const [totalRecords, setTotalRecords] = useState(0);
    const pageSize = 10;
    const navigate = useNavigate();

    useEffect(() => {
        const fetchChiNhanhNganHangs = () => {
            listChiNhanhNganHang(statusFilter, pageSize, currentPage)
                .then((response) => {
                    setChiNhanhNganHangs(response.data.data);
                    setTotalRecords(response.data.totalItems);
                })
                .catch((error) => {
                    console.error('Error fetching NganHangs:', error);
                });
        };
        fetchChiNhanhNganHangs();
    }, [statusFilter, currentPage]);

    const handleDelete = (id) => {
        if (window.confirm("Bạn có chắc chắn muốn xóa chi nhánh ngân hàng này?")) {
            deleteChiNhanhNganHang(id).then(() => {
                setChiNhanhNganHangs(chiNhanhNganHangs.filter(cnnh => cnnh.id !== id));
            }).catch(error => {
                console.error("Error deleting ChiNhanhNganHang:", error.response ? error.response.data : error.message);
            });
        }
    };

    const themChiNhanhNganHang = () => {
        navigate('/them-chi-nhanh-ngan-hang');
    };

    const toggleDropdown = () => setIsDropdownOpen(!isDropdownOpen);

    const handleFilterClick = (filter) => {
        setStatusFilter(filter);
        setCurrentPage(1);
        setIsDropdownOpen(false);
    };

    const handlePageChange = (page) => setCurrentPage(page);

    return (
        <div className="pt-5 m-10 mt-5" style={{ minHeight:'calc(100vh - 130px)' }}>
            <h2 className="text-3xl font-bold text-center mb-6">Danh sách Chi Nhánh Ngân Hàng</h2>
            <div className="flex justify-between mb-4">
                <button
                    className="inline-block mb-3 rounded-sm bg-gradient-to-r from-blue-500 to-purple-500 px-8 py-2.5 text-base font-semibold text-white shadow-lg transition duration-300 ease-in-out transform hover:scale-105 hover:from-blue-600 hover:to-purple-600 focus:outline-none focus:ring-4 focus:ring-blue-300 active:scale-95"
                    onClick={themChiNhanhNganHang}
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
            <table className="min-w-full bg-white border-2 border-gray-200 rounded-lg overflow-hidden text-xs">
                <thead className="bg-gray-200 text-gray-600">
                    <tr className="text-center">
                        <th className="py-2 px-4 border-b">Id</th>
                        <th className="py-2 px-4 border-b">Tên chi nhánh ngân hàng</th>
                        <th className="py-2 px-4 border-b">Địa chỉ</th>
                        <th className="py-2 px-4 border-b">Email</th>
                        <th className="py-2 px-4 border-b">Số điện thoại</th>
                        <th className="py-2 px-4 border-b">Mô tả</th>
                        <th className="py-2 px-4 border-b">Thuộc Ngân hàng</th>
                        <th className="py-2 px-4 border-b">Người tạo</th>
                        <th className="py-2 px-4 border-b">Ngày tạo</th>
                        <th className="py-2 px-4 border-b">Người cập nhật</th>
                        <th className="py-2 px-4 border-b">Ngày cập nhật</th>
                        <th className="py-2 px-4 border-b">Trạng thái</th>
                        <th className="py-2 px-4 border-b">Action</th>
                    </tr>
                </thead>
                <tbody>
                    {chiNhanhNganHangs.length > 0?chiNhanhNganHangs.map(chiNhanhNganHang => (
                        <tr key={chiNhanhNganHang.id}>
                            <td className="text-center py-2 px-2 border-b-2">{chiNhanhNganHang.id}</td>
                            <td className="text-center py-2 px-2 border-b">{chiNhanhNganHang.tenChiNhanhNganHang}</td>
                            <td className="text-center py-2 px-2 border-b">{chiNhanhNganHang.diaChi}</td>
                            <td className="text-center py-2 px-2 border-b">{chiNhanhNganHang.email}</td>
                            <td className="text-center py-2 px-2 border-b">{chiNhanhNganHang.soDienThoai}</td>
                            <td className="text-center py-2 px-2 border-b">{chiNhanhNganHang.moTa}</td>
                            <td className="text-center py-2 px-2 border-b">{chiNhanhNganHang.nganHangTen}</td>
                            <td className="text-center py-2 px-2 border-b">{chiNhanhNganHang.nguoiTaoHoTen}</td>
                            <td className="text-center py-2 px-2 border-b">{format(new Date(chiNhanhNganHang.ngayTao), 'dd-MM-yyyy')}</td>
                            <td className="text-center py-2 px-2 border-b">{chiNhanhNganHang.nguoiCapNhatHoTen}</td>
                            <td className="text-center py-2 px-2 border-b">{format(new Date(chiNhanhNganHang.ngayCapNhat), 'dd-MM-yyyy')}</td>
                            <td className="py-2 px-2 border-b">{chiNhanhNganHang.isActive ? "Áp dụng" : "Ngưng áp dụng"}</td>
                            <td className="flex justify-center py-2 px-2">
                                <Link to={`/sua-chi-nhanh-ngan-hang/${chiNhanhNganHang.id}`} className="btn bg-yellow-500 hover:bg-yellow-700 text-white font-bold py-1 px-3 rounded mr-2">Sửa</Link>
                                <button
                                    onClick={() => handleDelete(chiNhanhNganHang.id)}
                                    className="btn bg-red-500 hover:bg-red-700 text-white font-bold py-1 px-3 rounded"
                                >
                                    Xóa
                                </button>
                            </td>
                        </tr>
                    )) : (
                        <tr>
                            <td colSpan="12" className="text-center py-4">Không có dữ liệu.</td>
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
                                className={`mx-1 px-3 py-2 border rounded-sm transition-all duration-300 ${
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
}

export default ListChiNhanhNganHangComponent