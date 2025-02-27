export interface ICustomerType {
  id: number;
  customerTypeName: string;
}

export const defaultCustomerType: ICustomerType = {
  id: 0,
  customerTypeName: "",
};
