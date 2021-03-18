import React, { Component } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { endTesting } from '../actions/actionCreators/tests';

class Testing extends Component {
    render() {
        return (
            <div>{ this.showTesting()}</div>
        );
    }

    showTesting() {
        const questions = this.props.selectedTest.questions.map((question) => <div key={question.id} className="single-item">
            <p id="test-title" className="title">{question.text}</p>
            {question.answers.map((answer) => <div key={answer.id}>
                <input type="radio" name={`${question.text}`} value={`${answer.text}`} id={`${answer.id}`}></input>
                <label htmlFor={`${answer.id}`}>{answer.text}</label>
            </div>)}
        </div>);

        const testing = <div>{questions}<button className="btn"
            onClick={() => this.finishBtnClick()}>Finish!</button>
        </div>
        return testing;
    }

    finishBtnClick() {
        const correctCount = this.getCorrectAnswersCount();
        const test = this.props.selectedTest;
        const correctPercent = this.getCorrectAnswersPercent(correctCount, test.questions.length);
        let isPassed = false;

        if (correctPercent >= test.minRatingForPass) {
            isPassed = true;
        }

        const stat = {
            testName: test.title,
            isPassed: isPassed,
            score: correctPercent
        };

        let statisticsList = JSON.parse(localStorage.getItem("statistics"));
        console.log(statisticsList);
        if (statisticsList === null) {
            statisticsList = this.props.statisticList;
        }
        statisticsList.push(stat);
        localStorage.setItem("statistics", JSON.stringify(statisticsList));
        console.log(statisticsList);
        this.props.endTesting(test);
    }

    getCorrectAnswersCount(){
        let correctAnsw = 0;
        for (const question of this.props.selectedTest.questions) {
          const radios = document.getElementsByTagName('input');
          for (let i = 0; i < radios.length; i++){
            if (radios[i].type === 'radio'
              && radios[i].name === `${question.text}`
              && radios[i].checked === true) {
              const title = radios[i].value;
                if (this.checkAnswerIsCorrect(title, question)) {
                    correctAnsw++;
                }
            }
          }
        }

        return correctAnsw;
    }

    getCorrectAnswersPercent(correctCount, answerCount) {
        return (correctCount / answerCount) * 100;
    }
    
    checkAnswerIsCorrect(answerText, question) {
        const answer = question.answers.find(x => x.text === answerText);
        return answer.id === question.correctAnswerId;
    }
}

function mapStateToProps(state) {
    return {
        selectedTest: state.tests.selectedTest,
        isTesting: state.tests.isTesting,
        statistics: state.statistics.statisticsList
    };
}

function matchDispatchToProps(dispatch) {
    return bindActionCreators({endTesting: endTesting}, dispatch)
}

export default connect(mapStateToProps, matchDispatchToProps)(Testing);