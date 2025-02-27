import { createContext } from "react";
import { Project } from "../../models/Project";
import { IListProject } from "../../interfaces/IListProject";
// import { IProjectWithDetails } from "../../interfaces/IProjectWithDetails";

export type AppState = {
  projects: IListProject[];
  setProjects: React.Dispatch<React.SetStateAction<IListProject[]>>;
  currentProject: Project;
  setCurrentProject: React.Dispatch<React.SetStateAction<Project>>;
  loadProjects: () => Promise<void>;
};

export const AppContext = createContext<AppState>({} as AppState);
