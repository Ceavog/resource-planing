import React, {useState} from 'react';
import SingUpComponent from "../Components/SingUpComponent";
import SignInComponent from "../Components/SignInComponent";

function SignInUp() {
    const [isLoggingIn, setIsLoggingIn] = useState(true);
    return(
        <div className={"d-flex justify-content-center"}>
            <div className={"row align-items-center"}>
                <div>
                    <div className={"row mt-3 "}>
                        <button className={"btn btn-primary col mx-2"} onClick={()=> setIsLoggingIn(false)}>Sign Up</button>
                        <button className={"btn btn-primary col mx-2"} onClick={()=> setIsLoggingIn(true)}>Sign In</button>
                    </div>
                    <div>
                        {isLoggingIn?
                            <SignInComponent></SignInComponent>
                            :
                            <SingUpComponent></SingUpComponent>
                        }
                    </div>
                </div>
            </div>
        </div>
    );
}

export default SignInUp;