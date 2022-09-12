import data from "bootstrap/js/src/dom/data";

const axios = require('axios').default;


const AxiosInstance = axios.create({
    baseURL: 'https://localhost:7161'
})

//registerUser saves user in db with hashed password
//and login user with provided credentials

function RegisterUser(login, password){
    return AxiosInstance.post('/RegisterUser', {
        login: login,
        password: password,
    }).then(response =>{
            return response.data;
        })
        .catch(error => {throw error});

}

//login user returns json web token (jwt) with all required data

function LoginUser(login, password) {
   return AxiosInstance.post('/LoginUser', {
        login: login,
        password: password,
    }).then(respose => {
        return respose.data;
    }).catch(error => {
        throw error
    })
}

function GetLogin(jwt){
    return AxiosInstance.get('/GetLogin',
        {
            params:
                {
                    jwt:jwt
                }
    }).then(respose => {
        return respose.data;
    }).catch(error => {
        throw error
    })
}
export {RegisterUser, LoginUser, GetLogin};
