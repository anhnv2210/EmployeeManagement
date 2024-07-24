import axios from "axios"

const REST_API_BASE_URL = 'https://localhost:7178/api/nhanvien';

export const listNhanVien = () => axios.get(REST_API_BASE_URL);