export interface IProjectManager {
  id: number;
  name: string;
}

export const defaultProjectManager: IProjectManager = {
  id: 0,
  name: "",
};
