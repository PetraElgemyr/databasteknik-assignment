import { DateTime } from "ts-luxon";

export const formatDateHelper = (date: Date) => {
  const formattedDate = DateTime.fromISO(date.toString()).toFormat(
    "yyyy-MM-dd"
  );
  return formattedDate;
};
