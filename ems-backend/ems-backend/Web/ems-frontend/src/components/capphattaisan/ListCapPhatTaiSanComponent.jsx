import { deleteCapPhatTaiSan, listCapPhatTaiSan } from '@/services/CapPhatTaiSanService';
import { format } from 'date-fns';
import React, { useEffect, useState } from 'react'
import { Link, useNavigate } from 'react-router-dom';

const ListCapPhatTaiSanComponent = () => {
    const [capPhatTaiSans, setCapPhatTaiSans] = useState([]);
    const [currentPage, setCurrentPage] = useState(1);
    const [totalRecords, setTotalRecords] = useState(0);
    const pageSize = 10;
    const navigate = useNavigate(); 

    useEffect(() => {
        const fetchCapPhatTaiSans = () => {
            listCapPhatTaiSan(pageSize, currentPage)
                .then((response) => {
                    setCapPhatTaiSans(response.data.data);
                    setTotalRecords(response.data.totalItems);
                })
                .catch((error) => {
                    console.error('Error fetching CapPhatTaiSans:', error);
                });
        };
        fetchCapPhatTaiSans();
    }, [currentPage]);

    const handleDelete = (id) => {
        if (window.confirm('Bạn có chắc chắn muốn xóa cấp phát này?')) {
            deleteCapPhatTaiSan(id)
                .then(() => {
                    setCapPhatTaiSans(capPhatTaiSans.filter(cp => cp.id !== id));
                })
                .catch((error) => {
                    console.error('Error deleting CapPhatTaiSan:', error.response ? error.response.data : error.message);
                });
        }
    };

    const themCapPhat = () => navigate('/them-cap-phat');

    const handlePageChange = (page) => setCurrentPage(page);

    return (
        <div className='bg-gray-100'>
            <div className="container mx-auto pt-5" style={{ minHeight: 'calc(100vh - 150px)' }}>
                <h2 className="text-3xl font-bold text-center mb-6">Danh sách Cấp phát tài sản</h2>
                <div className="flex justify-between mb-4">
                    <button
                        className="inline-block mb-3 rounded-sm bg-gradient-to-r from-blue-500 to-purple-500 px-8 py-2.5 text-base font-semibold text-white shadow-lg transition duration-300 ease-in-out transform hover:scale-105 hover:from-blue-600 hover:to-purple-600 focus:outline-none focus:ring-4 focus:ring-blue-300 active:scale-95"
                        onClick={themCapPhat}
                    >
                        Thêm mới
                    </button>
                </div>
                <table className="min-w-full bg-white border border-gray-200 rounded-lg overflow-hidden">
                    <thead className="bg-gray-200 text-gray-600">
                        <tr className="text-center">
                            {['Id', 'Tên nhân viên', 'Tên tài sản',  'Ngày cấp',  'Ngày trả', 'Trạng thái', 'Action'].map((header, index) => (
                                <th key={index} className="py-2 px-4 border-b">{header}</th>
                            ))}
                        </tr>
                    </thead>
                    <tbody>
                        {capPhatTaiSans.length > 0 ? capPhatTaiSans.map((capPhat) => (
                            <tr key={capPhat.id}>
                                <td className="text-center py-2 px-4 border-b-2">{capPhat.id}</td>
                                <td className="text-center py-2 px-4 border-b">{capPhat.hoTenNhanVien}</td>
                                <td className="text-center py-2 px-4 border-b">{capPhat.tenTaiSan}</td>
                                <td className="text-center py-2 px-4 border-b">{format(new Date(capPhat.ngayCapPhat), 'dd-MM-yyyy')}</td>
                                <td className="text-center py-2 px-4 border-b">{format(new Date(capPhat.ngayTraLai), 'dd-MM-yyyy')}</td>
                                <td className="text-center py-2 px-4 border-b">{capPhat.tinhTrang}</td>
                                <td className="flex justify-center py-2 px-4 border-b">
                                    <Link to={`/sua-cap-phat/${capPhat.id}`} className="btn bg-yellow-500 hover:bg-yellow-700 text-white font-bold py-1 px-3 rounded mr-2">Sửa</Link>
                                    <button
                                        onClick={() => handleDelete(capPhat.id)}
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
        </div>
    );
}

export default ListCapPhatTaiSanComponent