import axios from "axios"

const REST_API_BASE_URL = 'https://localhost:7178/api/taisan';

export const listTaiSan = (statusFilter = '', pageSize = 10, pageNumber = 1) => {
    const params = {
        pageSize,
        pageNumber,
        ...(statusFilter && { isActive: statusFilter === 'True' })
    };

    return axios.get(REST_API_BASE_URL, { params });
};

export const checkTenTaiSanExists = async (tenTaiSan) => {
    try {
        const response = await axios.get(`${REST_API_BASE_URL}/check-ten?tenTaiSan=${encodeURIComponent(tenTaiSan)}`);
        return response.data.exists;
    } catch (error) {
        console.error("Error checking TenTaiSan exists:", error);
        throw error;
    }
};

export const addTaiSan = async (taiSan) => {
    try {
        const response = await axios.post(REST_API_BASE_URL, taiSan);
        return response.data;
    } catch (error) {
        console.error("Error adding TaiSan:", error);
        throw error;
    }
};

export const getTaiSanById = (id) => axios.get(`${REST_API_BASE_URL}/${id}`);

export const updateTaiSan= (id, taiSan) => axios.put(`${REST_API_BASE_URL}/${id}`, taiSan);

export const deleteTaiSan = (id) => axios.delete(`${REST_API_BASE_URL}/${id}`);