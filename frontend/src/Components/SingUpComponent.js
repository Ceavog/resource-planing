import React, {useState} from "react";
import {RegisterUser} from '../Services/UserService.js'
import {useNavigate} from "react-router";
import {useCookies} from "react-cookie";
import { useForm } from "react-hook-form";
import { ErrorMessage } from '@hookform/error-message';
import {toast} from "react-toastify";

function SignInComponent(){
    const [jwtCookies, setJwtCookies, removeJwtCookie] = useCookies(['jwt'])
    const { register, formState: { errors }, handleSubmit, watch } = useForm();
    const watchPassword = watch("password");
    const navigate = useNavigate();

    const onSubmit = (data, e) => {
        e.preventDefault();
        RegisterUser(data.login, data.password).then((x)=>{
            setJwtCookies('jwt', x, {secure: true, sameSite: 'none'})
            navigate('/Home')
        })
    }

    return (
        <div className={"mt-2"}>
            <form onSubmit={handleSubmit(onSubmit)}>

                <div className={"d-flex flex-column"}>
                    <div className={"row mt-2"}>
                        <input
                            placeholder={"login"}
                            type={"text"}
                            {...register(
                                'login',
                                {required: "login is required"})}
                        />
                    </div>
                    <div className={"row mt-2"}>
                        <input
                            placeholder={"password"}
                            type={"password"}
                            {...register(
                                "password",
                                { required: "password is required" })}
                        />
                    </div>
                    <div className={"row mt-2"}>
                        <input

                            placeholder={"confirmPassword"}
                            type={"password"}
                            {...register(
                                "confirmPassword",
                                { validate: value => value === watchPassword || "password is not 123" })}
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
                    <div className={"row text-danger"}>
                        <ErrorMessage
                            errors={errors}
                            name="confirmPassword"
                        />
                    </div>
                    <div className={"mt-4 text-center"}>
                        <input className={"btn btn-primary"} type="submit" value={"submit"}  />
                    </div>
                </div>
            </form>
        </div>
    );
}

export default SignInComponent;

