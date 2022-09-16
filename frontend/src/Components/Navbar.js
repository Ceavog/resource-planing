import React, {useState, useEffect} from 'react';
import {Link} from "react-router-dom"
import {useNavigate} from "react-router";
import '../Styles/Navbar.css'
import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import { faUser } from '@fortawesome/free-solid-svg-icons'
import {useCookies} from "react-cookie";
import {Dropdown, NavItem} from "react-bootstrap";
import jwt_decode, {JwtPayload} from "jwt-decode";



function Navbar() {

    const [cookies, setCookies, removeCookies] = useCookies();
    const [login, setLogin] = useState()

    useEffect(()=>{
        if(cookies.jwt !== undefined){
            const decodedHeader = jwt_decode(cookies.jwt);
            setLogin(decodedHeader.userLogin);
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
                    <Link className="nav-link mx-4 nav-link-hoover" to={'/Home'}>
                        Home
                    </Link>
                        {cookies.jwt !== undefined &&
                            <>
                                <Link className="nav-link mx-4 nav-link-hoover" to='/Menu'>
                                    Menu
                                </Link>
                                <Link className="nav-link mx-4 nav-link-hoover" to='/Orders'>
                                    Orders
                                </Link>
                            </>
                        }
                        <NavItem className="ms-auto">
                        </NavItem>
                    <NavItem className="nav-link mx-4 ms-auto d-flex">
                        <>
                             <div className="d-flex flex-row">
                                    <p className="m-2">Hello {login}!</p>
                                     <Dropdown>
                                         <Dropdown.Toggle>
                                             <FontAwesomeIcon icon={faUser} />
                                         </Dropdown.Toggle>
                                         <Dropdown.Menu>
                                             {cookies.jwt === undefined && <Dropdown.Item onClick={() => navigate('/SignInUp')}>Login</Dropdown.Item>}
                                             {cookies.jwt !== undefined && <Dropdown.Item onClick={logOut}>Logout</Dropdown.Item>}
                                             {cookies.jwt !== undefined && <Dropdown.Item onClick={() => navigate('/Settings')} >Settings</Dropdown.Item>}
                                         </Dropdown.Menu>
                                     </Dropdown>
                             </div>

                        </>
                    </NavItem>
                </nav>
        </>
    );
}

export default Navbar;