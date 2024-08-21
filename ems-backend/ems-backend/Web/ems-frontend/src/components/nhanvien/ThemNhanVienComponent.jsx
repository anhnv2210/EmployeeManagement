import { listChiNhanhNganHang, listChiNhanhNganHangByNganHang } from '@/services/ChiNhanhNganHangService';
import { listChucDanh } from '@/services/ChucDanhService';
import { listNganHang } from '@/services/NganHangService';
import { addNhanVien, checkEmailExists, checkSoDienThoaiExists, listNhanVien, uploadFile } from '@/services/NhanVienService';
import { listNoiKhamBenh } from '@/services/NoiKhamBenhService';
import { listPhongBan } from '@/services/PhongBanService';
import { listQuanHuyen, listQuanHuyenByTinhThanh } from '@/services/QuanHuyenService';
import { listQuocGia } from '@/services/QuocGiaService';
import { listTinhThanh, listTinhThanhByQuocGia } from '@/services/TinhThanhService';
import { listXaPhuong, listXaPhuongByQuanHuyen } from '@/services/XaPhuongService';
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom';

const ThemNhanVienComponent = () => {
    const [selectedFile, setSelectedFile] = useState(null);
    const [nhanVien, setNhanVien] = useState({
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
        ngayBatDauLamViec:'',
        ngayKetThucLamViec:''
    });

    const [nhanViens, setNhanViens] = useState([]);
    const [phongBans, setPhongBans] = useState([]);
    const [chucDanhs, setChucDanhs] = useState([]);
    const [xaPhuongs, setXaPhuongs] = useState([]);
    const [quanHuyens, setQuanHuyens] = useState([]);
    const [tinhThanhs, setTinhThanhs] = useState([]);
    const [quocGias, setQuocGias] = useState([]);
    const [nganHangs, setNganHangs] = useState([]);
    const [chiNhanhNganHangs, setChiNhanhNganHangs] = useState([]);
    const [noiKhamBenhs, setNoiKhamBenhs] = useState([]);

    const [error, setError] = useState('');
    const navigate = useNavigate();
    
    useEffect(() => {
        listNhanVien()
            .then(response => {
                setNhanViens(response.data.data);
            })
            .catch(error => {
                console.error('Có lỗi xảy ra khi gọi API:', error);
            });
        listPhongBan()
            .then(response => {
                setPhongBans(response.data.data);
            })
            .catch(error => {
                console.error('Có lỗi xảy ra khi gọi API:', error);
            });
        listChucDanh()
            .then(response => {
                setChucDanhs(response.data.data);
            })
            .catch(error => {
                console.error('Có lỗi xảy ra khi gọi API:', error);
            });
        listQuocGia()
            .then(response => {
                setQuocGias(response.data.data);
            })
            .catch(error => {
                console.error('Có lỗi xảy ra khi gọi API:', error);
            });
        listNganHang()
            .then(response => {
                setNganHangs(response.data.data);
            })
            .catch(error => {
                console.error('Có lỗi xảy ra khi gọi API:', error);
            });
        listNoiKhamBenh()
            .then(response => {
                setNoiKhamBenhs(response.data.data);
            })
            .catch(error => {
                console.error('Có lỗi xảy ra khi gọi API:', error);
            });
    }, []);
    
    useEffect(() => {
        if (nhanVien.quocGiaId) {
            listTinhThanhByQuocGia(nhanVien.quocGiaId)
                .then(response => {
                    setTinhThanhs(response.data);
                    setNhanVien(prevState => ({ ...prevState, tinhThanhId: '', quanHuyenId: '', xaPhuongId: '' }));
                })
                .catch(error => {
                    console.error('Có lỗi xảy ra khi gọi API:', error);
                });
        } else {
            setTinhThanhs([]);
            setNhanVien(prevState => ({ ...prevState, tinhThanhId: '', quanHuyenId: '', xaPhuongId: ''}));
        }
    }, [nhanVien.quocGiaId]);

    useEffect(() => {
        if (nhanVien.tinhThanhId) {
            listQuanHuyenByTinhThanh(nhanVien.tinhThanhId)
                .then(response => {
                    setQuanHuyens(response.data);
                    setNhanVien(prevState => ({ ...prevState, quanHuyenId: '', xaPhuongId:'' }));
                })
                .catch(error => {
                    console.error('Có lỗi xảy ra khi gọi API:', error);
                });
        } else {
            setQuanHuyens([]);
            setNhanVien(prevState => ({ ...prevState, quanHuyenId: '', xaPhuongId:'' }));
        }
    }, [nhanVien.tinhThanhId]);

    useEffect(() => {
        if (nhanVien.quanHuyenId) {
            listXaPhuongByQuanHuyen(nhanVien.quanHuyenId)
                .then(response => {
                    setXaPhuongs(response.data);
                    setNhanVien(prevState => ({ ...prevState, xaPhuongId: '' }));
                })
                .catch(error => {
                    console.error('Có lỗi xảy ra khi gọi API:', error);
                });
        } else {
            setXaPhuongs([]);
            setNhanVien(prevState => ({ ...prevState, xaPhuongId: '' }));
        }
    }, [nhanVien.quanHuyenId]);

    useEffect(() => {
        if (nhanVien.nganHangId) {
            listChiNhanhNganHangByNganHang(nhanVien.nganHangId)
                .then(response => {
                    setChiNhanhNganHangs(response.data);
                    setNhanVien(prevState => ({ ...prevState, chiNhanhNganHangId: '' }));
                })
                .catch(error => {
                    console.error('Có lỗi xảy ra khi gọi API:', error);
                });
        } else {
            setChiNhanhNganHangs([]);
            setNhanVien(prevState => ({ ...prevState, chiNhanhNganHangId: '' }));
        }
    }, [nhanVien.nganHangId]);

    const handleChange = (e) => {
        const { name, value, type, checked } = e.target;
        setNhanVien({
            ...nhanVien,
            [name]: type === 'checkbox' ? checked : value
        });
    };
    
    const handleSubmit = async (e) => {
        e.preventDefault();
        
        try {
            const existEmail = await checkEmailExists(nhanVien.email);
            if (!existEmail) {
                setError('Email của nhân viên đã tồn tại. Vui lòng chọn email khác.');
                return;
            }
            const existSDT = await checkSoDienThoaiExists(nhanVien.soDienThoai);
            if (!existSDT) {
                setError('Số điện thoại của nhân viên đã tồn tại. Vui lòng chọn sđt khác.');
                return;
            }
            const formData = new FormData();
            formData.append('AnhDaiDien', selectedFile);
            formData.append('Hoten', nhanVien.hoTen);
            formData.append('NgaySinh', nhanVien.ngaySinh);
            formData.append('GioiTinh', nhanVien.gioiTinh);
            formData.append('SoDienThoai', nhanVien.soDienThoai);
            formData.append('Email', nhanVien.email);
            formData.append('PhongBanId', nhanVien.phongBanId);
            formData.append('ChucDanhId', nhanVien.chucDanhId);
            formData.append('XaPhuongId', nhanVien.xaPhuongId);
            formData.append('QuanHuyenId', nhanVien.quanHuyenId);
            formData.append('TinhThanhId', nhanVien.tinhThanhId);
            formData.append('QuocGiaId', nhanVien.quocGiaId);
            formData.append('NganHangId', nhanVien.nganHangId);
            formData.append('ChiNhanhNganHangId', nhanVien.chiNhanhNganHangId);
            formData.append('NoiKhamBenhId', nhanVien.noiKhamBenhId);
            formData.append('NguoiTaoId', nhanVien.nguoiTaoId);
            formData.append('NguoiCapNhatId', nhanVien.nguoiCapNhatId);
            formData.append('NgayBatDauLamViec', nhanVien.ngayBatDauLamViec);
            await addNhanVien(formData);
            navigate('/nhan-vien');
        } catch (error) {
            console.error("Error adding NhanVien:", error.response ? error.response.data : error.message);
            setError('Có lỗi xảy ra khi thêm nhân viên.');
        }
    };

    const handleFileChange = (event) => {
        setSelectedFile(event.target.files[0]);
    };
    
    return (
    <div className='bg-gray-50'>
        <div className="mx-auto py-5" style={{ minHeight:'calc(100vh - 190px)' }}>
                <div className="card bg-white shadow-md p-6 mt-6 mb-6 mx-auto w-full md:w-1/2 lg:w-1/2 rounded-lg border-2">
                    <h2 className="text-3xl font-bold text-center mb-6">Thêm mới Nhân Viên</h2>
                    <form onSubmit={handleSubmit}>
                        {error && <div className="bg-red-100 text-red-700 p-4 rounded mb-4">{error}</div>}
                        <div className='flex justify-between'>
                            <div className="mb-4 w-1/2 mr-5">
                                <label className="block text-gray-700 font-bold mb-2">Ảnh đại diện</label>
                                <input
                                    type="file"
                                    className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                                    name="anhDaiDien"
                                    onChange={handleFileChange} 
                                    required 
                                />
                            </div>
                            <div className="mb-4 w-1/2 ml-5">
                                <label className="block text-gray-700 font-bold mb-2">Tên nhân viên</label>
                                <input 
                                    type="text" 
                                    className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                                    name="hoTen"
                                    value={nhanVien.hoTen} 
                                    onChange={handleChange} 
                                    placeholder='Điền thông tin họ tên'
                                    required 
                                />
                            </div>
                        </div>
                        <div className='flex justify-between'>
                        <div className="mb-4 w-1/2 mr-5">
                            <label className="block text-gray-700 font-bold mb-2">Giới tính</label>
                            <select
                                className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                                name="gioiTinh"
                                value={nhanVien.gioiTinh}
                                onChange={handleChange}
                                required
                            >
                                <option value="True">Nam</option>
                                <option value="False">Nữ</option>
                            </select>
                        </div>
                        <div className="mb-4 w-1/2 ml-5">
                            <label className="block text-gray-700 font-bold mb-2">Ngày sinh</label>
                            <input 
                                type="date" 
                                className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                                name="ngaySinh"
                                value={nhanVien.ngaySinh} 
                                onChange={handleChange} 
                                required 
                            />
                        </div>
                        </div>
                        <div className='flex justify-between'>
                        <div className="mb-4 w-1/2 mr-5">
                            <label className="block text-gray-700 font-bold mb-2">Email</label>
                            <input 
                                type="text" 
                                className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                                name="email"
                                value={nhanVien.email} 
                                onChange={handleChange} 
                                placeholder='Điền thông tin email'
                                required 
                            />
                        </div>
                        <div className="mb-4 w-1/2 ml-5">
                            <label className="block text-gray-700 font-bold mb-2">Số điện thoại</label>
                            <input 
                                type="text" 
                                className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                                name="soDienThoai"
                                value={nhanVien.soDienThoai} 
                                onChange={handleChange} 
                                placeholder='Điền thông tin số điện thoại'
                                required 
                            />
                        </div>
                        </div>
                        <div className='flex justify-between'>
                        <div className="mb-4 w-1/2 mr-5">
                            <label className="block text-gray-700 font-bold mb-2">Thuộc phòng ban</label>
                            <select
                                className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                                name="phongBanId"
                                value={nhanVien.phongBanId}
                                onChange={handleChange}
                                required
                            >
                                <option value="">Chọn phòng ban</option>
                                {phongBans.map(pb => (
                                    <option key={pb.id} value={pb.id}>{pb.tenPhongBan}</option>
                                ))}
                            </select>
                        </div>
                        <div className="mb-4 w-1/2 ml-5">
                            <label className="block text-gray-700 font-bold mb-2">Chức danh</label>
                            <select
                                className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                                name="chucDanhId"
                                value={nhanVien.chucDanhId}
                                onChange={handleChange}
                                required
                            >
                                <option value="">Chọn chức danh</option>
                                {chucDanhs.map(cd => (
                                    <option key={cd.id} value={cd.id}>{cd.tenChucDanh}</option>
                                ))}
                            </select>
                        </div>
                        </div>
                        <div className='flex justify-between'>
                        <div className="mb-4 w-1/2 mr-5">
                            <label className="block text-gray-700 font-bold mb-2">Thuộc quốc gia</label>
                            <select
                                className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                                name="quocGiaId"
                                value={nhanVien.quocGiaId}
                                onChange={handleChange}
                                required
                            >
                                <option value="">Chọn quốc gia</option>
                                {quocGias.map(quocGia => (
                                    <option key={quocGia.id} value={quocGia.id}>{quocGia.tenQuocGia}</option>
                                ))}
                            </select>
                        </div>
                        <div className="mb-4 w-1/2 ml-5">
                            <label className="block text-gray-700 font-bold mb-2">Thuộc tỉnh/thành phố</label>
                            <select
                                className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                                name="tinhThanhId"
                                value={nhanVien.tinhThanhId}
                                onChange={handleChange}
                                required
                            >
                                <option value="">Chọn tỉnh/thành</option>
                                {tinhThanhs.map(tinhThanh => (
                                    <option key={tinhThanh.id} value={tinhThanh.id}>{tinhThanh.tenTinhThanh}</option>
                                ))}
                            </select>
                        </div>
                        </div>
                        <div className='flex justify-between'> 
                        <div className="mb-4 w-1/2 mr-5">
                            <label className="block text-gray-700 font-bold mb-2">Thuộc quận/huyện</label>
                            <select
                                className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                                name="quanHuyenId"
                                value={nhanVien.quanHuyenId}
                                onChange={handleChange}
                                required
                            >
                                <option value="">Chọn quận/huyện</option>
                                {quanHuyens.map(qh => (
                                    <option key={qh.id} value={qh.id}>{qh.tenQuanHuyen}</option>
                                ))}
                            </select>
                        </div>
                        <div className="mb-4 w-1/2 ml-5">
                            <label className="block text-gray-700 font-bold mb-2">Thuộc xã/phường</label>
                            <select
                                className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                                name="xaPhuongId"
                                value={nhanVien.xaPhuongId}
                                onChange={handleChange}
                                required
                            >
                                <option value="">Chọn xã/phường</option>
                                {xaPhuongs.map(xp => (
                                    <option key={xp.id} value={xp.id}>{xp.tenXaPhuong}</option>
                                ))}
                            </select>
                        </div>
                        </div>
                        <div className='flex justify-between'>
                        <div className="mb-4 w-1/2 mr-5">
                            <label className="block text-gray-700 font-bold mb-2">Thuộc ngân hàng</label>
                            <select
                                className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                                name="nganHangId"
                                value={nhanVien.nganHangId}
                                onChange={handleChange}
                                required
                            >
                                <option value="">Chọn ngân hàng</option>
                                {nganHangs.map(nh => (
                                    <option key={nh.id} value={nh.id}>{nh.tenNganHang}</option>
                                ))}
                            </select>
                        </div>
                        <div className="mb-4 w-1/2 ml-5">
                            <label className="block text-gray-700 font-bold mb-2">Thuộc chi nhánh ngân hàng</label>
                            <select
                                className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                                name="chiNhanhNganHangId"
                                value={nhanVien.chiNhanhNganHangId}
                                onChange={handleChange}
                                required
                            >
                                <option value="">Chọn chi nhánh ngân hàng</option>
                                {chiNhanhNganHangs.map(cnnh => (
                                    <option key={cnnh.id} value={cnnh.id}>{cnnh.tenChiNhanhNganHang}</option>
                                ))}
                            </select>
                        </div>
                        </div>
                        <div className='flex justify-between'>
                        <div className="mb-4 w-1/2 mr-5">
                            <label className="block text-gray-700 font-bold mb-2">Thuộc nơi khám bệnh</label>
                            <select
                                className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                                name="noiKhamBenhId"
                                value={nhanVien.noiKhamBenhId}
                                onChange={handleChange}
                                required
                            >
                                <option value="">Chọn nơi khám bệnh</option>
                                {noiKhamBenhs.map(nkb => (
                                    <option key={nkb.id} value={nkb.id}>{nkb.tenNoiKhamBenh}</option>
                                ))}
                            </select>
                        </div>
                        <div className="mb-4 w-1/2 ml-5">
                            <label className="block text-gray-700 font-bold mb-2">Người tạo</label>
                            <select 
                                className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                                name="nguoiTaoId"
                                value={nhanVien.nguoiTaoId}
                                onChange={handleChange} 
                                required
                            >
                                <option value="">Chọn người tạo</option>
                                {nhanViens.map(nhanVien => (
                                    <option key={nhanVien.id} value={nhanVien.id}>{nhanVien.hoTen}</option>
                                ))}
                            </select>
                        </div>
                        </div>
                        <div className='flex justify-between'>
                        <div className="mb-4 w-1/2 mr-5">
                            <label className="block text-gray-700 font-bold mb-2">Người cập nhật</label>
                            <select 
                                className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                                name="nguoiCapNhatId"
                                value={nhanVien.nguoiCapNhatId}
                                onChange={handleChange} 
                                required
                            >
                                <option value="">Chọn người cập nhật</option>
                                {nhanViens.map(nhanVien => (
                                    <option key={nhanVien.id} value={nhanVien.id}>{nhanVien.hoTen}</option>
                                ))}
                            </select>
                        </div>
                        <div className="mb-4 w-1/2 ml-5">
                            <label className="block text-gray-700 font-bold mb-2">Ngày bắt đầu</label>
                            <input 
                                type="date" 
                                className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                                name="ngayBatDauLamViec"
                                value={nhanVien.ngayBatDauLamViec} 
                                onChange={handleChange} 
                                required 
                            />
                        </div>
                        </div>
                        <div className='flex justify-between'>
                            <div className="mb-4 w-1/2 mr-5">
                                <label className="block text-gray-700 font-bold mb-2">Ngày Kết thúc</label>
                                <input 
                                    type="date" 
                                    className="form-control border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
                                    name="ngayKetThucLamViec"
                                    value={nhanVien.ngayKetThucLamViec} 
                                    onChange={handleChange} 
                                    required 
                                />
                            </div>
                        </div>
                        <div className="flex justify-between">
                            <button type="submit" className="btn bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline">Lưu</button>
                            <button type="button" className="btn bg-gray-500 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" onClick={() => navigate('/nhan-vien')}>Hủy</button>
                        </div>
                    </form>
                </div>
        </div>
    </div>
    )
}

export default ThemNhanVienComponent