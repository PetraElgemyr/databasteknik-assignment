import { ICustomerType } from "./ICustomerType";

export interface ICustomer {
  id: number;
  customerName: string;
  customerType: ICustomerType;
}
