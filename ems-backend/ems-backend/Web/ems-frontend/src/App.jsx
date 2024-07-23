import './App.css'
import ChucDanhListComponent from './components/chucdanh/ChucDanhListComponent'
import FooterComponent from './components/FooterComponent'
import HeaderComponent from './components/HeaderComponent'
import {BrowserRouter, Routes, Route} from 'react-router-dom'
import HomeComponent from './components/HomeComponent'
function App() {

  return (
    <>
      <BrowserRouter>
        <HeaderComponent/>
          <Routes>
            <Route path='/' element = {<HomeComponent/>}></Route>
            <Route path='/chucdanh' element = {<ChucDanhListComponent/>}></Route>
          </Routes>
        {/* <ChucDanhListComponent/> */}
        <FooterComponent/>
      </BrowserRouter>
    </>
  )
}

export default App
