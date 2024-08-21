import axios from "axios"

const REST_API_BASE_URL = 'https://localhost:7178/api/nhanvien';

export const listNhanVien = (statusFilter = '', pageSize = 10, pageNumber = 1) => {
    const params = {
        pageSize,
        pageNumber,
        trangThai: statusFilter,
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
        console.error("Error checking email exists:", error);
        throw error;
    }
};

export const addNhanVien = async (nhanVien) => {
    try {
        const response = await axios.post(REST_API_BASE_URL, nhanVien);
        return response.data;
    } catch (error) {
        console.error("Error adding NhanVien:", error);
        throw error;
    }
};

export const getNhanVienById = (id) => axios.get(`${REST_API_BASE_URL}/${id}`);

export const updateNhanVien= (id, nhanVien) => axios.put(`${REST_API_BASE_URL}/${id}`, nhanVien);

export const uploadFile = (file) => {
    const formData = new FormData();
    formData.append('file', file);

    return axios.post('https://localhost:7178/api/uploadfile/upload', formData, {
        headers: {
            'Content-Type': 'multipart/form-data'
        }
    });
};