import axios from "axios"

const REST_API_BASE_URL = 'https://localhost:7178/api/quanhuyen';

export const listQuanHuyen = (pageSize = 10, pageNumber = 1) => {
    const params = {
        pageSize,
        pageNumber
    };

    return axios.get(REST_API_BASE_URL, { params });
};

export const listQuanHuyenByTinhThanh = (tinhThanhId) => {
    return axios.get(`${REST_API_BASE_URL}/byTinhThanh/${tinhThanhId}`);
};

export const addQuanHuyen = async (quanHuyen) => {
    try {
        const response = await axios.post(REST_API_BASE_URL, quanHuyen);
        return response.data;
    } catch (error) {
        console.error("Error adding QuanHuyen:", error);
        throw error;
    }
};

export const getQuanHuyenById = (id) => axios.get(`${REST_API_BASE_URL}/${id}`);

export const updateQuanHuyen = (id, quanHuyen) => axios.put(`${REST_API_BASE_URL}/${id}`, quanHuyen);

export const deleteQuanHuyen = (id) => axios.delete(`${REST_API_BASE_URL}/${id}`);