import util from "../../../util/util";
import axios from "axios";

export default {
  uploadDatasetAsync: async dataset => {
    const response = await util.responseHandling(
      axios.post("/api/dataset/upload", dataset)
    );
    return {
        isok: response.issuccess,
        message: response.issuccess? "OK" :response.result.response.data
    }
  }
};
