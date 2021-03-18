import React, { Component } from 'react';
import { connect } from 'react-redux';
import * as moment from 'moment';
import { NavLink } from 'react-router-dom';

class TestsList extends Component {
    render() {
        return (
            <div className="tests-container">{ this.showAllTests() }</div>
        );
    }

    showAllTests() {
        const items = this.props.tests.map((test) => <div key={test.id} className="single-item">
            <p id="test-title" className="title">{test.title}</p>
            <p className="right-title">{moment(test.startDate).format("DD/MM/yyyy")}
          - {moment(test.deadline).format("DD/MM/yyyy")}</p>
            <NavLink id="details-link" to={`/test/${test.id}`}>
            <button id="details-btn" className="btn">Details</button>
            </NavLink>
        </div>);

        return items;
    }
}

function mapStateToProps(state) {
    return {
        tests: state.tests
    };
}

export default connect(mapStateToProps)(TestsList);