import React, { Component } from 'react';
import { connect } from 'react-redux';
import { setStatisticsList } from '../actions/actionCreators/statistics';

class StatisticList extends Component {
    
    async componentDidMount() {
        const statisticList = JSON.parse(localStorage.getItem("statistics"));
        this.props.setStatisticsList(statisticList);
    }

    render() {

        return (
            <div>
                <table className="table text-center">
                    <tbody>
                        {this.showStatisticsTable()}
                    </tbody>         
                </table>
            </div>
        );
    }

    showStatisticsTable() {
        
        const statisticsView = this.props.statistics.map((statistic) => <tr key={this.props.statistics.indexOf(statistic)}>
            <td>{statistic.testName}</td>
            <td>{statistic.isPassed ? "Completed" : "Failed"}</td>
            <td>{this.roundNumber(statistic.score, 2)}%</td>
        </tr>);
        return statisticsView;
    }

    roundNumber(numberToRound, symbolsCount) {
        let x = Math.pow(10, symbolsCount);
        return (parseInt(String(numberToRound * x))) / x;
    }
}

function mapStateToProps(state) {
    return {
        statistics: state.statistics.statisticList
    };
}

function matchDispatchToProps(dispatch) {
    return {
        setStatisticsList: (statisticList) => dispatch(setStatisticsList(statisticList)),
    }
}

export default connect(mapStateToProps, matchDispatchToProps)(StatisticList);