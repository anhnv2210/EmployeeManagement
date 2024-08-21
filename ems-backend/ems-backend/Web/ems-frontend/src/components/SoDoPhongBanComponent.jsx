import axios from 'axios';
import React, { useEffect, useState } from 'react'

const SoDoPhongBanComponent = () => {
    const [phongBans, setPhongBans] = useState([]);

    useEffect(() => {
        const fetchPhongBans = async () => {
            try {
                const response = await axios.get('https://localhost:7178/api/phongban');
                setPhongBans(response.data.data);
            } catch (error) {
                console.error('Error fetching PhongBans:', error);
            }
        };

        fetchPhongBans();
    }, []);

    // Tạo cấu trúc cây cho phòng ban
    const renderPhongBanTree = (phongBans) => {
        if (!phongBans.length) return null;

        return (
            <div className="flex flex-col items-center">
                <div className="relative">
                    <div className="absolute top-0 left-1/2 transform -translate-x-1/2 w-2 bg-gray-600 h-8"></div>
                    <div className="absolute top-0 left-1/2 transform -translate-x-1/2 w-2 bg-gray-600 h-8"></div>
                    <div className="relative bg-white p-4 rounded-lg shadow-lg z-10">
                        <h3 className="text-xl font-semibold text-center">VMO Group</h3>
                    </div>
                    <div className="absolute top-0 left-1/2 transform -translate-x-1/2 w-2 bg-gray-600 h-8"></div>
                </div>
                <div className="flex flex-wrap justify-center mt-8">
                    
                    {phongBans.map((phongBan) => (
                        
                        <div key={phongBan.id} className="relative bg-white p-4 rounded-lg shadow-lg mx-4 mb-8">
                            
                            <h4 className="text-lg font-semibold text-center">{phongBan.tenPhongBan}</h4>
                            <p className="text-gray-600 text-center">{phongBan.moTa}</p>
                            
                        </div>
                    ))}
                </div>
            </div>
        );
    };

    return (
        <div className="p-6 bg-gray-100 min-h-screen">
            <h2 className="text-3xl font-bold text-center mb-6">Sơ Đồ Tổ Chức</h2>
            {renderPhongBanTree(phongBans)}
        </div>
    );
}

export default SoDoPhongBanComponent