import { IListProject } from "../interfaces/IListProject";
import { Project } from "../models/Project";
import {
  emptyIProjectWithDetails,
  IProjectWithDetails,
} from "../interfaces/IProjectWithDetails";
import { IProjectCreateResponse } from "../interfaces/IProjectCreateResponse";
import axios from "axios";
// import { Project } from "../models/Project";

export const getAllProjects = async (): Promise<IListProject[]> => {
  const response = await axios.get("https://localhost:7043/api/projects");

  if (!response) {
    console.log("nåt gick fel oh no:(");
  }

  return response.data;
};

export const getProjectById = async (
  id: string
): Promise<IProjectWithDetails> => {
  const response = await axios.get(`https://localhost:7043/api/projects/${id}`);

  if (!response) {
    return emptyIProjectWithDetails;
  }

  return response.data;
};

export const createNewProject = async (
  project: Project
): Promise<IProjectCreateResponse> => {
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

export const updateExistingProject = async (
  project: Project
): Promise<IProjectCreateResponse> => {
  try {
    const response = await fetch(`https://localhost:7043/api/projects`, {
      method: "PUT",
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
