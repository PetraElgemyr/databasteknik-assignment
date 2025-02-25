import { DateTime } from "ts-luxon";

export interface IProductSchedule {
  id: number;
  startDate: DateTime;
  endDate?: DateTime;
}
