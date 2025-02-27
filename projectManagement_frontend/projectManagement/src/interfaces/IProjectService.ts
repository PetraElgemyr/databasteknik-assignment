import { IService } from "./IService";

export interface IProjectService {
  estimatedHours: number;
  projectId: number;
  serviceId: number;
  service: IService;
}

export const emptyProjectService = {
  projectId: 0,
  serviceId: 0,
  service: {
    id: 0,
    serviceType: "",
    hourlyCost: 0,
  },
};
