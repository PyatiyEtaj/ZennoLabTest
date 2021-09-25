import { createApp } from "vue";
import App from "./App.vue";
import "./index.css";
import config from "./util/config";
import axios from "axios";

axios.defaults.baseURL = config.SERVER_URL;

createApp(App).mount("#app");
