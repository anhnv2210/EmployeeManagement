import axios from "axios"

const REST_API_BASE_URL = 'https://localhost:7178/api/nghiviec';

export const listNghiViec= (pageSize = 10, pageNumber = 1) => {
    const params = {
        pageSize,
        pageNumber
    };

    return axios.get(REST_API_BASE_URL, { params });
};


export const addNghiViec = async (nghiViec) => {
    try {
        const response = await axios.post(REST_API_BASE_URL, nghiViec);
        return response.data;
    } catch (error) {
        console.error("Error adding NghiViec:", error);
        throw error;
    }
};

export const getNghiViecById = (id) => axios.get(`${REST_API_BASE_URL}/${id}`);

export const updateNghiViec = (id, nghiViec) => axios.put(`${REST_API_BASE_URL}/${id}`, nghiViec);

export const deleteNghiViec = (id) => axios.delete(`${REST_API_BASE_URL}/${id}`);