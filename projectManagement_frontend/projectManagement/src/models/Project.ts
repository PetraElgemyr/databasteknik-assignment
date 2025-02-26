import { DateTime } from "ts-luxon";
import { ProjectSchedule } from "./ProjectSchedule";

export class Project {
  constructor(
    public projectName: string,
    public description: string,
    public totalCost: number,
    public customerId: number,
    public statusTypeId: number,
    public userId: number,
    public projectSchedule: ProjectSchedule,
    public id?: number
  ) {}
}

export const newProject = new Project(
  "",
  "",
  0,
  0,
  0,
  0,
  new ProjectSchedule(DateTime.now())
);
