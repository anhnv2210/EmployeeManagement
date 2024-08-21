import React from 'react'
import { useNavigate } from 'react-router-dom';

const HomeComponent = () => {
  const navigate = useNavigate();

    const handleChiTietPhuCapClick = () => {
        navigate('/phu-cap');
    }

    const handleChiTietPhucLoiClick = () => {
        navigate('/phuc-loi');
    }

    const handleChucDanhPhongBanClick = () => {
        navigate('/chuc-danh-phong-ban');
    }

    const handleReminderClick = () => {
      navigate('/reminder');
    }

    const handleSoDoClick = () => {
      navigate('/so-do');
    }

  return (
      <div className='bg-gray-100'>
        <div className='ml-40 mr-40 pt-6 px-10'>
          <div><img src='https://www.pace.edu.vn/uploads/news/2023/04/3-chuc-nang-cua-quan-tri-nhan-su.jpg' style={{ width: '100%' }}/></div>
          <div class="grid grid-cols-3 gap-3 mt-10">
          <div className="block rounded-lg bg-white p-8 mx-4 my-6 text-gray-800 shadow-md dark:bg-gray-800 dark:text-gray-200">
              <h5 className="mb-4 text-3xl font-bold leading-tight text-gray-900 dark:text-white">
              Thông tin chi tiết Phụ cấp
              </h5>
              <p className="mb-6 text-base text-gray-700 dark:text-gray-300">
              Khám phá thông tin chi tiết về các phụ cấp dành cho nhân viên.
              </p>
              <button onClick={handleChiTietPhuCapClick}
                type="button"
                className="inline-block rounded-full bg-gradient-to-r from-blue-500 to-purple-500 px-8 py-2.5 text-sm font-semibold text-white shadow-lg transition duration-300 ease-in-out transform hover:scale-105 hover:from-blue-600 hover:to-purple-600 focus:outline-none focus:ring-4 focus:ring-blue-300 active:scale-95">
                Xem thêm
              </button>
            </div>

            <div className="block rounded-lg bg-white p-8 mx-4 my-6 text-gray-800 shadow-md dark:bg-gray-800 dark:text-gray-200">
              <h5 className="mb-4 text-3xl font-bold leading-tight text-gray-900 dark:text-white">
              Thông tin chi tiết Chế độ phúc lợi
              </h5>
              <p className="mb-6 text-base text-gray-700 dark:text-gray-300">
              Khám phá thông tin chi tiết về các phúc lợi dành cho nhân viên.
              </p>
              <button onClick={handleChiTietPhucLoiClick}
                type="button"
                className="inline-block rounded-full bg-gradient-to-r from-blue-500 to-purple-500 px-8 py-2.5 text-sm font-semibold text-white shadow-lg transition duration-300 ease-in-out transform hover:scale-105 hover:from-blue-600 hover:to-purple-600 focus:outline-none focus:ring-4 focus:ring-blue-300 active:scale-95">
                Xem thêm
              </button>
            </div>

            <div className="block rounded-lg bg-white p-8 mx-4 my-6 text-gray-800 shadow-md dark:bg-gray-800 dark:text-gray-200">
              <h5 className="mb-4 text-3xl font-bold leading-tight text-gray-900 dark:text-white">
              Sơ đồ tổ chức theo Phòng ban
              </h5>
              <p className="mb-6 text-base text-gray-700 dark:text-gray-300">
              Hiển thị cấu trúc quản lý và các phòng ban trong công ty.
              </p>
              <button onClick={handleSoDoClick}
                type="button"
                className="inline-block rounded-full bg-gradient-to-r from-blue-500 to-purple-500 px-8 py-2.5 text-sm font-semibold text-white shadow-lg transition duration-300 ease-in-out transform hover:scale-105 hover:from-blue-600 hover:to-purple-600 focus:outline-none focus:ring-4 focus:ring-blue-300 active:scale-95">
                Xem thêm
              </button>
            </div>
            
            <div className="block rounded-lg bg-white p-8 mx-4 my-6 text-gray-800 shadow-md dark:bg-gray-800 dark:text-gray-200">
              <h5 className="mb-4 text-3xl font-bold leading-tight text-gray-900 dark:text-white">
              Chức danh theo đơn vị
              </h5>
              <p className="mb-6 text-base text-gray-700 dark:text-gray-300">
              Hiển thị các vị trí công việc được phân bổ trong từng phòng ban.
              </p>
              <button onClick={handleChucDanhPhongBanClick} type="button" className="inline-block rounded-full bg-gradient-to-r from-blue-500 to-purple-500 px-8 py-2.5 text-sm font-semibold text-white shadow-lg transition duration-300 ease-in-out transform hover:scale-105 hover:from-blue-600 hover:to-purple-600 focus:outline-none focus:ring-4 focus:ring-blue-300 active:scale-95">
                Xem thêm
              </button>
            </div>

            <div className="block rounded-lg bg-white p-8 mx-4 my-6 text-gray-800 shadow-md dark:bg-gray-800 dark:text-gray-200">
              <h5 className="mb-4 text-3xl font-bold leading-tight text-gray-900 dark:text-white">
                Số ngày Reminder
              </h5>
              <p className="mb-6 text-base text-gray-700 dark:text-gray-300">
                Cho biết thời gian cần thiết để nhắc nhở trước một sự kiện quan trọng.
              </p>
              <button onClick={handleReminderClick}
                type="button"
                className="inline-block rounded-full mt-2 bg-gradient-to-r from-blue-500 to-purple-500 px-8 py-2.5 text-sm font-semibold text-white shadow-lg transition duration-300 ease-in-out transform hover:scale-105 hover:from-blue-600 hover:to-purple-600 focus:outline-none focus:ring-4 focus:ring-blue-300 active:scale-95">
                Xem thêm
              </button>
            </div>

            {/* <div className="block rounded-lg bg-white p-8 mx-4 my-6 text-gray-800 shadow-md dark:bg-gray-800 dark:text-gray-200">
              <h5 className="mb-4 text-3xl font-bold leading-tight text-gray-900 dark:text-white">
                Báo cáo
              </h5>
              <p className="mb-6 text-base text-gray-700 dark:text-gray-300">
               Cho biết thông tin chi tiết về báo cáo thống kê: Nhân sự biến động theo tháng, năm; hợp đồng lao động ...
              </p>
              <button
                type="button"
                className="inline-block rounded-full mt-3 bg-gradient-to-r from-blue-500 to-purple-500 px-8 py-2.5 text-sm font-semibold text-white shadow-lg transition duration-300 ease-in-out transform hover:scale-105 hover:from-blue-600 hover:to-purple-600 focus:outline-none focus:ring-4 focus:ring-blue-300 active:scale-95">
                Xem thêm
              </button>
            </div> */}

          </div>
        </div>
      </div>
  );
}

export default HomeComponent