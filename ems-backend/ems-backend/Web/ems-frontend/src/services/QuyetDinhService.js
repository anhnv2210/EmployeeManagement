import axios from "axios"

const REST_API_BASE_URL = 'https://localhost:7178/api/quyetdinh';

export const listQuyetDinh = (pageSize = 10, pageNumber = 1) => {
    const params = {
        pageSize,
        pageNumber,
    };

    return axios.get(REST_API_BASE_URL, { params });
};


export const addQuyetDinh = async (quyetDinh) => {
    try {
        const response = await axios.post(REST_API_BASE_URL, quyetDinh);
        return response.data;
    } catch (error) {
        console.error("Error adding QuyetDinh:", error);
        throw error;
    }
};

export const getQuyetDinhById = (id) => axios.get(`${REST_API_BASE_URL}/${id}`);

export const updateQuyetDinh= (id, quyetDinh) => axios.put(`${REST_API_BASE_URL}/${id}`, quyetDinh);

export const deleteQuyetDinh = (id) => axios.delete(`${REST_API_BASE_URL}/${id}`);