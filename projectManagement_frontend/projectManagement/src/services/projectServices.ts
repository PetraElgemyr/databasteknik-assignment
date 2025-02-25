import axios from "axios";
import { IListProject } from "../interfaces/IListProject";
import { Project } from "../models/Project";

export const getAllProjects = async (): Promise<IListProject[]> => {
  const response = await axios.get("https://localhost:7043/api/projects");
  console.log(response.data);

  return response.data;
};

export const createNewProject = async (project: Project): Promise<> => {
  const response = await axios.post(
    `http://localhost:.../api/projects`,
    project
  );
  return response.data;
};
