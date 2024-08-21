import axios from "axios"

const REST_API_BASE_URL = 'https://localhost:7178/api/capphattaisan';

export const listCapPhatTaiSan = (pageSize = 10, pageNumber = 1) => {
    const params = {
        pageSize,
        pageNumber
    };

    return axios.get(REST_API_BASE_URL, { params });
};


export const addCapPhatTaiSan = async (capPhatTaiSan) => {
    try {
        const response = await axios.post(REST_API_BASE_URL, capPhatTaiSan);
        return response.data;
    } catch (error) {
        console.error("Error adding CapPhatTaiSan:", error);
        throw error;
    }
};

export const getCapPhatTaiSanById = (id) => axios.get(`${REST_API_BASE_URL}/${id}`);

export const updateCapPhatTaiSan = (id, capPhatTaiSan) => axios.put(`${REST_API_BASE_URL}/${id}`, capPhatTaiSan);

export const deleteCapPhatTaiSan = (id) => axios.delete(`${REST_API_BASE_URL}/${id}`);