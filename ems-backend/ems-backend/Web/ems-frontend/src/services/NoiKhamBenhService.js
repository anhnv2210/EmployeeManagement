import axios from "axios"

const REST_API_BASE_URL = 'https://localhost:7178/api/noikhambenh';

export const listNoiKhamBenh = (statusFilter = '', pageSize = 10, pageNumber = 1) => {
    const params = {
        pageSize,
        pageNumber,
        ...(statusFilter && { isActive: statusFilter === 'True' })
    };

    return axios.get(REST_API_BASE_URL, { params });
};


export const checkEmailExists = async (email) => {
    try {
        const response = await axios.get(`${REST_API_BASE_URL}/check-email?email=${encodeURIComponent(email)}`);
        return response.data.exists;
    } catch (error) {
        console.error("Error checking email exists:", error);
        throw error;
    }
};

export const checkSoDienThoaiExists = async (soDienThoai) => {
    try {
        const response = await axios.get(`${REST_API_BASE_URL}/check-sodienthoai?soDienThoai=${encodeURIComponent(soDienThoai)}`);
        return response.data.exists;
    } catch (error) {
        console.error("Error checking so dien thoai exists:", error);
        throw error;
    }
};

export const addNoiKhamBenh = async (noiKhamBenh) => {
    try {
        const response = await axios.post(REST_API_BASE_URL, noiKhamBenh);
        return response.data;
    } catch (error) {
        console.error("Error adding NoiKhamBenh:", error);
        throw error;
    }
};

export const getNoiKhamBenhById = (id) => axios.get(`${REST_API_BASE_URL}/${id}`);

export const updateNoiKhamBenh= (id, noiKhamBenh) => axios.put(`${REST_API_BASE_URL}/${id}`, noiKhamBenh);

export const deleteNoiKhamBenh = (id) => axios.delete(`${REST_API_BASE_URL}/${id}`);