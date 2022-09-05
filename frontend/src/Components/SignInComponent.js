import React, {useState} from "react";
import Button from "bootstrap/js/src/button";

function SignInComponent(){
    const [login, setLogin] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');

    const [loginMessage, setLoginMessage] = useState('');
    const [PasswordMessage, setPasswordMessage] = useState('');

    const [isValidForSubmit, setIsValidForSubmit] = useState(true)

    function validateField(){
        let isPasswordValid = false;
        let isLoginValid = false;
        if (password.length < 1){
            setPasswordMessage('password is too short')
            isPasswordValid = false
        }
        else{
            setPasswordMessage('');
            isPasswordValid = true
        }

        if(login.length < 1){
            setLoginMessage("login is too short")
            isLoginValid = false
        }
        else{
            setLoginMessage('');
            isLoginValid = true
        }

        if(isLoginValid && isLoginValid){
            setIsValidForSubmit(true)
        }
        else{
            setIsValidForSubmit(false)
        }


    }

    return(
        <div>
            <form className={"mt-5"}>
                <div className={"form-outline mb-4"}>
                    <input
                        placeholder='Login'
                        className={"form-control"}
                        type={"text"}
                        name={"Name"}
                        value={login}
                        onChange={(e) => setLogin(e.target.value)}
                        onBlur={(e) => validateField()}
                    />
                </div>

                <div className={"form-outline mb-4"}>
                    <input

                        placeholder="Password"
                        className={"form-control"}
                        type={"password"}
                        name={"Name"}
                        value={password}
                        onChange={(e)=> setPassword(e.target.value)}
                        onBlur={(e) => validateField()}

                    />
                </div>

                <h6 className={"text-danger"}>{PasswordMessage}</h6>
                <h6 className={"text-danger"} >{loginMessage}</h6>
                <div className={"d-flex justify-content-center mb-3"}>
                    <input className={"btn btn-primary"} type={"submit"} value={"Sign Up"} disabled={!isValidForSubmit}/>
                </div>
            </form>
        </div>
    );

}

export default SignInComponent;