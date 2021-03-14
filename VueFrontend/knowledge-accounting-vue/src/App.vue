<template>
  <div>
    <Header></Header>
    <router-view/>
    <Footer></Footer>
  </div>
</template>

<script>

import Header from './components/shared/Header'
import Footer from './components/shared/Footer'

export default {
  name: 'App',
  components: {
    Header,
    Footer
  }
}
</script>

<style>

body {
  background-color: #f1f1f193;
}

.container-fluid {
  min-height: 78vh;
  height: 100%;
  width: 80%;
  background-color: #ffffff;
  margin-top: 2em;
  margin-bottom: 2em;
  box-shadow: 0 0 5px #dddddd;
  border-radius: 5px;
}

.btn {
  color: #000000;
  transition: 0.2s;
  box-shadow: 0 0 5px #dddddd;
}

.btn:focus {
  outline: none;
}

.btn:hover {
  background-color: #255bce;
  transition: 0.2s;
  color: #ffffff;
}

input.ng-invalid.ng-touched {
  box-shadow: 0 0 5px red;
}

.single-item {
  float: left;
  width: 100%;
  box-shadow: 0 0 5px #dddddd;
  border-radius: 5px;
  padding: 1em;
}


</style>
