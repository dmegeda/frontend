import React, { Component } from 'react';

import 'bootstrap/dist/css/bootstrap.min.css';
import './HeaderComponent.css';

export default class HeaderComponent extends Component {
    render() {
        return (
            <header>
                <nav className="navbar navbar-expand-lg">
                    <a id="logo-title" className="navbar-brand" href="/home">Knowledge <br /> System</a>
                    <ul className="nav-items navbar-nav mr-auto">
                        <li className="nav-item">
                            <a className="nav-link" href="/home">Home</a>
                        </li>
                        <li className="nav-item">
                            <a className="nav-link" href="/statistic">Statistic</a>
                        </li>
                        <li className="nav-item">
                            <a className="nav-link" href="/register">Sign Up</a>
                        </li>
                        <li className="nav-item">
                            <a className="nav-link" href="/login">Sign In</a>
                        </li>
                        <li className="nav-item">
                            <a id="logout-link" className="nav-link">Sign Out</a>
                        </li>
                    </ul>
                    <div className="user-greeting d-flex align-items-center m-0">
                        <p className="m-0">Hello, Guest!</p>
                    </div>
                </nav>
            </header>
        )
    }
}