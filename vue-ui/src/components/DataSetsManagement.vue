<template>
  <div>
    <data-set-table :datasets="datasets" :updateDatasets="updateDatasets" />
    <data-set-upload-data :addNewSetToBegin="addNewSetToBegin" />
  </div>
</template>

<script>
import { ref, onMounted } from "vue";
import DataSetTable from "./DataSetTable/DataSetTable.vue";
import DataSetUploadData from "./DataSetUploadData/DataSetUploadData.vue";
import apiDateSetTable from "./DataSetTable/api"

export default {
  components: {
    DataSetTable,
    DataSetUploadData
  },

  setup() {
    const datasets = ref([]);
    const addNewSetToBegin = item => datasets.value.unshift(item);

    const updateDatasets = async () => {
      datasets.value = await apiDateSetTable.getDataSetsAsync();
    };

    onMounted(updateDatasets);

    return {
      datasets,
      updateDatasets,
      addNewSetToBegin
    };
  }
};
</script>
