<template>
  <button
    v-if="!activator"
    class="bg-gray-900 hover:bg-black text-white font-bold py-2 px-4 rounded"
    @click="onClick()"
  >
    {{ name }}
  </button>
  <div
    v-else
    class="inline-flex items-center px-4 py-2 border border-transparent text-base leading-6 font-bold rounded-md text-white bg-red-600 hover:bg-red-500 focus:border-red-700 active:bg-red-700 transition ease-in-out duration-150 cursor-not-allowed"
    disabled=""
  >
    <svg
      class="animate-spin ml-1 mr-3 h-5 w-5 text-white"
      fill="none"
      viewBox="0 0 24 24"
    >
      <circle
        class="opacity-25"
        cx="12"
        cy="12"
        r="10"
        stroke="currentColor"
        stroke-width="4"
      ></circle>
      <path
        class="opacity-75"
        fill="currentColor"
        d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"
      ></path>
    </svg>
    {{ loadingName }}
  </div>
</template>

<script>
export default {
  props: {
    onClick: Function,
    activator: Boolean,
    name: String,
    loadingName: String
  }
};
</script>
