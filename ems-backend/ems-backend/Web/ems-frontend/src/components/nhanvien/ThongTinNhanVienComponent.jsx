import { getNhanVienById } from '@/services/NhanVienService';
import { format } from 'date-fns';
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom';
const ThongTinNhanVienComponent = () => {
    const { id } = useParams();
    const navigate = useNavigate();
    const [nhanVien, setNhanVien] = useState({
        anhDaiDien:'',
        hoTen: '',
        gioiTinh: true,
        ngaySinh:'',
        email:'',
        soDienThoai:'',
        phongBanId:'',
        chucDanhId:'',
        xaPhuongId:'',
        quanHuyenId:'',
        tinhThanhId:'',
        quocGiaId:'',
        nganHangId:'',
        chiNhanhNganHangId:'',
        noiKhamBenhId:'',
        nguoiTaoId: '',
        nguoiCapNhatId: '',
        ngayBatDauLamViec:''
    });

    const duongDan = '@/src/asset'

    const [error, setError] = useState('');
    
    useEffect(() => {
        getNhanVienById(id)
            .then(response => {
                setNhanVien(response.data);
            })
            .catch(error => {
                console.error('Có lỗi xảy ra khi gọi API:', error);
            });
        });
        const ConvertDate = (stringDate) => {
            const dateString = stringDate;
            const dateObject = new Date(dateString);
            
            const day = String(dateObject.getDate()).padStart(2, '0'); 
            const month = String(dateObject.getMonth() + 1).padStart(2, '0');
            const year = dateObject.getFullYear();
            
            const formattedDate = `${day}-${month}-${year}`;
            return formattedDate;
        }
        
  return (
    <div className='bg-gray-50 py-10'>
        <div className='container bg-white w-1/2 border-2 rounded-lg font-sans'>
            <div className='flex '>
                <div className='w-3/5'>
                    <img className='w-full' src={nhanVien.anhDaiDien}/>
                </div>
                <div className='w-2/5 ml-10 mt-5'>
                    <span className='block text-lg mt-3'>Họ và tên: {nhanVien.hoTen}</span> <br/>
                    <span className='block text-lg mt-3'>Ngày sinh: {ConvertDate(nhanVien.ngaySinh)}</span> <br/>
                    <span className='block text-lg mt-3'>Giới tính: {nhanVien.gioiTinh ? "Nam" : "Nữ"}</span> <br/>
                    <span className='block text-lg mt-3'>Email: {nhanVien.email}</span> <br/>
                    <span className='block text-lg mt-3'>Số điện thoại: {nhanVien.soDienThoai}</span> <br/>
                </div>
            </div>
            <div className='flex mb-5'>
                <span className='block text-lg mx-5 w-1/2'>Thuộc phòng ban: {nhanVien.tenPhongBan}</span>
                <span className='block text-lg ml-32 w-1/2'>Chức danh: {nhanVien.tenChucDanh}</span>
            </div>
            <div className='mb-5'>
                <span className='block text-lg mx-5'>Địa chỉ: {nhanVien.tenXaPhuong}, {nhanVien.tenQuanHuyen}, {nhanVien.tenTinhThanh}, {nhanVien.tenQuocGia}</span> <br/>
                <span className='block text-lg mx-5'>Ngân hàng: {nhanVien.tenNganHang}</span> <br/>
                <span className='block text-lg mx-5'>Chi nhán ngân hàng: {nhanVien.tenChiNhanhNganHang}</span> <br/>
                <span className='block text-lg mx-5'>Nơi khám chữa bệnh: {nhanVien.tenNoiKhamBenh}</span> <br/>
                <span className='block text-lg mx-5'>Ngày bắt đầu làm việc: {ConvertDate(nhanVien.ngayBatDauLamViec)}</span> <br/>
                <span className='block text-lg mx-5'>Hiện trạng: {nhanVien.trangThai}</span> <br/>
            </div>
            <div className='mb-3 flex justify-end'>
                <button type="button" className="btn bg-gray-500 hover:bg-gray-700 text-white font-bold py-2 px-2 rounded focus:outline-none focus:shadow-outline" onClick={() => navigate('/nhan-vien')}>Đóng</button>
            </div>
        </div>
    </div>    
  )
}

export default ThongTinNhanVienComponent