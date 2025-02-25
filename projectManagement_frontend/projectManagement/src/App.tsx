import { useEffect, useState } from "react";
import "./App.css";
import { AppContext } from "./components/contexts/AppContext";
import { Routing } from "./Routing";
import { getAllProjects } from "./services/projectServices";
import { IProject } from "./interfaces/IProject";

function App() {
  const [projects, setProjects] = useState<IProject[]>([]);

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
