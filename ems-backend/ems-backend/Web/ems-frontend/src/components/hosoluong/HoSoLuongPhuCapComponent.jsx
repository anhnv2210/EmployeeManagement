import axios from 'axios';
import React, { useEffect, useState } from 'react';
import {useNavigate, useParams } from 'react-router-dom';

const HoSoLuongPhuCapComponent = () => {
    const { hoSoLuongId } = useParams();
    const [phuCaps, setPhuCaps] = useState([]);
    const [hoSoLuongPhuCaps, setHoSoLuongPhuCaps] = useState([]);
    const [newPhuCaps, setNewPhuCaps] = useState([{ phuCapId: '', soTien: '' }]);
    useEffect(() => {
        const fetchHoSoLuongPhuCaps = async () => {
            try {
                const response = await axios.get(`https://localhost:7178/api/hosoluong_phucap/${hoSoLuongId}`);
                if (Array.isArray(response.data)) {
                    setHoSoLuongPhuCaps(response.data); 
                } else {
                    setHoSoLuongPhuCaps([]); 
                }
            } catch (error) {
                console.error('Error fetching HoSoLuongPhuCaps:', error);
                setHoSoLuongPhuCaps([]); 
            }
        };

        fetchHoSoLuongPhuCaps();
    }, [hoSoLuongId]);

    const navigate = useNavigate(); 


    useEffect(() => {
        const fetchPhuCaps = async () => {
            try {
                const response = await axios.get(`https://localhost:7178/api/phucap`);
                if (Array.isArray(response.data.data)) {
                    setPhuCaps(response.data.data); 
                } else {
                    setPhuCaps([]); 
                }
            } catch (error) {
                console.error('Error fetching PhuCaps:', error);
                setPhuCaps([]); 
            }
        };
        fetchPhuCaps();
    }, []);

    const handleAddPhuCap = () => {
        setNewPhuCaps([...newPhuCaps, { phuCapId: '', soTien: '' }]);
    };

    const handlePhuCapChange = (index, event) => {
        const { name, value } = event.target;
        const updatedPhuCaps = newPhuCaps.map((item, i) =>
            i === index ? { ...item, [name]: value } : item
        );
        setNewPhuCaps(updatedPhuCaps);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await axios.post('https://localhost:7178/api/HoSoLuong_PhuCap', newPhuCaps.map(item => ({
                hoSoLuongId,
                phuCapId: item.phuCapId,
                soTien: item.soTien
            })));
            setNewPhuCaps([{ phuCapId: '', soTien: '' }]);
            const response = await axios.get(`https://localhost:7178/api/HoSoLuong_PhuCap/${hoSoLuongId}`);
            setHoSoLuongPhuCaps(response.data);
        } catch (error) {
            console.error(error);
        }
    };

    const isSubmitDisabled = newPhuCaps.some(item => !item.phuCapId || !item.soTien);

    return (
        <div className='bg-gray-100'>
            <div className="container mx-auto p-6 w-2/5 " style={{ minHeight: 'calc(100vh - 150px)' }}>
                <h2 className="text-3xl font-bold text-center mb-6">Phụ Cấp Hồ Sơ Lương</h2>
                <form onSubmit={handleSubmit} className="bg-white p-6 rounded-lg shadow-lg">
                    {newPhuCaps.map((item, index) => (
                        <div key={index} className="mb-4">
                            <label className="block text-gray-700 font-bold mb-2">Phụ Cấp</label>
                            <select 
                                className="form-select border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                                name="phuCapId"
                                value={item.phuCapId}
                                onChange={(e) => handlePhuCapChange(index, e)}
                                required
                            >
                                <option value="">Chọn phụ cấp</option>
                                {phuCaps.map(pc => (
                                    <option key={pc.id} value={pc.id}>{pc.tenPhuCap}</option>
                                ))}
                            </select>
                            <label className="block text-sm font-medium text-gray-700 mt-2">
                                Số Tiền
                                <input
                                    type="number"
                                    step="0.01"
                                    name="soTien"
                                    value={item.soTien}
                                    onChange={(e) => handlePhuCapChange(index, e)}
                                    className="mt-1 block w-full px-3 py-2 bg-white border border-gray-300 rounded-md shadow-sm focus:outline-none focus:ring-indigo-500 focus:border-indigo-500 sm:text-sm"
                                    required
                                />
                            </label>
                        </div>
                    ))}
                    <div className="flex justify-between items-center">
                        <button
                            type="button"
                            onClick={handleAddPhuCap}
                            className="inline-block mb-3 rounded-sm bg-gradient-to-r from-green-500 to-teal-500 px-8 py-2.5 text-base font-semibold text-white shadow-lg transition duration-300 ease-in-out transform hover:scale-105 hover:from-green-600 hover:to-teal-600 focus:outline-none focus:ring-4 focus:ring-green-300 active:scale-95"
                        >
                            Thêm Phụ Cấp
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
                            Lưu Phụ Cấp
                        </button>
                    </div>
                </form>
                <table className="min-w-full bg-white border border-gray-200 rounded-lg overflow-hidden mt-6">
                    <thead className="bg-gray-200 text-gray-600">
                        <tr>
                            <th className="py-2 px-4 border-b text-center">Tên phụ cấp</th>
                            <th className="py-2 px-4 border-b text-center">Số Tiền</th>
                        </tr>
                    </thead>
                    <tbody>
                        {hoSoLuongPhuCaps.length > 0 ? (
                            hoSoLuongPhuCaps.map((item, index) => (
                                <tr key={index}>
                                    <td className="text-center py-2 px-4 border-b">{item.tenPhuCap}</td>
                                    <td className="text-center py-2 px-4 border-b">{item.soTien}</td>
                                </tr>
                            ))
                        ) : (
                            <tr>
                                <td colSpan="2" className="text-center py-4">Không có phụ cấp nào được thêm.</td>
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

export default HoSoLuongPhuCapComponent;
