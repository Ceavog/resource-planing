import React from "react";


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
                </div>

                <div className={"form-outline mb-4"}>
                    <label className={"form-label"}>Confirm Password</label>
                    <input className={"form-control"} type={"text"} name={"Name"}/>
                </div>
                <div className={"d-flex justify-content-center mb-3"}>
                    <input className={"btn btn-primary"} type={"submit"} value={"Sign Up"}/>
                </div>
            </form>
</div>
    );
}

export default SignInComponent;

