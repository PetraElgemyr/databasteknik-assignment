export interface IProjectService {
  projectId: number;
  serviceId: number;
  service: IService;
}

export interface IService {
  id: number;
  serviceType: string;
  hourlyCost: number;
}
