import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import * as moment from 'moment';
import { selectTest, startTesting } from '../actions/actionCreators/tests';
import { tests } from '../../constants/tests';
import Testing from './testing';

class TestDetails extends Component {
    render() {
        const { id } = this.props;
        if (Object.keys(this.props.selectedTest).length === 0) {
            this.props.selectTest(tests.find(x => x.id == id));
        }

        const test = this.props.selectedTest;

        return (
            <div>
                <h2 className="text-center pt-3">{test.title}</h2>
                <div className="test-info">
                    <p>Description: {test.description}</p>
                    <p>Max rate: {test.maxRate}</p>
                    <p>Min pass rate: {test.minRatingForPass}</p>
                    <p>Start date: { moment(test.startDate).format("DD/MM/yyyy")}</p>
                    <button className="btn" onClick={() => this.props.startTesting(test)}>GO!</button>
                </div>
                {this.props.isTesting && <Testing/>}
            </div>
        );
    }
}

function mapStateToProps(state) {
    return {
        selectedTest: state.tests.selectedTest,
        isTesting: state.tests.isTestingStarted
    };
}

function matchDispatchToProps(dispatch) {
    return {
        selectTest: (test) => dispatch(selectTest(test)),
        startTesting: (test) => dispatch(startTesting(test))
    }
}

export default connect(mapStateToProps, matchDispatchToProps)(TestDetails);