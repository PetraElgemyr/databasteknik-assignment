export interface IService {
  id: number;
  serviceType: string;
  serviceName: string;
  hourlyCost: number;
}

export const emptyService = {
  id: 0,
  serviceType: "",
  serviceName: "",
  hourlyCost: 0,
};
