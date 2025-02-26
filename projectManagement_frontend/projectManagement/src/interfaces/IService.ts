export interface IService {
  id: number;
  serviceType: string;
  hourlyCost: number;
}

export const emptyService = {
  id: 0,
  serviceType: "",
  hourlyCost: 0,
};
