const axios = require('axios').default;

const AxiosInstance = axios.create({
    baseURL: 'https://localhost:7161'
})

function RegisterUser(login, password){

    AxiosInstance.post('/RegisterUser',{
        login: login,
        password: password,
    }).then(response=>{
        console.log(response)
    })

    // fetch("https://localhost:7161/RegisterUser",
    // {
    //     method: `POST`,
    //         body: {
    //         login: `${login}`,
    //             password: `${password}`,
    //     }
    // }}).then(res => {
    //     console.log(res.data)
    // }).catch(error => {
    //     throw error
    // });

    console.log("im in register user")
    console.log(`${login}`)
    console.log(`${password}`)
}

export default  RegisterUser ;