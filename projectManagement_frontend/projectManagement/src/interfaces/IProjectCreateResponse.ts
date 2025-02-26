export interface IProjectCreateResponse {
  id: number;
  projectName: string;
  description: string;
  totalCost: number;
  statusTypeId: number;
  userId: number;
  projectScheduleId: number;
}
