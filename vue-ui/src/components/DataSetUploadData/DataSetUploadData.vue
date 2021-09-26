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
          <input type="file" id="file" ref="zipArchive" />
        </div>
      </div>
      <div class="max-w-md">
        <span v-if="!uploadResult.isok" class="text-red-600 italic text-sm ">
            {{ uploadResult.message }}</span
          >
      </div>
      <div>
        <button-with-loading
          class="mt-4"
          :name="'Загрузить данные'"
          :onClick="uploadData"
          :loadingName="'Проверка данных'"
          :activator="awaitingAnswerFromServer"
        />
      </div>
    </div>
  </div>
</template>

<script>
import { ref, toRefs } from "vue";
import api from "./api";
import ButtonWithLoading from "../ButtonWithLoading.vue";

export default {
  props: {
    addNewSetToBegin: Function
  },
  components: {
    ButtonWithLoading
  },
  setup(props) {
    const { addNewSetToBegin } = toRefs(props);
    const name = ref("");
    const hasCyrillic = ref(false);
    const hasLatin = ref(false);
    const hasDigits = ref(false);
    const hasSpecialSymbols = ref(false);
    const caseSensitivity = ref(false);
    const answersLocation = ref(0);
    const zipArchive = ref(null);
    const uploadResult = ref({ isok: true, message: "" });
    const awaitingAnswerFromServer = ref(false);
    const listOfAnswersLocation = [
      "отсутствует",
      "в именах файлов",
      "в отдельном файле"
    ];

    const uploadData = async () => {
      awaitingAnswerFromServer.value = true;
      const formData = new FormData();
      formData.append("name", name.value);
      formData.append("hasCyrillic", hasCyrillic.value);
      formData.append("hasLatin", hasLatin.value);
      formData.append("hasDigits", hasDigits.value);
      formData.append("hasSpecialSymbols", hasSpecialSymbols.value);
      formData.append("caseSensitivity", caseSensitivity.value);
      formData.append("answersLocation", answersLocation.value);
      formData.append("zipArchiveImages", zipArchive.value.files[0]);
      uploadResult.value = await api.uploadDatasetAsync(formData);
      if (uploadResult.value.isok) {
        addNewSetToBegin.value({
          name: name.value,
          date: new Date()
        });
      }
      awaitingAnswerFromServer.value = false;
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
      uploadData,
      uploadResult,
      awaitingAnswerFromServer
    };
  }
};
</script>
