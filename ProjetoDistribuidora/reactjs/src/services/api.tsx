import axios from "axios";


const api = axios.create({
  baseURL: "https://localhost:44327/"
})

export default api;