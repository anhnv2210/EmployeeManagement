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
function App() {

  return (
    <>
      <BrowserRouter>
        <HeaderComponent/>
          <Routes>

            <Route path='/' element = {<HomeComponent/>}></Route>

            <Route path='/chuc-danh' element = {<ChucDanhListComponent/>}></Route>

            <Route path='/them-chuc-danh' element = {<ThemChucDanhComponent/>}></Route>

            <Route path="/sua-chucdanh/:id" element={<SuaChucDanhComponent />} />

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

            <Route path='/them-tai-san' element = {<ThemPhucLoiComponent/>}></Route>

            <Route path="/sua-tai-san/:id" element={<SuaPhucLoiComponent />} />

          </Routes>
        <FooterComponent/>
      </BrowserRouter>
    </>
  )
}

export default App
