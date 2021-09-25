<template>
  <div class="border h-halfscreen overflow-y-auto">
    <div class="flex justify-center">
      <table class="shadow-md w-8/12 mt-3 ml-5 divide-y divide-gray-200">
        <thead>
          <tr>
            <th class="py-3 w-2/12">
              <button
                @click="updateDatasets"
                class="bg-yellow-300 hover:bg-yellow-500 font-bold py-2 px-4 rounded"
              >
                Обновить
              </button>
            </th>
            <th
              class="w-5/12 px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider"
            >
              Имя набора данных
            </th>
            <th
              class="w-5/12 px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider"
            >
              Дата создания
            </th>
          </tr>
        </thead>
        <tbody class="bg-white divide-y divide-gray-200">
          <tr
            v-for="set in datasets"
            :key="set.dataSetId"
            class="hover:bg-gray-100"
          >
            <td class="w-2/12"></td>
            <td class="w-5/12 px-6 py-3 text-left tracking-wider">
              {{ set.name }}
            </td>
            <td class="w-5/12 px-6 py-3 text-left tracking-wider">
              {{ set.date }}
            </td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script>
import { ref, onMounted } from "vue";
import api from "./api/api";

export default {
  setup() {
    const datasets = ref([]);

    const updateDatasets = async () => {
      datasets.value = await api.getDataSetsAsync();
    };

    onMounted(updateDatasets);

    return {
      datasets,
      updateDatasets
    };
  }
};
</script>
