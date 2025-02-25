import Button from "@mui/material/Button";
import { ProjectsDataGrid } from "../ProjectsDataGrid";
import Stack from "@mui/material/Stack";
import { useAppContext } from "../hooks/useAppContext";
import { Typography } from "@mui/material";

export const HomePage = () => {
  const { selectedProject } = useAppContext();

  return (
    <>
      <Typography variant="h3">Alla projekt</Typography>
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
