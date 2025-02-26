import { IProjectWithDetails } from "../../interfaces/IProjectWithDetails";
import { Project } from "../../models/Project";
import { ProjectSchedule } from "../../models/ProjectSchedule";

export const convertIProjectWithDetailsToProject = (
  projectWithDetails: IProjectWithDetails
): Project => {
  const project: Project = new Project(
    projectWithDetails.projectName,
    projectWithDetails.description,
    projectWithDetails.totalCost,
    projectWithDetails.customer.id,
    projectWithDetails.statusType.id,
    projectWithDetails.user.id,
    new ProjectSchedule(
      projectWithDetails.projectSchedule.startDate,
      projectWithDetails.projectSchedule.endDate,
      projectWithDetails.projectSchedule.id
    ),
    projectWithDetails.id
  );

  return project;
};
