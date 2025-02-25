import { DateTime } from "ts-luxon";

export class ProjectSchedule {
  constructor(public startDate: DateTime, public endDate?: DateTime) {}
}
