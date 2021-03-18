import React, { Component } from "react";
import './statisticComponent.css';

export default class StatisticComponent extends Component{
    constructor(props) {
        super(props)

        const statistics = JSON.parse(localStorage.getItem("statistics"));
        console.log(statistics);
        this.state = {
            statistics: Array.from(statistics)
        };
    }

    roundNumber(numberToRound, symbolsCount) {
        let x = Math.pow(10, symbolsCount);
        return (parseInt(String(numberToRound * x))) / x;
      }

    render() {
        console.log(this.state.statistics);
        const statistics = this.state.statistics.map((statistic) => <tr key={this.state.statistics.indexOf(statistic)}>
            <td>{statistic.testName}</td>
            <td>{statistic.isPassed ? "Completed" : "Failed"}</td>
            <td>{this.roundNumber(statistic.score, 2)}%</td>
        </tr>);

        return (
            <div className="container-fluid">
                <h1 className="text-center pt-3">Your statistics</h1>
                <table className="table">
                    <tbody>
                        <tr>
                        <th>Test name</th>
                        <th>Status</th>
                        <th>Score</th>
                        </tr>
                        {statistics}
                    </tbody> 
                </table>
            </div>
        );
    }
}