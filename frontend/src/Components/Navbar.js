import React from 'react';
import {Link} from 'react-router-dom'
import '../Styles/Navbar.css'
function Navbar() {
    return (
        <>
                <nav className="navbar navbar-expand-lg navbar-styles">
                    <Link className="nav-link mx-4 nav-link-hoover" to='/Settings'>
                        Settings
                    </Link>
                    <Link className="nav-link mx-4 nav-link-hoover" to='/Menu'>
                        Menu
                    </Link>
                    <Link className="nav-link mx-4 nav-link-hoover" to='/Orders'>
                        Orders
                    </Link>
                    <Link className="nav-link mx-4 nav-link-hoover" to='/SignInUp'>
                        Logging
                    </Link>
                </nav>
        </>
    );
}

export default Navbar;