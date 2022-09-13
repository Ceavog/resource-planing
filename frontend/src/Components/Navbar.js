import React, {useState, useEffect} from 'react';
import {Link} from "react-router-dom"
import {useNavigate} from "react-router";
import '../Styles/Navbar.css'
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import { faUser, faRightFromBracket} from '@fortawesome/free-solid-svg-icons'
import {useCookies} from "react-cookie";
import {Dropdown} from "react-bootstrap";
import {GetLogin} from '../Services/UserService.js'
function Navbar() {

    const [cookies, setCookies, removeCookies] = useCookies();
    const [login, setLogin] = useState()
    useEffect(()=>{
        if(cookies.jwt !== undefined){
            GetLogin(cookies.jwt).then((x)=>{
                setLogin(x)
            })
        }else {
            setLogin(" user")
        }
    });

    const navigate = useNavigate();
    const logOut = () =>{
        removeCookies('jwt');
        navigate('/SignInUp')
    }



    return (
        <>
                <nav className="navbar navbar-expand-lg navbar-styles d-flex">
                        {cookies.jwt !== undefined &&
                            <>
                                <Link className="nav-link mx-4 nav-link-hoover" to='/Settings'>
                                    Settings
                                </Link>
                                <Link className="nav-link mx-4 nav-link-hoover" to='/Menu'>
                                    Menu
                                </Link>
                                <Link className="nav-link mx-4 nav-link-hoover" to='/Orders'>
                                    Orders
                                </Link>
                            </>
                        }
                    <Link className="nav-link mx-4 nav-link-hoover ms-auto " to='/SignInUp'>
                        <>
                            <Dropdown>
                                <Dropdown.Toggle>
                                    {`hi ${login} `}
                                    <FontAwesomeIcon icon={faUser} />
                                </Dropdown.Toggle>
                                <Dropdown.Menu>
                                    <Dropdown.Item onClick={logOut}>Logout</Dropdown.Item>
                                    <Dropdown.Item >Settings</Dropdown.Item>
                                </Dropdown.Menu>
                            </Dropdown>
                        </>
                    </Link>
                </nav>
        </>
    );
}

export default Navbar;