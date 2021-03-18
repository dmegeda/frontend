import React, { Component } from "react";
import '../auth.scoped.css';


export default class LoginComponent extends Component{
    constructor(props) {
        super(props)
    }

    render() {

        return (
            <div className="container-fluid  d-flex align-items-center justify-content-center">
                <form className="
                    auth-form
                    form-group
                    d-flex
                    flex-column
                    align-items-center
                    w-75" noValidate>
                    <h1 className="m-0">SignIn Form</h1>
                    <input className="form-control" name="name" placeholder="Username"></input>
                    <input className="form-control" type="password" name="password" placeholder="Password"></input>
                    <button class="btn" type="submit">Sign In</button>
                </form>
            </div>
        );
    }
}