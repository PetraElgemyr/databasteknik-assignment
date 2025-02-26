import axios from "axios";
import { IListProject } from "../interfaces/IListProject";
import { Project } from "../models/Project";
// import { Project } from "../models/Project";

export const getAllProjects = async (): Promise<IListProject[]> => {
  const response = await axios.get("https://localhost:7043/api/projects");
  console.log(response.data);

  return response.data;
};

export const createNewProject = async (project: Project) => {
  try {
    const response = await fetch(`https://localhost:7043/api/projects`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(project),
    });

    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }

    return await response.json();
  } catch (error) {
    console.error("Error creating project:", error);
    throw error;
  }
};
