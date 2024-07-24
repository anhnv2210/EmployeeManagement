import React, {useEffect, useState} from 'react'
import { deleteChucDanh, listChucDanh } from '../../services/ChucDanhService'
import {format} from 'date-fns'
import {Link,useNavigate} from 'react-router-dom'

const ChucDanhListComponent = () => {

    const [chucDanhs, setChucDanhs] = useState([]);

    const navigator = useNavigate();

    useEffect(() => {
        listChucDanh().then((response) => {
            setChucDanhs(response.data);
        }).catch(error => {
            console.error(error);
        })

    }, [])

    const handleDelete = (id) => {
        if (window.confirm("Bạn có chắc chắn muốn xóa chức danh này?")) {
            deleteChucDanh(id).then(() => {
                setChucDanhs(chucDanhs.filter(cd => cd.id !== id));
            }).catch(error => {
                console.error("Error deleting ChucDanh:", error.response ? error.response.data : error.message);
            });
        }
    }

    function themChucDanh(){
        navigator('/them-chucdanh')
    }

  return (
    <div className='container mt-5'>
        <h2 className='text-center mb-4'>Danh sách chức danh</h2>
        <button className='btn btn-primary mb-2' onClick={themChucDanh}>Thêm mới</button>
        <table className='table table-striped table-bordered'>
            <thead className='text-center'>
                <tr>
                    <th>Id</th>
                    <th>Tên chức danh</th>
                    <th>Mô tả</th>
                    <th>Người tạo</th>
                    <th>Ngày tạo</th>
                    <th>Người cập nhật</th>
                    <th>Ngày cập nhật</th>
                    <th>Trạng thái</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
                {
                    chucDanhs.map(chucDanh => 
                        <tr key={chucDanh.id}>
                            <td className='text-center'>{chucDanh.id}</td>
                            <td>{chucDanh.tenChucDanh}</td>
                            <td>{chucDanh.moTa}</td>
                            <td>{chucDanh.nguoiTaoHoTen}</td>
                            <td className='text-center'>{format(new Date(chucDanh.ngayTao), 'dd-MM-yyyy')}</td>
                            <td>{chucDanh.nguoiCapNhatHoTen}</td>
                            <td className='text-center'>{format(new Date(chucDanh.ngayCapNhat), 'dd-MM-yyyy')}</td>
                            <td>{chucDanh.isActive ? "Áp dụng" : "Ngưng áp dụng"}</td>
                            <td className='d-flex justify-content-center'>
                                    <Link to={`/sua-chucdanh/${chucDanh.id}`} className='btn btn-warning btn-sm'>Sửa</Link>
                                    <button
                                        onClick={() => handleDelete(chucDanh.id)}
                                        className='btn btn-danger btn-sm ms-2'
                                    >
                                        Xóa
                                    </button>
                                </td>
                        </tr>)
                }
            </tbody>
        </table>
    </div>
  )
}

export default ChucDanhListComponent