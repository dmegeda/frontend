<template>
  <div class="container-fluid  d-flex align-items-center justify-content-center">
    <form class="
    auth-form
    form-group
    d-flex
    flex-column
    align-items-center
    w-75"
    noValidate>
    <h1 class="m-0">SignUp Form</h1>
    <input class="form-control" placeholder="Username"/>
    <input class="form-control" name="password" placeholder="Password"/>
    <input class="form-control" name="confirm password" placeholder="Confirm password"/>
    <button class="btn" type="submit">Sign Up</button>
    </form>
  </div>
</template>

<script>

export default {

  data () {}
}

</script>

<style scoped>

@import './Auth.css';

</style>
