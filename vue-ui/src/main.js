import { createApp } from "vue";
import App from "./App.vue";
import config from "./util/config";
import axios from "axios";
import "./assets/tailwind.css";

console.log(process.env);

axios.defaults.baseURL = config.SERVER_URL;

createApp(App).mount("#app");
