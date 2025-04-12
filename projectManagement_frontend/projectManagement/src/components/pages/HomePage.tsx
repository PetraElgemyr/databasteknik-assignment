import Button from "@mui/material/Button";
import { ProjectsDataGrid } from "../ProjectsDataGrid";
import Stack from "@mui/material/Stack";
import { useAppContext } from "../hooks/useAppContext";
import { Typography } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { newProject } from "../../models/Project";
import { useEffect, useState } from "react";
import { deleteProjectById } from "../../services/projectServices";

export const HomePage = () => {
  const { setCurrentProject, loadProjects } = useAppContext();
  const navigate = useNavigate();
  const [selectedProjectId, setSelectedProjectId] = useState<number | null>(
    null
  );

  useEffect(() => {
    setCurrentProject(newProject);
  }, [setCurrentProject]);

  const handleDeleteProject = async () => {
    if (selectedProjectId) {
      const response = await deleteProjectById(selectedProjectId);

      if (response) {
        setSelectedProjectId(null);
        loadProjects();
      }
    }
  };

  return (
    <>
      <Typography
        sx={{
          overflow: "hidden",
        }}
        variant="h3"
      >
        Alla projekt
      </Typography>
      <Stack spacing={3} direction="row" justifyContent={"end"}>
        <Button
          variant="outlined"
          size="large"
          disabled={selectedProjectId === null}
          onClick={handleDeleteProject}
          color="error"
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
      <ProjectsDataGrid setSelectedProjectId={setSelectedProjectId} />
    </>
  );
};
