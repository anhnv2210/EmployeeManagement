import axios from "axios"

const REST_API_BASE_URL = 'https://localhost:7178/api/chucdanh';

export const listChucDanh = () => axios.get(REST_API_BASE_URL);