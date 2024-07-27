import axios from "axios";

const REST_API_BASE_URL = 'https://localhost:7178/api/chucdanhphongban';

export const getChucDanhTheoPhongBan = async () => {
    try {
        const response = await axios.get(REST_API_BASE_URL);
        return response.data; // Giả sử response.data đã là mảng
    } catch (error) {
        console.error('Error fetching data:', error);
        throw error; // Đảm bảo lỗi được ném ra để có thể xử lý
    }
};
