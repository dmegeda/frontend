import React, { Component } from "react";
import * as moment from 'moment';
import './TestComponent.scoped.css';
import { tests } from '../../Constants/tests';
import { statistics } from '../../Constants/statistics';

export default class TestComponent extends Component{
    constructor(props) {
        super(props)

        const id = this.props.match.params.id;
        const test = tests.find(x => x.id == id);

        this.state = {
            test: test,
            isTesting: false
        }

        this.goTestingBtnClick = this.goTestingBtnClick.bind(this);
        this.finishBtnClick = this.finishBtnClick.bind(this);
        this.setTest = this.setTest.bind(this);
    }

    setTest(){
        const id = this.props.match.params.id;
        const test = tests.find(x => x.id == id);
        this.setState({
            test: test
        });
    }

    goTestingBtnClick() {
        this.setState({
            isTesting: true
        });
    }

    finishBtnClick() {
        const correctCount = this.getCorrectAnswersCount();
        const test = this.state.test;
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

        statistics.push(stat);
        localStorage.setItem("statistics", JSON.stringify(statistics));

        this.setState({
            isTesting: false
        });
    }

    getCorrectAnswersCount(){
        let correctAnsw = 0;
        for (const question of this.state.test.questions) {
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
        console.log(answerCount);
        console.log(correctCount);
        return (correctCount / answerCount) * 100;
    }
    
    checkAnswerIsCorrect(answerText, question) {
        const answer = question.answers.find(x => x.text === answerText);
        return answer.id === question.correctAnswerId;
    }

    render() {
        const id = this.props.match.params.id;
        const test = tests.find(x => x.id == id);
        //this.state.test = test;
        console.log(statistics);
        const questions = this.state.test.questions.map((question) => <div key={question.id} className="single-item">
            <p id="test-title" className="title">{question.text}</p>
            {question.answers.map((answer) => <div key={answer.id}>
                <input type="radio" name={`${question.text}`} value={`${answer.text}`} id={`${answer.id}`}></input>
                <label htmlFor={`${answer.id}`}>{answer.text}</label>
            </div>)}
        </div>);

        const testing = <div>{questions}<button className="btn" onClick={this.finishBtnClick}>Finish!</button>
        </div>

        return (
            <div id="test-container" className="container-fluid d-flex">
                <h2 className="text-center pt-3">{test.title}</h2>
                <div className="test-info">
                    <p>Description: {test.description}</p>
                    <p>Max rate: {test.maxRate}</p>
                    <p>Min pass rate: {test.minRatingForPass}</p>
                    <p>Start date: { moment(test.startDate).format("DD/MM/yyyy")}</p>
                    <button className="btn" onClick={this.goTestingBtnClick}>GO!</button>
                </div>
                {this.state.isTesting && testing}
            </div>
        );
    }
}