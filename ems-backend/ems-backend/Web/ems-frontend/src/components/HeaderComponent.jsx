import React, { useState } from 'react'
const HeaderComponent = () => {

    const [showDanhMuc, setShowDanhMuc] = useState  (false);
    const [showNghiepVu, setShowNghiepVu] = useState(false);

    const toggleDanhMuc = () => setShowDanhMuc(!showDanhMuc && !showNghiepVu);
    const toggleNghiepVu = () => setShowNghiepVu(!showNghiepVu && !showDanhMuc);

    return (
        <div>
            <nav className="bg-white shadow">
                <div className="container mx-auto px-4 py-2 flex flex-wrap items-center justify-between">
                    <a className="text-2xl font-semibold text-gray-800" href="/">Hồ sơ nhân sự</a>
                    <button className="block lg:hidden p-2 text-gray-800 focus:outline-none" type="button">
                        <span className="material-icons">menu</span>
                    </button>
                    <div className="w-full lg:flex lg:items-center lg:w-auto hidden lg:block" id="navbarSupportedContent">
                        <ul className="lg:flex lg:space-x-6 mt-4 lg:mt-0">
                            <li className="relative group">
                                <button onClick={toggleDanhMuc} className="block py-2 text-gray-700 hover:text-gray-900 focus:outline-none">
                                    Danh mục
                                </button>
                                {showDanhMuc && (
                                    <ul className="absolute left-0 mt-2 w-48 bg-white shadow-lg rounded-md py-2">
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="/chuc-danh">Chức danh</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="/phong-ban">Phòng ban</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="/loai-hop-dong">Loại hợp đồng</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Ngân hàng</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Chi nhánh ngân hàng</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="/tai-san">Tài sản cấp phát</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Nơi khám bệnh</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Tỉnh thành</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Quận huyện</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Xã phường</a></li>
                                        <li><hr className="border-gray-200" /></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Danh mục khác</a></li>
                                    </ul>
                                )}
                            </li>
                            <li className="relative group">
                                <button onClick={toggleNghiepVu} className="block py-2 text-gray-700 hover:text-gray-900 focus:outline-none">
                                    Nghiệp vụ
                                </button>
                                {showNghiepVu && (
                                    <ul className="absolute left-0 mt-2 w-48 bg-white shadow-lg rounded-md py-2">
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Hồ sơ nhân viên</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Thông tin các quá trình trong HSNV</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Thông tin công tác – lương</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="/phu-cap">Phụ cấp</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="/phuc-loi">Phúc lợi</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Hợp đồng lao động</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Cấp phát tài sản</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Kỷ luật</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Khen thưởng</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Nghỉ việc</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Tệp tin đính kèm</a></li>
                                    </ul>
                                )}
                            </li>
                            <li>
                                <a className="block py-2 text-gray-700 hover:text-gray-900" href="#" tabIndex="-1" aria-disabled="true">About</a>
                            </li>
                        </ul>
                        <form className="mt-4 lg:mt-0 lg:ml-8 relative">
                            <input className="block w-full pl-4 pr-4 py-2 border rounded-md" type="search" placeholder="Search" aria-label="Search" />
                            <button className="absolute inset-y-0 left-0 flex items-center pl-3" type="submit">
                                <span className="material-icons"></span>
                            </button>
                        </form>
                    </div>
                </div>
            </nav>
        </div>
    );
}

export default HeaderComponent