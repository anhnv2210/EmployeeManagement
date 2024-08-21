import axios from "axios"

const REST_API_BASE_URL = 'https://localhost:7178/api/nganhang';

export const listNganHang = (statusFilter = '', pageSize = 10, pageNumber = 1) => {
    const params = {
        pageSize,
        pageNumber,
        ...(statusFilter && { isActive: statusFilter === 'True' })
    };

    return axios.get(REST_API_BASE_URL, { params });
};

export const checkTenNganHangExists = async (tenNganHang) => {
    try {
        const response = await axios.get(`${REST_API_BASE_URL}/check-ten?tenNganHang=${encodeURIComponent(tenNganHang)}`);
        return response.data.exists;
    } catch (error) {
        console.error("Error checking TenNganHang exists:", error);
        throw error;
    }
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
        console.error("Error checking email exists:", error);
        throw error;
    }
};

export const addNganHang = async (nganHang) => {
    try {
        const response = await axios.post(REST_API_BASE_URL, nganHang);
        return response.data;
    } catch (error) {
        console.error("Error adding NganHang:", error);
        throw error;
    }
};

export const getNganHangById = (id) => axios.get(`${REST_API_BASE_URL}/${id}`);

export const updateNganHang= (id, nganHang) => axios.put(`${REST_API_BASE_URL}/${id}`, nganHang);

export const deleteNganHang = (id) => axios.delete(`${REST_API_BASE_URL}/${id}`);