import axios from "axios";
import { IProjectManager } from "../interfaces/IProjectManager";

export const getAllProjectManagers = async (): Promise<IProjectManager[]> => {
  const response = await axios.get(
    "https://localhost:7043/api/users/projectmanagers"
  );
  console.log(response.data);

  return response.data;
};
