import axios from "axios"

const REST_API_BASE_URL = 'https://localhost:7178/api/xaphuong';

export const listXaPhuong = (pageSize = 10, pageNumber = 1) => {
    const params = {
        pageSize,
        pageNumber
    };

    return axios.get(REST_API_BASE_URL, { params });
};

export const listXaPhuongByQuanHuyen = (quanHuyenId) => {
    return axios.get(`${REST_API_BASE_URL}/byQuanHuyen/${quanHuyenId}`);
};

export const addXaPhuong = async (xaPhuong) => {
    try {
        const response = await axios.post(REST_API_BASE_URL, xaPhuong);
        return response.data;
    } catch (error) {
        console.error("Error adding XaPhuong:", error);
        throw error;
    }
};

export const getXaPhuongById = (id) => axios.get(`${REST_API_BASE_URL}/${id}`);

export const updateXaPhuong = (id, xaPhuong) => axios.put(`${REST_API_BASE_URL}/${id}`, xaPhuong);

export const deleteXaPhuong = (id) => axios.delete(`${REST_API_BASE_URL}/${id}`);