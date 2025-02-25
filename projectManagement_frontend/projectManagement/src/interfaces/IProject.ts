export interface IProject {
  id: number;
  projectName: string;
  description: string;
  customerName: string;
  totalCost: number;
  statusTypeName: string;
  startDate: Date;
  endDate: Date;
}
