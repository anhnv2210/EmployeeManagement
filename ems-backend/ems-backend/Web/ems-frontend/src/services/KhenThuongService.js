import axios from "axios"

const REST_API_BASE_URL = 'https://localhost:7178/api/khenthuong';

export const listKhenThuong = (pageSize = 10, pageNumber = 1) => {
    const params = {
        pageSize,
        pageNumber
    };

    return axios.get(REST_API_BASE_URL, { params });
};


export const addKhenThuong = async (khenthuong) => {
    try {
        const response = await axios.post(REST_API_BASE_URL, khenthuong);
        return response.data;
    } catch (error) {
        console.error("Error adding KhenThuong:", error);
        throw error;
    }
};

export const getKhenThuongById = (id) => axios.get(`${REST_API_BASE_URL}/${id}`);

export const updateKhenThuong = (id, khenthuong) => axios.put(`${REST_API_BASE_URL}/${id}`, khenthuong);

export const deleteKhenThuong = (id) => axios.delete(`${REST_API_BASE_URL}/${id}`);