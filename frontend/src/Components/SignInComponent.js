import React, {useState} from "react";
import {LoginUser, RegisterUser} from "../Services/UserService";
import {useCookies} from "react-cookie";
import {useNavigate} from "react-router";
import { useForm } from "react-hook-form";
import { ErrorMessage } from '@hookform/error-message';
import {toast, ToastContainer} from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';

function SignInComponent(){
    const [jwtCookies, setJwtCookies, removeJwtCookie] = useCookies(['jwt'])
    const { register, formState: { errors }, handleSubmit, reset } = useForm({
        defaultValues:{
            login: "",
            password: ""
        }
    });

    const notify = () => toast("Login or password are incorrect :(");
    const navigate = useNavigate();
    const onSubmit = (data, e) => {
        e.preventDefault();
        LoginUser(data.login, data.password).then((x)=>{
            setJwtCookies('jwt', x, {secure: true, sameSite: 'none'})
            navigate('/Home')

        }).catch(error => {
            console.log(error)
        }).finally(
            notify,
            reset()
        );

    }


    return(
        <div className={"mt-2"}>
            <form onSubmit={handleSubmit(onSubmit)}>

                <div className={"d-flex flex-column"}>
                    <div className={"row mt-2"}>
                        <input
                            id={"loginInput"}
                            placeholder={"login"}
                            type={"text"}
                            {...register(
                                'login',
                                {required: "login is required"})}
                        />
                    </div>
                    <div className={"row mt-2"}>
                        <input
                            id={"passwordInput"}
                            placeholder={"password"}
                            type={"password"}
                            {...register(
                                "password",
                                { required: "password is required" })}
                        />
                    </div>

                    <div className={"row text-danger"}>
                        <ErrorMessage
                            errors={errors}
                            name="password"
                        />
                    </div>
                    <div className={"row text-danger"}>
                        <ErrorMessage
                            errors={errors}
                            name="login"
                        />
                    </div>
                    <div className={"mt-4 text-center"}>
                        <input className={"btn btn-primary"} type="submit" value={"submit"}  />
                    </div>
                </div>
            </form>
            <ToastContainer/>
        </div>
    );

}

export default SignInComponent;
