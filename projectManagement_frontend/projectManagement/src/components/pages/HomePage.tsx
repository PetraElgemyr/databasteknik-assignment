import Button from "@mui/material/Button";
import { ProjectsDataGrid } from "../ProjectsDataGrid";
import Stack from "@mui/material/Stack";
import { useState } from "react";
import { defaultProject, Project } from "../../models/Project";

export const HomePage = () => {
  // in i appcontext.
  const [selectedProject, setSelectedProject] =
    useState<Project>(defaultProject);

  return (
    <>
      <h1>Alla projekt</h1>
      <Stack spacing={3} direction="row" justifyContent={"end"}>
        <Button
          variant="outlined"
          size="large"
          disabled={selectedProject.id === 0}
          onClick={() => {
            //delete request med selectedProject.id
          }}
        >
          Ta bort projekt
        </Button>
        <Button
          variant="contained"
          size="large"
          onClick={() => {
            //öppna create Project page med form
          }}
        >
          Skapa projekt
        </Button>
      </Stack>
      <ProjectsDataGrid />
    </>
  );
};
