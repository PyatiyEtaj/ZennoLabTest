import axios from "axios";
import util from "../../../util/util";

export default {
  getDataSetsAsync: async () => {
    const response = await util.responseHandling(axios.get("/api/DataSet/Get"));
    return response.issuccess ? response.result.data : [];
  }
};
