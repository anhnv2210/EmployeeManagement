import axios from "axios"

const REST_API_BASE_URL = 'https://localhost:7178/api/hosoluong';

export const listHoSoLuong = (pageSize = 10, pageNumber = 1) => {
    const params = {
        pageSize,
        pageNumber,
    };

    return axios.get(REST_API_BASE_URL, { params });
};


export const addHoSoLuong = async (hoSoLuong) => {
    try {
        const response = await axios.post(REST_API_BASE_URL, hoSoLuong);
        return response.data;
    } catch (error) {
        console.error("Error adding HoSoLuong:", error);
        throw error;
    }
};