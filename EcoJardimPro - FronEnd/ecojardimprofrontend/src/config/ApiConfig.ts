import axios from "axios";
import {getToken, removeModoNoturno, removeToken} from '../config/Token';
import Navigation from '../helpers/NavigationHelper'

const httpHeader = {
  headers: {    
    "Access-Control-Allow-Origin": "*",
    "Access-Control-Allow-Headers": "Authorization",
    "Authorization" : "",
    "Access-Control-Allow-Methods": "GET, POST, PUT, DELETE",
  }
};

const http = axios.create({
  baseURL: process.env.NODE_ENV == 'development' ? 'http://localhost:5104' : 'http://localhost:5104',
  headers: httpHeader.headers
});

http.interceptors.request.use(async (config) => {
  const token = getToken();

  if (token) {
    config.headers!["Authorization"] = `Bearer ${token}`;
  }
  return config;
}, (err) => {
  return Promise.reject(err)
})

http.interceptors.response.use((response) => {
  return response
}, (error) => {
  if (error.response.config.url !== 'Login' && error.response.status === 401) {
    removeToken();
    Navigation.navigate('/Login');
  }
  return Promise.reject(error)
})


export default http;