import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import * as moment from 'moment';
import { NavLink } from 'react-router-dom';
import { setTestsList } from '../actions/actionCreators/tests';
import { selectTest } from '../actions/actionCreators/tests';
import { tests } from '../../constants/tests';

class TestsList extends Component {
    render() {
        return (
            <div className="tests-container">{ this.showAllTests() }</div>
        );
    }

    showAllTests() {
        const testsList = tests;
        this.props.setTestsList(testsList);
        const items = this.props.tests.map((test) => <div key={test.id} className="single-item">
            <p id="test-title" className="title">{test.title}</p>
            <p className="right-title">{moment(test.startDate).format("DD/MM/yyyy")}
          - {moment(test.deadline).format("DD/MM/yyyy")}</p>
            <NavLink id="details-link" to={`/test/${test.id}`}>
            <button id="details-btn" className="btn" onClick={() => this.props.selectTest(test)}>Details</button>
            </NavLink>
        </div>);
        return items;
    }
}

function mapStateToProps(state) {
    return {
        tests: state.tests.testsList
    };
}

function matchDispatchToProps(dispatch) {
    return {
        setTestsList: (testsList) => dispatch(setTestsList(testsList)),
        selectTest: (test) => dispatch(selectTest(test))
    }
}

export default connect(mapStateToProps, matchDispatchToProps)(TestsList);