import axios from "axios"

const REST_API_BASE_URL = 'https://localhost:7178/api/kyluat';

export const listKyLuat = (pageSize = 10, pageNumber = 1) => {
    const params = {
        pageSize,
        pageNumber
    };

    return axios.get(REST_API_BASE_URL, { params });
};


export const addKyLuat = async (kyluat) => {
    try {
        const response = await axios.post(REST_API_BASE_URL, kyluat);
        return response.data;
    } catch (error) {
        console.error("Error adding KyLuat:", error);
        throw error;
    }
};

export const getKyLuatById = (id) => axios.get(`${REST_API_BASE_URL}/${id}`);

export const updateKyLuat = (id, kyluat) => axios.put(`${REST_API_BASE_URL}/${id}`, kyluat);

export const deleteKyLuat = (id) => axios.delete(`${REST_API_BASE_URL}/${id}`);