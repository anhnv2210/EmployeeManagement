import React, {useEffect, useState} from 'react'
import { listChucDanh } from '../../services/ChucDanhService'
import {format} from 'date-fns'
const ChucDanhListComponent = () => {

    const [chucDanhs, setChucDanhs] = useState([])

    useEffect(() => {
        listChucDanh().then((response) => {
            setChucDanhs(response.data);
        }).catch(error => {
            console.error(error);
        })

    }, [])

  return (
    <div className='container mt-5'>
        <h2 className='text-center mb-4'>Danh sách chức danh</h2>
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
                        </tr>)
                }
            </tbody>
        </table>
    </div>
  )
}

export default ChucDanhListComponent