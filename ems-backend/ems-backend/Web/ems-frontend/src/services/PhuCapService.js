import axios from "axios"

const REST_API_BASE_URL = 'https://localhost:7178/api/phucap';

export const listPhuCap = () => axios.get(REST_API_BASE_URL);

export const checkTenPhuCapExists = async (tenPhuCap) => {
    try {
        const response = await axios.get(`${REST_API_BASE_URL}/check-ten?tenPhuCap=${encodeURIComponent(tenPhuCap)}`);
        return response.data.exists;
    } catch (error) {
        console.error("Error checking TenPhuCap exists:", error);
        throw error;
    }
};

export const addPhuCap = async (phuCap) => {
    try {
        const response = await axios.post(REST_API_BASE_URL, phuCap);
        return response.data;
    } catch (error) {
        console.error("Error adding PhuCap:", error);
        throw error;
    }
};

export const getPhuCapById = (id) => axios.get(`${REST_API_BASE_URL}/${id}`);

export const updatePhuCap = (id, phuCap) => axios.put(`${REST_API_BASE_URL}/${id}`, phuCap);

export const deletePhuCap = (id) => axios.delete(`${REST_API_BASE_URL}/${id}`);