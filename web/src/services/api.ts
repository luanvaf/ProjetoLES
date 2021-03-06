import axios from 'axios';

const api = axios.create({
    baseURL: 'http://localhost:5000'
});

api.defaults.headers.post['content-type'] = 'application/json';

export default api;
