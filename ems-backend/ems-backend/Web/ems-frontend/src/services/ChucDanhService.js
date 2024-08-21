import axios from "axios"

const REST_API_BASE_URL = 'https://localhost:7178/api/chucdanh';

export const listChucDanh = (statusFilter = '', pageSize = 10, pageNumber = 1) => {
    const params = {
        pageSize,
        pageNumber,
        ...(statusFilter && { isActive: statusFilter === 'True' })
    };

    return axios.get(REST_API_BASE_URL, { params });
};

export const checkTenChucDanhExists = async (tenChucDanh) => {
    try {
        const response = await axios.get(`${REST_API_BASE_URL}/check-ten?tenChucDanh=${encodeURIComponent(tenChucDanh)}`);
        return response.data.exists;
    } catch (error) {
        console.error("Error checking TenChucDanh exists:", error);
        throw error;
    }
};

export const addChucDanh = async (chucDanh) => {
    try {
        const response = await axios.post(REST_API_BASE_URL, chucDanh);
        return response.data;
    } catch (error) {
        console.error("Error adding ChucDanh:", error);
        throw error;
    }
};

export const getChucDanhById = (id) => axios.get(`${REST_API_BASE_URL}/${id}`);

export const updateChucDanh = (id, chucDanh) => axios.put(`${REST_API_BASE_URL}/${id}`, chucDanh);

export const deleteChucDanh = (id) => axios.delete(`${REST_API_BASE_URL}/${id}`);
