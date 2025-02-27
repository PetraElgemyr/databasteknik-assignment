import axios from "axios";
import { IProjectService } from "../interfaces/IProjectService";

export const getAllProjectServicesByProjectId = async (
  id: string
): Promise<IProjectService[]> => {
  const response = await axios.get(
    `https://localhost:7043/api/projectservices/${id}`
  );

  if (!response) {
    console.log("nåt gick fel oh no:(");
  }

  return response.data;
};

export const createNewProjectService = async (
  projectService: IProjectService
): Promise<IProjectService> => {
  try {
    const response = await fetch(
      `https://localhost:7043/api/projectservices/`,
      {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(projectService),
      }
    );

    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }

    return await response.json();
  } catch (error) {
    console.error("Error creating project service:", error);
    throw error;
  }
};
