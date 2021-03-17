<template>
  <div class="container-fluid  d-flex align-items-center justify-content-center">
    <form class="
        auth-form
        form-group
        d-flex
        flex-column
        align-items-center
        w-75" noValidate>
        <h1 class="m-0">SignIn Form</h1>
        <input class="form-control" name="name" placeholder="Username"></input>
        <input class="form-control" type="password" name="password" placeholder="Password"></input>
        <button class="btn" type="submit">Sign In</button>
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
