<template>
  <div class="container">
      <app-header></app-header>
      <router-view></router-view>
      <!-- <app-principal></app-principal> -->
  </div>
  
</template>

<script>
// import Principal from './components/Principal.vue'
import Header from './components/Header.vue'

export default {
  components:{
    appHeader: Header
  }
}
</script>

<style>

</style>
