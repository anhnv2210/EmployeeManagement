import axios from "axios"

const REST_API_BASE_URL = 'https://localhost:7178/api/loaihopdong';

export const listLoaiHopDong = (statusFilter = '', pageSize = 10, pageNumber = 1) => {
    const params = {
        pageSize,
        pageNumber,
        ...(statusFilter && { isActive: statusFilter === 'True' })
    };

    return axios.get(REST_API_BASE_URL, { params });
};

export const checkTenLoaiHopDongExists = async (tenLoaiHopDong) => {
    try {
        const response = await axios.get(`${REST_API_BASE_URL}/check-ten?tenLoaiHopDong=${encodeURIComponent(tenLoaiHopDong)}`);
        return response.data.exists;
    } catch (error) {
        console.error("Error checking TenLoaiHopDong exists:", error);
        throw error;
    }
};

export const addLoaiHopDong = async (loaiHopDong) => {
    try {
        const response = await axios.post(REST_API_BASE_URL, loaiHopDong);
        return response.data;
    } catch (error) {
        console.error("Error adding LoaiHopDong:", error);
        throw error;
    }
};

export const getLoaiHopDongById = (id) => axios.get(`${REST_API_BASE_URL}/${id}`);

export const updateLoaiHopDong = (id, loaiHopDong) => axios.put(`${REST_API_BASE_URL}/${id}`, loaiHopDong);

export const deleteLoaiHopDong = (id) => axios.delete(`${REST_API_BASE_URL}/${id}`);