import Button from "@mui/material/Button";
import { ProjectsDataGrid } from "../ProjectsDataGrid";
import Stack from "@mui/material/Stack";
import { useAppContext } from "../hooks/useAppContext";
import { Typography } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { newProject } from "../../models/Project";
import { useEffect } from "react";

export const HomePage = () => {
  const { selectedProject, setCurrentProject } = useAppContext();
  const navigate = useNavigate();

  useEffect(() => {
    setCurrentProject(newProject);
  }, [setCurrentProject]);

  return (
    <>
      <Typography variant="h3">Alla projekt</Typography>
      <Stack spacing={3} direction="row" justifyContent={"end"}>
        <Button
          variant="outlined"
          size="large"
          disabled={selectedProject.id === 0}
          onClick={() => {
            //delete request med selectedProject.id om d behövs.
          }}
        >
          Ta bort projekt
        </Button>
        <Button
          variant="contained"
          size="large"
          onClick={() => {
            setCurrentProject(newProject);
            navigate("/projects/new");
          }}
        >
          Skapa projekt
        </Button>
      </Stack>
      <ProjectsDataGrid />
    </>
  );
};
