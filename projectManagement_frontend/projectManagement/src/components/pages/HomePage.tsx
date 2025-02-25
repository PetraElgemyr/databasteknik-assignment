import { useEffect, useState } from "react";
import { getAllProjects } from "../../services/projectServices";
import { IProject } from "../../interfaces/IProject";

export const HomePage = () => {
  const [projects, setProjects] = useState<IProject[]>([]);

  const loadProjects = async () => {
    const response = await getAllProjects();
    setProjects(response);
  };

  useEffect(() => {
    loadProjects();
  }, []);
  return (
    <>
      {projects.map((p) => (
        <div key={p.id}>
          <p>
            Id: {p.id} - {p.projectName}
          </p>
        </div>
      ))}
    </>
  );
};
