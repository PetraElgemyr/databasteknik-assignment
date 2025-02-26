import axios from "axios";
import { IStatusType } from "../interfaces/IStatusType";

export const getStatusTypes = async (): Promise<IStatusType[]> => {
  const response = await axios.get("https://localhost:7043/api/statustypes");

  return response.data;
};
