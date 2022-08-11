import React from 'react';
import {Link} from 'react-router-dom'

function Navbar() {
    return (
        <>
            <nav>
                <Link to='/Settings'>
                    Settings
                </Link>
                <Link to='/Menu'>
                    Menu
                </Link>
                <Link to='/Orders'>
                    Orders
                </Link>
            </nav>
        </>
    );
}

export default Navbar;