import {useCookies} from "react-cookie";
import data from "bootstrap/js/src/dom/data";

const axios = require('axios').default;

const AxiosInstance = axios.create({
    baseURL: 'https://localhost:7161',
})

function GetMenuCategoriesWithPositions(userId, jwt){
    return AxiosInstance.get('/CategoryWithMenuPositions',{params: {
        userId: userId},
        headers:{
            "Authorization":`Bearer ${jwt}`
        }
    }).then(response =>{
        return response;
    })
        .catch(error => {throw error});
}

export default GetMenuCategoriesWithPositions;