import { DateTime } from "ts-luxon";

export const formatDateHelper = (date: Date) => {
  const formattedDate = DateTime.fromISO(date.toString()).toFormat(
    "yyyy-MM-dd"
  );
  return formattedDate;
};

// export const formatDateTime = (date: DateTime) => {
//   console.log(date);
//   console.log(date.());

//   // const dateformattedDateAsDate = date.toFormat("yyyy-MM-dd");
//   // const formattedDate = DateTime.fromISO(dateAsDate.toString()).toFormat(
//   //   "yyyy-MM-dd"
//   // );
//   // return formattedDate;
// };
