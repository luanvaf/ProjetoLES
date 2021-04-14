import axios from 'axios';

const api = axios.create({
    //baseURL: 'http://localhost:5000'
    baseURL: 'http://03890d003fc8.ngrok.io'
});

api.defaults.headers.post['content-type'] = 'application/json';

export default api;
