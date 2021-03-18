import React, { Component } from "react";
import '../auth.scoped.css';

export default class RegistrationComponent extends Component{

    render() {

        return (
            <div className="container-fluid  d-flex align-items-center justify-content-center">
                <form className="
                auth-form
                form-group
                d-flex
                flex-column
                align-items-center
                w-75"
                noValidate>
                <h1 className="m-0">SignUp Form</h1>
                <input className="form-control" placeholder="Username"></input>
                <input className="form-control" name="password" placeholder="Password"></input>
                <input className="form-control" name="confirm password" placeholder="Confirm password"></input>
                <button className="btn" type="submit">Sign Up</button>
                </form>
            </div>
        );
    }
}