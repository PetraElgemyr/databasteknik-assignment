import axios from "axios";
import { ICustomer } from "../interfaces/ICustomer";

export const getAllCustomers = async (): Promise<ICustomer[]> => {
  const response = await axios.get("https://localhost:7043/api/customers");
  console.log(response.data);

  return response.data;
};
