<template>
  <DataSetTable />
  <DataSetUploadData />
</template>

<script>
import DataSetTable from "./components/DataSetTable/DataSetTable.vue";
import DataSetUploadData from "./components/DataSetUploadData/DataSetUploadData.vue";

export default {
  name: "App",
  components: {
    DataSetTable,
    DataSetUploadData
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
