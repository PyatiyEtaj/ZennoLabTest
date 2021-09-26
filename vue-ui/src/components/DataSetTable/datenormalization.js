import dayjs from "dayjs";
import "dayjs/locale/ru";
dayjs.locale("ru");

export default {
  normalizeDate: date => {
    return dayjs(date).format("HH:mm:ss - DD MMM YYYY");
  }
};
