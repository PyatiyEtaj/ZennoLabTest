<template>
  <div class="py-2 flex justify-center">
    <div>
      <div class="shadow-lg py-2">
        <span class="inline align-baseline px-4 underline">Наименование</span>
        <input type="text" class="rounded-md" v-model="name" />
      </div>
      <div class="mt-2 shadow-lg">
        <div class="flex justify-center font-bold">
          Метаинформация
        </div>
        <div class="py-1 flex justify-between mx-5">
          <span class="inline align-baseline px-4 underline"
            >Содержит кириллицу</span
          >
          <input type="checkbox" v-model="hasCyrillic" />
        </div>
        <div class="py-1 flex justify-between mx-5">
          <span class="inline align-baseline px-4 underline"
            >Содержит латиницу</span
          >
          <input type="checkbox" v-model="hasLatin" />
        </div>
        <div class="py-1 flex justify-between mx-5">
          <span class="inline align-baseline px-4 underline"
            >Содержит цифры</span
          >
          <input type="checkbox" v-model="hasDigits" />
        </div>
        <div class="py-1 flex justify-between mx-5">
          <span class="inline align-baseline px-4 underline"
            >Содержит специальные символы</span
          >
          <input type="checkbox" v-model="hasSpecialSymbols" />
        </div>
        <div class="py-1 flex justify-between mx-5">
          <span class="inline align-baseline px-4 underline"
            >Чувствительность к регистру</span
          >
          <input type="checkbox" v-model="caseSensitivity" />
        </div>
      </div>
      <div class="shadow-lg py-2">
        <span class="font-bold">Расположение ответов на картинки</span>
        <select class="form-select px-4 py-3 w-11/12" v-model="answersLocation">
          <option
            v-for="(item, index) in listOfAnswersLocation"
            :key="index"
            :value="index"
            >{{ item }}</option
          >
        </select>
      </div>
      <div class="shadow-lg py-2">
        <span class="font-bold">Загрузка ZIP архива</span>
        <div>
          <input type="file" id="file" ref="zipArchive"/>
        </div>
      </div>
      <div class="mt-5">
        <button
          @click="uploadData"
          class="bg-yellow-300 hover:bg-yellow-500 font-bold py-2 px-4 rounded"
        >
          Загрузить данные
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import { ref } from "vue";
export default {
  setup() {
    const name = ref("");
    const hasCyrillic = ref("");
    const hasLatin = ref(false);
    const hasDigits = ref(false);
    const hasSpecialSymbols = ref(false);
    const caseSensitivity = ref(false);
    const answersLocation = ref(0);
    const zipArchive = ref(null);
    const listOfAnswersLocation = [
      "отсутствует",
      "в именах файлов",
      "в отдельном файле"
    ];

    const uploadData = () => {
      console.log(zipArchive.value.files[0]);
    };

    return {
      name,
      hasCyrillic,
      hasLatin,
      hasDigits,
      hasSpecialSymbols,
      caseSensitivity,
      answersLocation,
      listOfAnswersLocation,
      zipArchive,
      uploadData
    };
  }
};
</script>
