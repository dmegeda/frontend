<template>
    <header>
        <nav class="navbar navbar-expand-lg">
            <a class="navbar-brand" href="/">Knowledge<br>System</a>
            <ul class="navbar-nav mr-auto">
            <li class="nav-item">
                <a class="nav-link" href="/">Home</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="/statistic">Statistic</a>
            </li>
            <li v-if=true class="nav-item">
                <a class="nav-link" href="/register">Sign Up</a>
            </li>
            <li v-if=true class="nav-item">
                <a class="nav-link" href="/login">Sign In</a>
            </li>
            <li v-if=true class="nav-item">
                <a id="logout-link" class="nav-link" href="/">Sign Out</a>
            </li>
            </ul>
            <div class="user-greeting d-flex align-items-center m-0">
            <p class="m-0">Hello, {{userName}}!</p>
            </div>
        </nav>
    </header>
</template>

<script>

export default {
  data () {
    return {
      isAuthorized: true,
      userName: 'Guest'
    }
  }
}

</script>

<style scoped>

.navbar {
  background-color: #255bce;
}

.navbar-brand {
  color: #ffffff;
  font-weight: 900;
  word-wrap: break-word;
}

a {
  color: #f1f1f193;
  font-family: Arial, Helvetica, sans-serif;
}

.nav-link {
  transition: 0.3s;
}

.nav-link:hover {
  color: #ffffff;
}

.user-greeting p {
  font-size: 20px;
  color: #ffffff;
  transition: 0.3s;
}

.user-greeting p:hover {
  color: #d3d3d3;
}

</style>
