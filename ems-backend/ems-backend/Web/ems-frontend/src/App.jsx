import './App.css'
import ChucDanhListComponent from './components/chucdanh/ChucDanhListComponent'
import FooterComponent from './components/FooterComponent'
import HeaderComponent from './components/HeaderComponent'
import {BrowserRouter, Routes, Route} from 'react-router-dom'
import HomeComponent from './components/HomeComponent'
import ThemChucDanhComponent from './components/chucdanh/ThemChucDanhComponent'
import SuaChucDanhComponent from './components/chucdanh/SuaChucDanhComponent'
import ChucDanhPhongBanComponent from './components/chucdanh/ChucDanhTheoPhongBanComponent'
import ListPhongBanComponent from './components/phongban/ListPhongBanComponent'
import ThemPhongBanComponent from './components/phongban/ThemPhongBanComponent'
import SuaPhongBanComponent from './components/phongban/SuaPhongBanComponent'
import ListLoaiHopDongComponent from './components/loaihopdong/ListLoaiHopDongComponent'
import ThemLoaiHopDongComponent from './components/loaihopdong/ThemLoaiHopDongComponent'
import SuaLoaiHopDongComponent from './components/loaihopdong/SuaLoaiHopDongComponent'
import ListPhuCapComponent from './components/phucap/ListPhuCapComponent'
import ThemPhuCapComponent from './components/phucap/ThemPhuCapComponent'
import SuaPhuCapComponent from './components/phucap/SuaPhuCapComponent'
import ListPhucLoiComponent from './components/phucloi/ListPhucLoiComponent'
import ThemPhucLoiComponent from './components/phucloi/ThemPhucLoiComponent'
import SuaPhucLoiComponent from './components/phucloi/SuaPhucLoiComponent'
import ListTaiSanComponent from './components/taisan/ListTaiSanComponent'
import ThemTaiSanComponent from './components/taisan/ThemTaiSanComponent'
import SuaTaiSanComponent from './components/taisan/SuaTaiSanComponent'
import ListDanhMucKhacComponent from './components/danhmuckhac/ListDanhMucKhacComponent'
import ThemDanhMucKhacComponent from './components/danhmuckhac/ThemDanhMucKhacComponent'
import SuaDanhMucKhacComponent from './components/danhmuckhac/SuaDanhMucKhacComponent'
import ListNganHangComponent from './components/nganhang/ListNganHangComponent'
import ThemNganHangComponent from './components/nganhang/ThemNganHangComponent'
import SuaNganHangComponent from './components/nganhang/SuaNganHangComponent'
import ListChiNhanhNganHangComponent from './components/chinhanhnganhang/ListChiNhanhNganHangComponent'
import ThemChiNhanhNganHangComponent from './components/chinhanhnganhang/ThemChiNhanhNganHangComponent'
import SuaChiNhanhNganHangComponent from './components/chinhanhnganhang/SuaChiNhanhNganHangComponent'
import ListNoiKhamBenhComponent from './components/noikhambenh/ListNoiKhamBenhComponent'
import ThemNoiKhamBenhComponent from './components/noikhambenh/ThemNoiKhamBenhComponent'
import SuaNoiKhamBenhComponent from './components/noikhambenh/SuaNoiKhamBenhComponent'
import ListQuocGiaComponent from './components/quocgia/ListQuocGiaComponent'
import ThemQuocGiaComponent from './components/quocgia/ThemQuocGiaComponent'
import SuaQuocGiaComponent from './components/quocgia/SuaQuocGiaComponent'
import ListTinhThanhComponent from './components/tinhthanh/ListTinhThanhComponent'
import ThemTinhThanhComponent from './components/tinhthanh/ThemTinhThanhComponent'
import SuaTinhThanhComponent from './components/tinhthanh/SuaTinhThanhComponent'
import ListQuanHuyenComponent from './components/quanhuyen/ListQuanHuyenComponent'
import ThemQuanHuyenComponent from './components/quanhuyen/ThemQuanHuyenComponent'
import SuaQuanHuyenComponent from './components/quanhuyen/SuaQuanHuyenComponent'
import ListXaPhuongComponent from './components/xaphuong/ListXaPhuongComponent'
import ThemXaPhuongComponent from './components/xaphuong/ThemXaPhuongComponent'
import SuaXaPhuongComponent from './components/xaphuong/SuaXaPhuongComponent'
import ListNhanVienComponent from './components/nhanvien/ListNhanVienComponent'
import ThemNhanVienComponent from './components/nhanvien/ThemNhanVienComponent'
import ThongTinNhanVienComponent from './components/nhanvien/ThongTinNhanVienComponent'
import SuaNhanVienComponent from './components/nhanvien/SuaNhanVienComponent'
import ListHoSoLuongComponent from './components/hosoluong/ListHoSoLuongComponent'
import ThemHoSoLuongComponent from './components/hosoluong/ThemHoSoLuongComponent'
import HoSoLuongPhuCapComponent from './components/hosoluong/HoSoLuongPhuCapComponent'
import HoSoLuongPhucLoiComponent from './components/hosoluong/HoSoLuongPhucLoiComponent'
import ThemQuyetDinhComponent from './components/hopdonglaodong/ThemQuyetDinhComponent'
import ThemHopDongLaoDongComponent from './components/hopdonglaodong/ThemHopDongLaoDongComponent'
import ListHopDongComponent from './components/hopdonglaodong/ListHopDongComponent'
import SuaQuyetDinhComponent from './components/hopdonglaodong/SuaQuyetDinhComponent'
import SuaHopDongComponent from './components/hopdonglaodong/SuaHopDongComponent'
import ListQuyetDinhComponent from './components/hopdonglaodong/ListQuyetDinhComponent'
import ReminderComponent from './components/ReminderComponent'
import SoDoPhongBanComponent from './components/SoDoPhongBanComponent'
import ListCapPhatTaiSanComponent from './components/capphattaisan/ListCapPhatTaiSanComponent'
import ThemCapPhatTaiSanComponent from './components/capphattaisan/ThemCapPhatTaiSanComponent'
import SuaCapPhatTaiSanComponent from './components/capphattaisan/SuaCapPhatTaiSanComponent'
function App() {

  return (
    <>
      <BrowserRouter>
        <HeaderComponent/>
          <Routes>

            <Route path='/' element = {<HomeComponent/>}></Route>

            <Route path='/chuc-danh' element = {<ChucDanhListComponent/>}></Route>

            <Route path='/them-chuc-danh' element = {<ThemChucDanhComponent/>}></Route>

            <Route path="/sua-chuc-danh/:id" element={<SuaChucDanhComponent />} />

            <Route path='/chuc-danh-phong-ban' element = {<ChucDanhPhongBanComponent />}/>

            <Route path='/phong-ban' element = {<ListPhongBanComponent/>}></Route>

            <Route path='/them-phong-ban' element = {<ThemPhongBanComponent/>}></Route>

            <Route path="/sua-phong-ban/:id" element={<SuaPhongBanComponent />} />

            <Route path='/loai-hop-dong' element = {<ListLoaiHopDongComponent/>}></Route>

            <Route path='/them-loai-hop-dong' element = {<ThemLoaiHopDongComponent/>}></Route>

            <Route path="/sua-loai-hop-dong/:id" element={<SuaLoaiHopDongComponent />} />

            <Route path='/phu-cap' element = {<ListPhuCapComponent/>}></Route>

            <Route path='/them-phu-cap' element = {<ThemPhuCapComponent/>}></Route>

            <Route path="/sua-phu-cap/:id" element={<SuaPhuCapComponent />} />

            <Route path='/phuc-loi' element = {<ListPhucLoiComponent/>}></Route>

            <Route path='/them-phuc-loi' element = {<ThemPhucLoiComponent/>}></Route>

            <Route path="/sua-phuc-loi/:id" element={<SuaPhucLoiComponent />} />

            <Route path='/tai-san' element = {<ListTaiSanComponent/>}></Route>

            <Route path='/them-tai-san' element = {<ThemTaiSanComponent/>}></Route>

            <Route path="/sua-tai-san/:id" element={<SuaTaiSanComponent />} />

            <Route path='/danh-muc-khac' element = {<ListDanhMucKhacComponent/>}></Route>

            <Route path='/them-danh-muc-khac' element = {<ThemDanhMucKhacComponent/>}></Route>

            <Route path="/sua-danh-muc-khac/:id" element={<SuaDanhMucKhacComponent />} />

            <Route path='/ngan-hang' element = {<ListNganHangComponent/>}></Route>

            <Route path='/them-ngan-hang' element = {<ThemNganHangComponent/>}></Route>

            <Route path="/sua-ngan-hang/:id" element={<SuaNganHangComponent />} />

            <Route path='/chi-nhanh-ngan-hang' element = {<ListChiNhanhNganHangComponent/>}></Route>

            <Route path='/them-chi-nhanh-ngan-hang' element = {<ThemChiNhanhNganHangComponent/>}></Route>

            <Route path="/sua-chi-nhanh-ngan-hang/:id" element={<SuaChiNhanhNganHangComponent />} />

            <Route path='/noi-kham-benh' element = {<ListNoiKhamBenhComponent/>}></Route>

            <Route path='/them-noi-kham-benh' element = {<ThemNoiKhamBenhComponent/>}></Route>

            <Route path="/sua-noi-kham-benh/:id" element={<SuaNoiKhamBenhComponent />} />

            <Route path='/quoc-gia' element = {<ListQuocGiaComponent/>}></Route>

            <Route path='/them-quoc-gia' element = {<ThemQuocGiaComponent/>}></Route>

            <Route path="/sua-quoc-gia/:id" element={<SuaQuocGiaComponent />} />

            <Route path='/tinh-thanh' element = {<ListTinhThanhComponent/>}></Route>

            <Route path='/them-tinh-thanh' element = {<ThemTinhThanhComponent/>}></Route>

            <Route path="/sua-tinh-thanh/:id" element={<SuaTinhThanhComponent />} />

            <Route path='/quan-huyen' element = {<ListQuanHuyenComponent/>}></Route>

            <Route path='/them-quan-huyen' element = {<ThemQuanHuyenComponent/>}></Route>

            <Route path="/sua-quan-huyen/:id" element={<SuaQuanHuyenComponent />} />

            <Route path='/xa-phuong' element = {<ListXaPhuongComponent/>}></Route>

            <Route path='/them-xa-phuong' element = {<ThemXaPhuongComponent/>}></Route>

            <Route path="/sua-xa-phuong/:id" element={<SuaXaPhuongComponent />} />

            <Route path='/nhan-vien' element = {<ListNhanVienComponent/>}></Route>

            <Route path='/them-nhan-vien' element = {<ThemNhanVienComponent/>}></Route>

            <Route path="/thong-tin-nhan-vien/:id" element={<ThongTinNhanVienComponent />} />

            <Route path="/sua-nhan-vien/:id" element={<SuaNhanVienComponent />} />

            <Route path='/ho-so-luong' element = {<ListHoSoLuongComponent/>}></Route>

            <Route path='/them-ho-so-luong' element = {<ThemHoSoLuongComponent/>}></Route>

            <Route path='/ho-so-luong-phu-cap/:hoSoLuongId' element = {<HoSoLuongPhuCapComponent/>}></Route>

            <Route path='/ho-so-luong-phuc-loi/:hoSoLuongId' element = {<HoSoLuongPhucLoiComponent/>}></Route>

            <Route path='/them-quyet-dinh' element = {<ThemQuyetDinhComponent/>}></Route>

            <Route path='/them-hop-dong' element = {<ThemHopDongLaoDongComponent/>}></Route>

            <Route path='/hop-dong' element = {<ListHopDongComponent/>}></Route>

            <Route path="/sua-quyet-dinh/:id" element={<SuaQuyetDinhComponent />} />

            <Route path="/sua-hop-dong/:id" element={<SuaHopDongComponent />} />

            <Route path='/quyet-dinh' element = {<ListQuyetDinhComponent/>}></Route>

            <Route path='/reminder' element = {<ReminderComponent/>}></Route>

            <Route path='/so-do' element = {<SoDoPhongBanComponent/>}></Route>

            <Route path='/cap-phat' element = {<ListCapPhatTaiSanComponent/>}></Route>

            <Route path='/them-cap-phat' element = {<ThemCapPhatTaiSanComponent/>}></Route>

            <Route path="/sua-cap-phat/:id" element={<SuaCapPhatTaiSanComponent/>} />

          </Routes>
        <FooterComponent/>
      </BrowserRouter>
    </>
  )
}

export default App
