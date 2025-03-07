import { emptyService, IService } from "./IService";

export interface IProjectService {
  estimatedHours: number;
  projectId: number;
  serviceId: number;
  service: IService;
}

export const emptyProjectService: IProjectService = {
  estimatedHours: 0,
  projectId: 0,
  serviceId: 0,
  service: emptyService,
};
