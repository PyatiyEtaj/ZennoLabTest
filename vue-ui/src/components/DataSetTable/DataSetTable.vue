<template>
  <div>
    <button @click="updateDatasets" class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
      Update
    </button>
    <pre>{{ dataset }}</pre>
  </div>
</template>

<script>
import { ref, onMounted } from "vue";
import api from "./api/api";

export default {
  setup() {
    const dataset = ref([]);

    const updateDatasets = async () => {
      dataset.value = await api.getDataSetsAsync();
    };

    onMounted(updateDatasets);

    return {
      dataset,
      updateDatasets
    };
  }
};
</script>
