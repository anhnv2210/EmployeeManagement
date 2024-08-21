import axios from "axios"

const REST_API_BASE_URL = 'https://localhost:7178/api/tinhthanh';

export const listTinhThanh = (pageSize = 10, pageNumber = 1) => {
    const params = {
        pageSize,
        pageNumber
    };

    return axios.get(REST_API_BASE_URL, { params });
};

export const listTinhThanhByQuocGia = (quocGiaId) => {
    return axios.get(`${REST_API_BASE_URL}/byQuocGia/${quocGiaId}`);
};

export const checkTenTinhThanhExists = async (tenTinhThanh) => {
    try {
        const response = await axios.get(`${REST_API_BASE_URL}/check-ten?tenTinhThanh=${encodeURIComponent(tenTinhThanh)}`);
        return response.data.exists;
    } catch (error) {
        console.error("Error checking tentinhThanh exists:", error);
        throw error;
    }
};

export const addTInhThanh = async (tinhThanh) => {
    try {
        const response = await axios.post(REST_API_BASE_URL, tinhThanh);
        return response.data;
    } catch (error) {
        console.error("Error adding TInhThanh:", error);
        throw error;
    }
};

export const getTinhThanhById = (id) => axios.get(`${REST_API_BASE_URL}/${id}`);

export const updateTinhThanh = (id, tinhThanh) => axios.put(`${REST_API_BASE_URL}/${id}`, tinhThanh);

export const deleteTinhThanh = (id) => axios.delete(`${REST_API_BASE_URL}/${id}`);