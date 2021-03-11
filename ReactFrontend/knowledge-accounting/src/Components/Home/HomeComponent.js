import React, { Component } from "react";
import * as moment from 'moment';
import { NavLink } from 'react-router-dom';
import './HomeComponent.css';
import { tests } from '../../Constants/tests';

export default class HomeComponent extends Component{
    constructor(props) {
        super(props)
        this.state = {
            tests: tests
        }
    }

    render() {

        const items = this.state.tests.map((test) => <div key={test.id} className="single-item">
            <p id="test-title" className="title">{test.title}</p>
            <p className="right-title">{moment(test.startDate).format("DD/MM/yyyy")}
          - {moment(test.deadline).format("DD/MM/yyyy")}</p>
            <NavLink id="details-link" to={`/test/${test.id}`}>
            <button id="details-btn" className="btn">Details</button>
            </NavLink>
        </div>);

        return (
            <div className="container-fluid">
                <h1 className="text-center pt-3">Latest tests</h1>
                <div className="tests-container">
                    {items}
                </div>
            </div>
        );
    }
}