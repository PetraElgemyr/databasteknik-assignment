import { createContext } from "react";
import { IProject } from "../../interfaces/IProject";

export type AppState = {
  projects: IProject[];
  setProjects: React.Dispatch<React.SetStateAction<IProject[]>>;
};

export const AppContext = createContext<AppState>({} as AppState);
