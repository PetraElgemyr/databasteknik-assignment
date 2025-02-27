import { defaultCustomerType, ICustomerType } from "./ICustomerType";

export interface ICustomer {
  id: number;
  customerName: string;
  customerType: ICustomerType;
}

export const defaultCustomer: ICustomer = {
  id: 0,
  customerName: "",
  customerType: defaultCustomerType,
};
