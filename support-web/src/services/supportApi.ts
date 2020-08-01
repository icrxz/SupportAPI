import axios from 'axios';

const supportApi = axios.create({
  baseURL: process.env.VUE_APP_API_GATEWAY_URL,
});

export default supportApi;
