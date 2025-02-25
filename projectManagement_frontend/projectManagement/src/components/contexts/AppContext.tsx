import { createContext } from "react";
import { Project } from "../../models/Project";
import { IListProject } from "../../interfaces/IListProject";
import { IProjectWithDetails } from "../../interfaces/IProjectWithDetails";

export type AppState = {
  projects: IListProject[];
  setProjects: React.Dispatch<React.SetStateAction<IListProject[]>>;
  selectedProject: IProjectWithDetails;
  setSelectedProject: React.Dispatch<React.SetStateAction<IProjectWithDetails>>;
  currentProject: Project;
  setCurrentProject: React.Dispatch<React.SetStateAction<Project>>;
};

export const AppContext = createContext<AppState>({} as AppState);
