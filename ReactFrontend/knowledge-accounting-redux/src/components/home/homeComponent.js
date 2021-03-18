import React, { Component } from "react";
import './homeComponent.css';
import TestsList from '../../redux/containers/test-list';

export default class HomeComponent extends Component{

    render() {

        return (
            <div className="container-fluid">
                <h1 className="text-center pt-3">Latest tests</h1>
                <TestsList/>
            </div>
        );
    }
}