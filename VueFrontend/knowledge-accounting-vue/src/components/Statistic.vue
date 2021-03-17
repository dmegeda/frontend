<template>
  <div class="container-fluid">
    <h1 class="text-center pt-3">Your statistics</h1>
    <table class="table">
      <tr>
        <th id="test-name">Test name</th>
        <th id="test-status">Status</th>
        <th id="test-score">Score</th>
      </tr>
      <tr v-for="(stat, index) in statistics" :key="index">
        <td>{{stat.testName}}</td>
        <td>{{stat.isPassed ? "Completed" : "Failed"}}</td>
        <td>{{roundNumber(stat.score, 2)}}%</td>
      </tr>
    </table>
  </div>
</template>

<script>

export default {

  data () {

    const statistics = JSON.parse(localStorage.getItem("statistics"));

    return {
      statistics: statistics
    }
  },

  methods: {
    roundNumber(numberToRound, symbolsCount) {
      let x = Math.pow(10, symbolsCount);
      return (parseInt(String(numberToRound * x))) / x;
    }
  }
}

</script>
