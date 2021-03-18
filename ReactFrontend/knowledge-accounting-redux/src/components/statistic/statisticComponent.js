import React, { Component } from "react";
import StatisticList from "../../redux/containers/statistic-list";
import './statisticComponent.css';

export default class StatisticComponent extends Component{
    constructor(props) {
        super(props)
    }

    render() {
        return (
            <div className="container-fluid">
                <h1 className="text-center pt-3">Your statistics</h1>
                <StatisticList/>             
            </div>
        );
    }
}