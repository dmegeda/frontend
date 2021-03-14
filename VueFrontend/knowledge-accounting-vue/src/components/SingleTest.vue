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
      <button class="btn">Finish</button>
    </div>
  </div>
</template>

<script>

import { tests } from '../Constants/tests'

export default {

  data () {

    const id_parsed = Number.parseInt(this.$route.params.id);
    console.log(id_parsed);
    const test = tests.find(x => x.id === id_parsed);

    return {
      test: test,
      isTesting: false
    }
  },

  methods: {
    goTesting() {
      this.isTesting = true;
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
