import React, { Component } from "react";
import './testComponent.css';
import { tests } from '../../constants/tests';
import { statistics } from '../../constants/statistics';
import TestDetails from '../../redux/containers/test-details';


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
        return (correctCount / answerCount) * 100;
    }
    
    checkAnswerIsCorrect(answerText, question) {
        const answer = question.answers.find(x => x.text === answerText);
        return answer.id === question.correctAnswerId;
    }

    render() {
        return (
            <div id="test-container" className="container-fluid d-flex">
                <TestDetails id={this.props.match.params.id} />
            </div>
        );
    }
}