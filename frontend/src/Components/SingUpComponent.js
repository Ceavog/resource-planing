import React, {useState} from "react";
import RegisterUser from '../Services/UserService.js'


function SignInComponent(){

const [login, setLogin] = useState('');
const [password, setPassword] = useState('');
const [confirmPassword, setConfirmPassword] = useState('');

const [loginMessage, setLoginMessage] = useState('');
const [confirmPasswordMessage, setConfirmPasswordMessage] = useState('');

const [isValidForSubmit, setIsValidForSubmit] = useState(true)

function validateField(){
    let isPasswordValid = false;
    let isLoginValid = false;
     if (password !== confirmPassword){
         setConfirmPasswordMessage('passwords are not the same')
         isPasswordValid = false
     }
     else{
         setConfirmPasswordMessage('');
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

     if(isLoginValid && isPasswordValid){
         setIsValidForSubmit(true)
     }
     else{
         setIsValidForSubmit(false)
     }


}

    const HandleSubmit = (e) => {
       e.preventDefault();
       RegisterUser(login, password);
    }
    return(
        <div>
            <form className={"mt-5"} onSubmit={HandleSubmit}>
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

                <div className={"form-outline mb-4"}>
                    <input
                        placeholder="Confirm Password"
                        className={"form-control"}
                        type={"password"}
                        name={"Name"}
                        value={confirmPassword}
                        onChange={(e)=>setConfirmPassword(e.target.value)}
                        onBlur={(e) => validateField()}

                    />
                </div>
                <h6 className={"text-danger"}>{confirmPasswordMessage}</h6>
                <h6 className={"text-danger"} >{loginMessage}</h6>
                <div className={"d-flex justify-content-center mb-3"}>
                    <input className={"btn btn-primary"} type={"submit"} value={"Sign Up"} disabled={!isValidForSubmit}/>
                </div>
            </form>
</div>
    );
}

export default SignInComponent;

