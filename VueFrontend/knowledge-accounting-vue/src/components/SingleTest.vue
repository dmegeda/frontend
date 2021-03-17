<template>
  <div class="container-fluid">
    <h2 class="text-center pt-3">{{test.title}}</h2>
    <div class="test-info">
      <p>Description: {{test.description}}</p>
      <p>Max rate: {{test.maxRate}}</p>
      <p>Min pass rate: {{test.minRatingForPass}}</p>
      <p>Start date: {{ test.startDate | moment("DD/MM/YYYY")}}</p>
      <button class="btn" v-on:click="goTesting()">GO!</button>
    </div>
    <div class="test-container" v-if="isTesting">
      <div class="single-item" v-for="(question, index) in test.questions" :key="index">
        {{question.text}}
        <div v-for="(answer, index) in question.answers" :key="index">
          <input type="radio" v-bind:name="question.text" v-bind:value="answer.text" v-bind:id="answer.id">
          <label v-bind:for="answer.id">{{answer.text}}</label>
        </div>
      </div>
      <button class="btn" v-on:click="finishTesting()">Finish</button>
    </div>
  </div>
</template>

<script>

import { tests } from '../constants/tests';
import { statistics } from '../constants/statistics'

export default {

  data () {

    const id_parsed = Number.parseInt(this.$route.params.id);
    const test = tests.find(x => x.id === id_parsed);

    return {
      test: test,
      isTesting: false
    }
  },

  methods: {
    goTesting() {
      this.isTesting = true;
    },

    finishTesting() {
      const correctCount = this.getCorrectAnswersCount();
      const test = this.test;
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

      this.isTesting = false;
      this.$router.push('/statistic');
    },

    getCorrectAnswersCount(){
      let correctAnsw = 0;
      for (const question of this.test.questions) {
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
    },

    getCorrectAnswersPercent(correctCount, answerCount) {
      return (correctCount / answerCount) * 100;
    },

    checkAnswerIsCorrect(answerText, question) {
      const answer = question.answers.find(x => x.text === answerText);
      return answer.id === question.correctAnswerId;
    }
  }

}

</script>

<style scoped>

label {
  margin-left: 5px;
}

.radios-group {
  display: flex;
  flex-direction: column;
}

.test-container{
  padding: 10px 0;
}

.test-container * {
  margin: 10px 0;
}

</style>
