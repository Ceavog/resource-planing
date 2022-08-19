import React from "react";
import Button from "bootstrap/js/src/button";

function SignInComponent(){
    return(
        <div>
            <form className={"mt-5"}>
                <div className={"form-outline mb-4"}>
                    <label className={"form-label"}>Login</label>
                    <input className={"form-control"} type={"text"} name={"Name"}/>
                </div>
                <div className={"form-outline mb-4"}>
                    <label className={"form-label"}>Password</label>
                    <input className={"form-control"} type={"text"} name={"Name"}/>
                    <a href="#!">Forgot password?</a>
                </div>
                <div className={"d-flex justify-content-center mb-3"}>
                    <input className={"btn btn-primary"} type={"submit"} value={"Sign In"}/>
                </div>
            </form>
        </div>
    );
}

export default SignInComponent;