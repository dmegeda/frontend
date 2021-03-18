import React, { Component } from "react";
import './HomeComponent.css';
import { tests } from '../../Constants/tests';
import TestsList from '../../Redux/containers/tests-list';

export default class HomeComponent extends Component{
    constructor(props) {
        super(props)
        this.state = {
            tests: tests
        }
    }

    render() {

        return (
            <div className="container-fluid">
                <h1 className="text-center pt-3">Latest tests</h1>
                <TestsList/>
            </div>
        );
    }
}