import axios from "axios"

const REST_API_BASE_URL = 'https://localhost:7178/api/chinhanhnganhang';

export const listChiNhanhNganHang = (statusFilter = '', pageSize = 10, pageNumber = 1) => {
    const params = {
        pageSize,
        pageNumber,
        ...(statusFilter && { isActive: statusFilter === 'True' })
    };

    return axios.get(REST_API_BASE_URL, { params });
};

export const listChiNhanhNganHangByNganHang = (nganHangId) => {
    return axios.get(`${REST_API_BASE_URL}/byNganHang/${nganHangId}`);
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

export const addChiNhanhNganHang = async (chiNhanhNganHang) => {
    try {
        const response = await axios.post(REST_API_BASE_URL, chiNhanhNganHang);
        return response.data;
    } catch (error) {
        console.error("Error adding ChiNhanhNganHang:", error);
        throw error;
    }
};

export const getChiNhanhNganHangById = (id) => axios.get(`${REST_API_BASE_URL}/${id}`);

export const updateChiNhanhNganHang= (id, chiNhanhNganHang) => axios.put(`${REST_API_BASE_URL}/${id}`, chiNhanhNganHang);

export const deleteChiNhanhNganHang = (id) => axios.delete(`${REST_API_BASE_URL}/${id}`);