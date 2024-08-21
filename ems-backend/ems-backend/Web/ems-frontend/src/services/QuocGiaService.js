import axios from "axios"

const REST_API_BASE_URL = 'https://localhost:7178/api/quocgia';

export const listQuocGia = (pageSize = 10, pageNumber = 1) => {
    const params = {
        pageSize,
        pageNumber
    };

    return axios.get(REST_API_BASE_URL, { params });
};

export const checkTenQuocGiaExists = async (tenQuocGia) => {
    try {
        const response = await axios.get(`${REST_API_BASE_URL}/check-ten?tenQuocGia=${encodeURIComponent(tenQuocGia)}`);
        return response.data.exists;
    } catch (error) {
        console.error("Error checking TenQuocGia exists:", error);
        throw error;
    }
};

export const addQuocGia = async (quocGia) => {
    try {
        const response = await axios.post(REST_API_BASE_URL, quocGia);
        return response.data;
    } catch (error) {
        console.error("Error adding QuocGia:", error);
        throw error;
    }
};

export const getQuocGiaById = (id) => axios.get(`${REST_API_BASE_URL}/${id}`);

export const updateQuocGia = (id, quocGia) => axios.put(`${REST_API_BASE_URL}/${id}`, quocGia);

export const deleteQuocGia = (id) => axios.delete(`${REST_API_BASE_URL}/${id}`);