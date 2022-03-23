import axios from 'axios'
import authService from "../components/api-authorization/AuthorizeService";
import {ApplicationPaths, QueryParameterNames} from "../components/api-authorization/ApiAuthorizationConstants";
/*export  async function api() {
  const token = await authService.getAccessToken();
  const makeRequest = axios.create({
    baseURL: "https://localhost:7262",
    headers: {
      Accept: 'application/json',
      headers: !token ? {} : {'Authorization': `Bearer ${token}`},
      'Content-Type': 'application/json'
    }
  })

  makeRequest.interceptors.request.use(function (config) {
    config.headers.Authorization = `Bearer ${token}`
    config.headers.Accept = 'application/json'
     config.headers.ContentType = 'application/json'
    return config
  }, function (error) {
    return Promise.reject(error)
  })

  makeRequest.interceptors.response.use(response => {
        return response
      }, error => {
        const code = error && error.response ? error.response.status : 0
        if (code === 401 || code === 403 || code === 419) {
          window.location.replace('/Identity/Account/Login')
        }
        return Promise.reject(error)
      }
  )

  return makeRequest
}*/

const API = axios.create({
  baseURL: "https://localhost:44497",
  timeout: 10000,
  headers: {
    'Content-Type': 'application/json',
  },
});

API.interceptors.request.use(
    async config => {
      //const token = sessionStorage.getItem('jwt');
      const token = await authService.getAccessToken();
      console.log("token",token)
      if (token) {
       //config.headers.Authorization = `Bearer ${token}`;
          //config.headers=!token ? {} : {'Authorization': `Bearer ${token}`};
          config.headers=!token ? {} : {'Authorization': `Bearer ${token}`};
          //config.headers['Authorization'] = `Bearer ${token}` // new header new token
        
      } else {
        //delete API.defaults.headers.common.Authorization;
          window.location.href = `${ApplicationPaths.Login}?${QueryParameterNames.ReturnUrl}=${encodeURI(window.location.href)}`;

      }
       
      return config;
    },

    error => {
        const code = error && error.response ? error.response.status : 0
        if (code === 401 || code === 403 || code === 419) {
           // window.location.replace('/Identity/Account/Login')
            window.location.href = `${ApplicationPaths.Login}?${QueryParameterNames.ReturnUrl}=${encodeURI(window.location.href)}`;
        }
        return Promise.reject(error)
    }
);

export default API;

 