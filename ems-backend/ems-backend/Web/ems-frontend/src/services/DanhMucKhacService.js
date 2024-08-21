import axios from "axios"

const REST_API_BASE_URL = 'https://localhost:7178/api/danhmuckhac';

export const listDanhMucKhac = (statusFilter = '', pageSize = 10, pageNumber = 1) => {
    const params = {
        pageSize,
        pageNumber,
        ...(statusFilter && { isActive: statusFilter === 'True' })
    };

    return axios.get(REST_API_BASE_URL, { params });
};


export const addDanhMucKhac = async (danhMucKhac) => {
    try {
        const response = await axios.post(REST_API_BASE_URL, danhMucKhac);
        return response.data;
    } catch (error) {
        console.error("Error adding DanhMucKhacs:", error);
        throw error;
    }
};

export const getDanhMucKhacById = (id) => axios.get(`${REST_API_BASE_URL}/${id}`);

export const updateDanhMucKhac= (id, danhMucKhac) => axios.put(`${REST_API_BASE_URL}/${id}`, danhMucKhac);

export const deleteDanhMucKhac = (id) => axios.delete(`${REST_API_BASE_URL}/${id}`);