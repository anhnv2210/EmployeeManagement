import './App.css'
import ChucDanhListComponent from './components/chucdanh/ChucDanhListComponent'
import FooterComponent from './components/FooterComponent'
import HeaderComponent from './components/HeaderComponent'
import {BrowserRouter, Routes, Route} from 'react-router-dom'
import HomeComponent from './components/HomeComponent'
import ThemChucDanhComponent from './components/chucdanh/ThemChucDanhComponent'
import SuaChucDanhComponent from './components/chucdanh/SuaChucDanhComponent'
function App() {

  return (
    <>
      <BrowserRouter>
        <HeaderComponent/>
          <Routes>
            {/* "http://localhost:3000" */}
            <Route path='/' element = {<HomeComponent/>}></Route>
            {/* "http://localhost:3000/chucdanh" */}
            <Route path='/chucdanh' element = {<ChucDanhListComponent/>}></Route>
            {/* "http://localhost:3000/them-chucdanh" */}
            <Route path='/them-chucdanh' element = {<ThemChucDanhComponent/>}></Route>
            <Route path="/sua-chucdanh/:id" element={<SuaChucDanhComponent />} />
          </Routes>
        {/* <ChucDanhListComponent/> */}
        <FooterComponent/>
      </BrowserRouter>
    </>
  )
}

export default App
