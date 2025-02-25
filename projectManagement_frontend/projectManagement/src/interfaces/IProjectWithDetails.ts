import { IUser } from "./IUser";
import { IProductSchedule } from "./IProductSchedule";
import { ICustomer } from "./ICustomer";
import { IStatusType } from "./IStatusType";
import { DateTime } from "ts-luxon";

export interface IProjectWithDetails {
  id: number;
  projectName: string;
  description: string;
  totalCost: number;
  productSchedule: IProductSchedule;
  customer: ICustomer;
  statusType: IStatusType;
  user: IUser;
}

export const emptyIProjectWithDetails: IProjectWithDetails = {
  id: 0,
  projectName: "",
  description: "",
  totalCost: 0,
  productSchedule: {
    id: 0,
    startDate: DateTime.now(),
  },
  customer: {
    id: 0,
    customerName: "",
    customerType: {
      id: 0,
      customerTypeName: "",
    },
  },
  statusType: { id: 0, statusName: "" },
  user: {
    id: 0,
    firstName: "",
    lastName: "",
    email: "",
    phoneNumber: "",
    roleId: 0,
  },
};
