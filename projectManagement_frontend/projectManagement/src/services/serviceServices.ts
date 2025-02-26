import axios from "axios";
import { IService } from "../interfaces/IService";

export const getAllServices = async (): Promise<IService[]> => {
  const response = await axios.get(`https://localhost:7043/api/services`);

  if (!response) {
    console.log("nåt gick fel oh no:(");
  }

  return response.data;
};
