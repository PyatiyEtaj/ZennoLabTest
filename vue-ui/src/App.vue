<template>
  <DataSetTable />
</template>

<script>
import DataSetTable from "./components/DataSetTable/DataSetTable.vue";

export default {
  name: "App",
  components: {
    DataSetTable
  }
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
