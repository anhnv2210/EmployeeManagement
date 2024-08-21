import axios from 'axios';
import React, { useEffect, useState } from 'react'

const ReminderComponent = () => {
    const [reminders, setReminders] = useState([]);

    useEffect(() => {
        const fetchReminders = async () => {
            try {
                const response = await axios.get('https://localhost:7178/api/reminders');
                setReminders(response.data);
            } catch (error) {
                console.error('Error fetching reminders:', error);
            }
        };

        fetchReminders();
    }, []);

    return (
        <div  className="container mx-auto p-6 bg-gray-100 min-h-screen" style={{ minHeight: 'calc(100vh - 150px)' }}> 
            <h2 className="text-3xl font-bold text-center mb-6">Danh Sách Nhắc Nhở</h2>
            <table className="min-w-full bg-white border border-gray-200 rounded-lg overflow-hidden">
                <thead className="bg-gray-200 text-gray-600">
                    <tr>
                        <th className="py-2 px-4 border-b text-center">Tên Nhân Viên</th>
                        <th className="py-2 px-4 border-b text-center">Loại Sự Kiện</th>
                        <th className="py-2 px-4 border-b text-center">Ngày Nhắc Nhở</th>
                    </tr>
                </thead>
                <tbody>
                    {reminders.length > 0 ? (
                        reminders.map((reminder, index) => (
                            <tr key={index}>
                                <td className="text-center py-2 px-4 border-b">{reminder.hoTenNhanVien}</td>
                                <td className="text-center py-2 px-4 border-b">{reminder.loaiSuKien === "ContractExpiration" ? "Hết hạn hợp đồng" : "Sinh nhật" }</td>
                                <td className="text-center py-2 px-4 border-b">{new Date(reminder.NgayCuThe).toLocaleDateString()}</td>
                            </tr>
                        ))
                    ) : (
                        <tr>
                            <td colSpan="3" className="text-center py-4">Không có nhắc nhở nào.</td>
                        </tr>
                    )}
                </tbody>
            </table>
        </div>
    );
}
export default ReminderComponent;