import Button from "@mui/material/Button";
import { ProjectsDataGrid } from "../ProjectsDataGrid";
import Stack from "@mui/material/Stack";
import { useAppContext } from "../hooks/useAppContext";
import { Typography } from "@mui/material";
import { useNavigate } from "react-router-dom";

export const HomePage = () => {
  const { selectedProject } = useAppContext();
  const navigate = useNavigate();

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
            navigate("/projects/new");
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
