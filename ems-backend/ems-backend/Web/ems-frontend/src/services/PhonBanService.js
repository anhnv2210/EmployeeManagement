import axios from "axios"

const REST_API_BASE_URL = 'https://localhost:7178/api/phongban';

export const listPhongBan = () => axios.get(REST_API_BASE_URL);

export const checkTenPhongBanExists = async (tenPhongBan) => {
    try {
        const response = await axios.get(`${REST_API_BASE_URL}/check-ten?tenPhongBan=${encodeURIComponent(tenPhongBan)}`);
        return response.data.exists;
    } catch (error) {
        console.error("Error checking TenPhongBan exists:", error);
        throw error;
    }
};

export const addPhongBan = async (phongBan) => {
    try {
        const response = await axios.post(REST_API_BASE_URL, phongBan);
        return response.data;
    } catch (error) {
        console.error("Error adding PhongBan:", error);
        throw error;
    }
};

export const getPhongBanById = (id) => axios.get(`${REST_API_BASE_URL}/${id}`);

export const updatePhongBan = (id, phongBan) => axios.put(`${REST_API_BASE_URL}/${id}`, phongBan);

export const deletePhongBan = (id) => axios.delete(`${REST_API_BASE_URL}/${id}`);