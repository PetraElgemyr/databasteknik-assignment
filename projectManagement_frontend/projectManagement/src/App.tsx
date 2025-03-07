import { useEffect, useState } from "react";
import "./App.css";
import { AppContext } from "./components/contexts/AppContext";
import { Routing } from "./Routing";
import { getAllProjects } from "./services/projectServices";
import { IListProject } from "./interfaces/IListProject";
import { newProject, Project } from "./models/Project";

function App() {
  const [projects, setProjects] = useState<IListProject[]>([]);
  const [currentProject, setCurrentProject] = useState<Project>(newProject);

  const loadProjects = async () => {
    const response = await getAllProjects();
    setProjects(response);
  };

  useEffect(() => {
    loadProjects();
  }, []);

  const contextValue = {
    projects,
    setProjects,
    currentProject,
    setCurrentProject,
    loadProjects,
  };

  return (
    <>
      <AppContext.Provider value={contextValue}>
        <Routing />
      </AppContext.Provider>
    </>
  );
}

export default App;
