import axios from 'axios';
import React, { useEffect, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom';

const HoSoLuongPhucLoiComponent = () => {
    const { hoSoLuongId } = useParams();
    const [phucLois, setPhucLois] = useState([]);
    const [hoSoLuongPhucLois, setHoSoLuongPhucLois] = useState([]);
    const [newPhucLois, setNewPhucLois] = useState([{ phucLoiId: '' }]);
    useEffect(() => {
        const fetchHoSoLuongPhucLois = async () => {
            try {
                const response = await axios.get(`https://localhost:7178/api/hosoluong_phucloi/${hoSoLuongId}`);
                if (Array.isArray(response.data)) {
                    setHoSoLuongPhucLois(response.data); 
                } else {
                    setHoSoLuongPhucLois([]); 
                }
            } catch (error) {
                console.error('Error fetching HoSoLuongPhucLois:', error);
                setHoSoLuongPhucLois([]); 
            }
        };

        fetchHoSoLuongPhucLois();
    }, [hoSoLuongId]);

    const navigate = useNavigate(); 


    useEffect(() => {
        const fetchPhucLois = async () => {
            try {
                const response = await axios.get(`https://localhost:7178/api/phucloi`);
                if (Array.isArray(response.data.data)) {
                    setPhucLois(response.data.data); 
                } else {
                    setPhucLois([]); 
                }
            } catch (error) {
                console.error('Error fetching PhucLois:', error);
                setPhucLois([]); 
            }
        };
        fetchPhucLois();
    }, []);

    const handleAddPhucLoi = () => {
        setNewPhucLois([...newPhucLois, { phucLoiId: '' }]);
    };

    const handlePhucLoiChange = (index, event) => {
        const { name, value } = event.target;
        const updatedPhucLois = newPhucLois.map((item, i) =>
            i === index ? { ...item, [name]: value } : item
        );
        setNewPhucLois(updatedPhucLois);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await axios.post('https://localhost:7178/api/HoSoLuong_PhucLoi', newPhucLois.map(item => ({
                hoSoLuongId,
                phucLoiId: item.phucLoiId,
            })));
            setNewPhucLois([{ phucLoiId: ''}]);
            const response = await axios.get(`https://localhost:7178/api/HoSoLuong_PhucLoi/${hoSoLuongId}`);
            setHoSoLuongPhucLois(response.data);
        } catch (error) {
            console.error(error);
        }
    };

    const isSubmitDisabled = newPhucLois.some(item => !item.phucLoiId);

    return (
        <div className='bg-gray-100'>
            <div className="container mx-auto p-6 w-1/4 " style={{ minHeight: 'calc(100vh - 150px)' }}>
                <h2 className="text-3xl font-bold text-center mb-6">Phúc Lợi Hồ Sơ Lương</h2>
                <form onSubmit={handleSubmit} className="bg-white p-6 rounded-lg shadow-lg">
                    {newPhucLois.map((item, index) => (
                        <div key={index} className="mb-4">
                            <label className="block text-gray-700 font-bold mb-2">Phụ Cấp</label>
                            <select 
                                className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                                name="phucLoiId"
                                value={item.phucLoiId}
                                onChange={(e) => handlePhucLoiChange(index, e)}
                                required
                            >
                                <option value="">Chọn phúc lợi</option>
                                {phucLois.map(pl => (
                                    <option key={pl.id} value={pl.id}>{pl.tenPhucLoi}</option>
                                ))}
                            </select>
                        </div>
                    ))}
                    <div className="flex justify-between items-center">
                        <button
                            type="button"
                            onClick={handleAddPhucLoi}
                            className="inline-block mb-3 rounded-sm bg-gradient-to-r from-green-500 to-teal-500 px-8 py-2.5 text-base font-semibold text-white shadow-lg transition duration-300 ease-in-out transform hover:scale-105 hover:from-green-600 hover:to-teal-600 focus:outline-none focus:ring-4 focus:ring-green-300 active:scale-95"
                        >
                            Thêm Phúc Lợi
                        </button>
                        <button
                            type="submit"
                            disabled={isSubmitDisabled}
                            className={`inline-block mb-3 rounded-sm px-8 py-2.5 text-base font-semibold shadow-lg transition duration-300 ease-in-out transform focus:outline-none focus:ring-4 ${
                                isSubmitDisabled 
                                    ? 'bg-gray-400 text-gray-700 cursor-not-allowed'
                                    : 'bg-gradient-to-r from-blue-500 to-purple-500 text-white hover:scale-105 hover:from-blue-600 hover:to-purple-600 active:scale-95'
                            }`}
                        >
                            Lưu Phúc Lợi
                        </button>
                    </div>
                </form>
                <table className="min-w-full bg-white border border-gray-200 rounded-lg overflow-hidden mt-6">
                    <thead className="bg-gray-200 text-gray-600">
                        <tr>
                            <th className="py-2 px-4 border-b text-center">Tên phúc lợi</th>
                        </tr>
                    </thead>
                    <tbody>
                        {hoSoLuongPhucLois.length > 0 ? (
                            hoSoLuongPhucLois.map((item, index) => (
                                <tr key={index}>
                                    <td className="py-2 px-4 border-b">{item.tenPhucLoi}</td>
                                </tr>
                            ))
                        ) : (
                            <tr>
                                <td colSpan="2" className="text-center py-4">Không có phúc lợi nào được thêm.</td>
                            </tr>
                        )}
                    </tbody>
                </table>
                <div className="flex justify-end mt-5">
                    <button type="button" className="btn bg-gray-500 hover:bg-gray-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" onClick={() => navigate('/ho-so-luong')}>Trở lại</button>
                </div>
            </div>
        </div>
    );
}

export default HoSoLuongPhucLoiComponent