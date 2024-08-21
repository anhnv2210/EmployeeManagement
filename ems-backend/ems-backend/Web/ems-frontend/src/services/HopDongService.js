import axios from "axios"

const REST_API_BASE_URL = 'https://localhost:7178/api/hopdong';

export const listHopDong = (pageSize = 10, pageNumber = 1) => {
    const params = {
        pageSize,
        pageNumber,
    };

    return axios.get(REST_API_BASE_URL, { params });
};


export const addHopDong = async (hopDong) => {
    try {
        const response = await axios.post(REST_API_BASE_URL, hopDong);
        return response.data;
    } catch (error) {
        console.error("Error adding HopDong:", error);
        throw error;
    }
};

export const getHopDongById = (id) => axios.get(`${REST_API_BASE_URL}/${id}`);

export const updateHopDong= (id, hopDong) => axios.put(`${REST_API_BASE_URL}/${id}`, hopDong);

export const deleteHopDong = (id) => axios.delete(`${REST_API_BASE_URL}/${id}`);