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
