import {Navigate, Outlet} from "react-router";
import {useCookies} from "react-cookie";

const PrivateRoutes = () =>{
    const [cookies] = useCookies()
    let auth = {'token': true}
    if(cookies.jwt !== undefined){
        auth.token = true
    }else{
        auth.token = false
    }

    return (
    auth.token ? <Outlet/> : <Navigate to={"/SignInUp"}/>
    )
}
export default PrivateRoutes