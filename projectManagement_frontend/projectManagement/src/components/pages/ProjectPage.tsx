import { Box, Button, Typography } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { ProjectForm } from "../ProjectForm";
import { useState } from "react";

export const ProjectPage = () => {
  const navigate = useNavigate();
  const [submitted, setSubmitted] = useState<boolean>(false);
  // const { id } = useParams();
  //   <Link
  //   className="animal__container"
  //   key={index}
  //   to={animal.id.toString()}
  // >
  return (
    <>
      <Typography variant="h4" gutterBottom>
        Skapa nytt projekt
      </Typography>
      <Box width={"100%"} padding={2} paddingBottom={0}>
        <Button
          variant="outlined"
          size="large"
          onClick={() => {
            navigate("/");
            //delete request med selectedProject.id
          }}
        >
          Avbryt
        </Button>
      </Box>
      <ProjectForm submitted={submitted} setSubmitted={setSubmitted} />
    </>
  );
};
