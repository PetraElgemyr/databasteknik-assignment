import { IProjectService } from "../../interfaces/IProjectService";

export const createNewProjectServiceWithProjectId = (
  projectId: number
): IProjectService => {
  return {
    estimatedHours: 0,
    projectId: projectId,
    serviceId: 0,
    service: {
      id: 0,
      serviceType: "",
      hourlyCost: 0,
    },
  };
};
