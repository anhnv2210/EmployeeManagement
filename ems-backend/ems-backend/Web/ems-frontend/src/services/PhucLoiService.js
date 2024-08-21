import axios from "axios"

const REST_API_BASE_URL = 'https://localhost:7178/api/phucloi';

export const listPhucLoi = (statusFilter = '', pageSize = 10, pageNumber = 1) => {
    const params = {
        pageSize,
        pageNumber,
        ...(statusFilter && { isActive: statusFilter === 'True' })
    };

    return axios.get(REST_API_BASE_URL, { params });
};

export const checkTenPhucLoiExists = async (tenPhucLoi) => {
    try {
        const response = await axios.get(`${REST_API_BASE_URL}/check-ten?tenPhucLoi=${encodeURIComponent(tenPhucLoi)}`);
        return response.data.exists;
    } catch (error) {
        console.error("Error checking TenPhucLoi exists:", error);
        throw error;
    }
};

export const addPhucLoi = async (phucLoi) => {
    try {
        const response = await axios.post(REST_API_BASE_URL, phucLoi);
        return response.data;
    } catch (error) {
        console.error("Error adding PhucLoi:", error);
        throw error;
    }
};

export const getPhucLoiById = (id) => axios.get(`${REST_API_BASE_URL}/${id}`);

export const updatePhucLoi= (id, phucLoi) => axios.put(`${REST_API_BASE_URL}/${id}`, phucLoi);

export const deletePhucLoi = (id) => axios.delete(`${REST_API_BASE_URL}/${id}`);