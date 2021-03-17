<template>
  <div class="container-fluid">
    <h1 class="text-center pt-3">Latest tests</h1>
    <div class="tests-container">
      <div class="single-item" v-for="(test, index) in tests" :key="index">
        <p class="title">{{test.title}}</p>
          <p class="right-title">{{test.startDate | moment("DD/MM/YYYY")}}
          - {{test.deadline | moment("DD/MM/YYYY")}}</p>
          <p>{{test.description}}</p>
          <router-link :to="{ path: '/test/' + test.id }">
            <button class="btn">Details</button>
          </router-link>
      </div>
    </div>
</div>
</template>

<script>

import { tests } from '../constants/tests'

export default {

  data () {
    return {
      tests: tests
    }
  }
}

</script>

<style scoped>

h1 {
  text-transform: uppercase;
}

p {
  margin: 0;
}

a {
  color: #000000;
  text-decoration: none;
}

.tests-container {
  display: inline-grid;
  width: 100%;
  grid-template-columns: 1fr 1fr;
  gap: 1em;
}

.test-item {
  width: 100%;
  box-shadow: 0 0 5px #dddddd;
  border-radius: 5px;
  padding: 1em;
}

.title {
  font-weight: 600;
}

.loading-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  margin: 10%;
}

:host ::ng-deep .progress-spinner circle {
  stroke: #255bce;
}

</style>
