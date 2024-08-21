import React, { useState } from 'react';
import logoEM from '@/assets/img/LogoEM.jpg'
const HeaderComponent = () => {
    const [activeMenu, setActiveMenu] = useState('');

    const toggleMenu = (menu) => {
        setActiveMenu(menu === activeMenu ? '' : menu);
    };

    return (
        <div>
            <nav className="bg-white shadow">
                <div className="px-4 py-2 flex justify-between ">
                     <img className='ml-32 w-32 h-20' src={logoEM} alt='Logo' title='Design for Dream'/> 
                    <button className="block lg:hidden p-2 text-gray-800 focus:outline-none" type="button">
                        <span className="material-icons">menu</span>
                    </button>
                    <div className="w-full lg:flex lg:items-center lg:w-auto hidden lg:block" id="navbarSupportedContent">
                        <ul className="lg:flex lg:space-x-6 mt-4 lg:mt-0">
                            <li><a className="block py-2 text-gray-700 hover:text-gray-900 focus:outline-none" href='/'>Trang chủ</a></li>
                            <li className="relative group">
                                <button 
                                    onClick={() => toggleMenu('danhMuc')}
                                    className="block py-2 text-gray-700 hover:text-gray-900 focus:outline-none"
                                >
                                    Danh mục
                                </button>
                                {activeMenu === 'danhMuc' && (
                                    <ul className="absolute left-0 mt-2 w-48 bg-white shadow-lg rounded-md py-2 transition-opacity duration-300 ease-in-out">
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="/chuc-danh">Chức danh</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="/phong-ban">Phòng ban</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="/loai-hop-dong">Loại hợp đồng</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="/ngan-hang">Ngân hàng</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="/chi-nhanh-ngan-hang">Chi nhánh ngân hàng</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="/tai-san">Tài sản cấp phát</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="/noi-kham-benh">Nơi khám bệnh</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="/quoc-gia">Quốc gia</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="/tinh-thanh">Tỉnh thành</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="/quan-huyen">Quận huyện</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="/xa-phuong">Xã phường</a></li>
                                        <li><hr className="border-gray-200" /></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="/danh-muc-khac">Danh mục khác</a></li>
                                    </ul>
                                )}
                            </li>
                            <li className="relative group">
                                <button 
                                    onClick={() => toggleMenu('nghiepVu')}
                                    className="block py-2 text-gray-700 hover:text-gray-900 focus:outline-none"
                                >
                                    Nghiệp vụ
                                </button>
                                {activeMenu === 'nghiepVu' && (
                                    <ul className="absolute left-0 mt-2 w-48 bg-white shadow-lg rounded-md py-2 transition-opacity duration-300 ease-in-out">
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="/nhan-vien">Hồ sơ nhân viên</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="/ho-so-luong">Thông tin công tác – lương</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="/quyet-dinh">Quyết định</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="/phu-cap">Phụ cấp</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="/phuc-loi">Phúc lợi</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="/hop-dong">Hợp đồng lao động</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="/cap-phat">Cấp phát tài sản</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Kỷ luật</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Khen thưởng</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Nghỉ việc</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Tệp tin đính kèm</a></li>
                                    </ul>
                                )}
                            </li>
                            <li className="relative group">
                                <button 
                                    onClick={() => toggleMenu('baoCao')}
                                    className="block py-2 text-gray-700 hover:text-gray-900 focus:outline-none"
                                >
                                    Báo cáo
                                </button>
                                {activeMenu === 'baoCao' && (
                                    <ul className="absolute left-0 mt-2 w-48 bg-white shadow-lg rounded-md py-2 transition-opacity duration-300 ease-in-out">
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Nhân sự biến động theo năm, tháng</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Báo cáo hợp đồng lao động</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Quản lý thay đổi thông tin nhân sự</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Báo cáo về phúc lợi</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Báo cáo về phụ cấp</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Báo cáo về kỷ luật</a></li>
                                        <li><a className="block px-4 py-2 text-gray-700 hover:bg-gray-100" href="#">Báo cáo về khen thưởng</a></li>
                                    </ul>
                                )}
                            </li>
                            <li>
                                <a className="block py-2 text-gray-700 hover:text-gray-900" href="#" tabIndex="-1" aria-disabled="true">Giới thiệu</a>
                            </li>
                        </ul>
                        <form className="mt-4 lg:mt-0 lg:ml-8 relative">
                            <input className="block w-full pl-4 pr-4 py-2 border rounded-3xl" type="search" placeholder="Tìm kiếm" aria-label="Search" />
                            <button className="absolute inset-y-0 left-0 flex items-center pl-3" type="submit">
                                <span className="material-icons"></span>
                            </button>
                        </form>
                    </div>
                </div>
            </nav>
        </div>
    );
};

export default HeaderComponent;
