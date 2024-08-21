import { deleteQuanHuyen, listQuanHuyen } from '@/services/QuanHuyenService';
import React, { useEffect, useState } from 'react'
import { Link, useNavigate } from 'react-router-dom';

const ListQuanHuyenComponent = () => {
    const [quanHuyens, setQuanHuyens] = useState([]);
    const [currentPage, setCurrentPage] = useState(1);
    const [totalRecords, setTotalRecords] = useState(0);
    const pageSize = 10; 
    const navigate = useNavigate();

    useEffect(() => {
        const fetchQuanHuyens = () => {
            listQuanHuyen(pageSize, currentPage)
                .then((response) => {
                    setQuanHuyens(response.data.data);
                    setTotalRecords(response.data.totalItems);
                })
                .catch((error) => {
                    console.error('Error fetching QuanHuyens:', error);
                });
        };
        fetchQuanHuyens();
    }, [currentPage]);

    const handleDelete = (id) => {
        if (window.confirm("Bạn có chắc chắn muốn xóa quận huyện này?")) {
            deleteQuanHuyen(id).then(() => {
                setQuanHuyens(quanHuyens.filter(qh => qh.id !== id));
            }).catch(error => {
                console.error("Error deleting QuanHuyen:", error.response ? error.response.data : error.message);
            });
        }
    };

    const themQuanHuyen = () => {
        navigate('/them-quan-huyen');
    };

    const handlePageChange = (page) => setCurrentPage(page);

    return (
        <div className='bg-gray-50 pt-5'>
            <div className="container mx-auto" style={{ minHeight:'calc(100vh - 130px)' }}>
                <h2 className="text-3xl font-bold text-center mb-5">Danh sách Quận/Huyện</h2>
                <button className="inline-block mb-3 rounded-sm bg-gradient-to-r from-blue-500 to-purple-500 px-8 py-2.5 text-base font-semibold text-white shadow-lg transition duration-300 ease-in-out transform hover:scale-105 hover:from-blue-600 hover:to-purple-600 focus:outline-none focus:ring-4 focus:ring-blue-300 active:scale-95" onClick={themQuanHuyen}>Thêm mới</button>
                <table className="min-w-full bg-white border border-gray-200 rounded-lg overflow-hidden">
                    <thead className="bg-gray-200 text-gray-600">
                        <tr className="text-center">
                            <th className="py-2 px-4 border-b">Id</th>
                            <th className="py-2 px-4 border-b">Tên quận huyện</th>
                            <th className="py-2 px-4 border-b">Thuộc tỉnh thành</th>
                            <th className="py-2 px-4 border-b">Thuộc quốc gia</th>
                            <th className="py-2 px-4 border-b">Mô tả</th>
                            <th className="py-2 px-4 border-b">Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        {quanHuyens.map(quanHuyen => (
                            <tr key={quanHuyen.id}>
                                <td className="text-center py-2 px-2 border-b-2">{quanHuyen.id}</td>
                                <td className="text-center py-2 px-2 border-b">{quanHuyen.tenQuanHuyen}</td>
                                <td className="text-center py-2 px-2 border-b">{quanHuyen.tenTinhThanh}</td>
                                <td className="text-center py-2 px-2 border-b">{quanHuyen.tenQuocGia}</td>
                                <td className="text-center py-2 px-2 border-b">{quanHuyen.moTa}</td>
                                <td className="flex justify-center py-2 px-4 border-b">
                                    <Link to={`/sua-quan-huyen/${quanHuyen.id}`} className="btn bg-yellow-500 hover:bg-yellow-700 text-white font-bold py-1 px-3 rounded mr-2">Sửa</Link>
                                    <button
                                        onClick={() => handleDelete(quanHuyen.id)}
                                        className="btn bg-red-500 hover:bg-red-700 text-white font-bold py-1 px-3 rounded"
                                    >
                                        Xóa
                                    </button>
                                </td>
                            </tr>
                        ))}
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
        </div>
    );
}

export default ListQuanHuyenComponent