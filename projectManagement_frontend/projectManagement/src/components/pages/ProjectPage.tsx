import { Box, Button, Stack, Typography } from "@mui/material";
import { useNavigate, useParams } from "react-router-dom";
import { ProjectForm } from "../ProjectForm";
import { useCallback, useEffect, useState } from "react";
import { getProjectById } from "../../services/projectServices";
import {
  emptyIProjectWithDetails,
  IProjectWithDetails,
} from "../../interfaces/IProjectWithDetails";
import { ProjectView } from "../ProjectView";
import { convertIProjectWithDetailsToProject } from "../helpers/projectHelper";
import { Project } from "../../models/Project";
import { useAppContext } from "../hooks/useAppContext";

export const ProjectPage = () => {
  const { setCurrentProject, loadProjects } = useAppContext();
  const [isEditProjectServicesMode, setIsEditProjectServicesMode] =
    useState(false);
  const navigate = useNavigate();
  const { id } = useParams();
  const [fetchedProject, setFetchedProject] = useState<IProjectWithDetails>(
    emptyIProjectWithDetails
  );
  const [isEditMode, setIsEditMode] = useState<boolean>(false);

  const changeCurrentProjectToFetchedProject = useCallback(
    (response: IProjectWithDetails) => {
      const selectedProject: Project =
        convertIProjectWithDetailsToProject(response);
      setCurrentProject(selectedProject);
    },
    [setCurrentProject]
  );

  const fetchProjectByParamsId = useCallback(async () => {
    if (id) {
      const response: IProjectWithDetails = await getProjectById(id);

      if (response.id === 0) {
        setFetchedProject(response);
      }
      setFetchedProject(response);
      changeCurrentProjectToFetchedProject(response);
    }
  }, [id, changeCurrentProjectToFetchedProject]);

  useEffect(() => {
    fetchProjectByParamsId();
  }, [fetchProjectByParamsId]);

  return (
    <>
      {id && parseInt(id) > 0 ? (
        <>
          <Box width={"100%"} padding={2} paddingBottom={0}>
            <Stack justifyContent={"space-between"} direction={"row"}>
              <Button
                variant="outlined"
                size="large"
                onClick={() => {
                  loadProjects();
                  navigate("/");
                }}
              >
                {isEditMode ? "Avbryt redigering" : "Tillbaka till lista"}
              </Button>

              {fetchedProject.id > 0 &&
                !isEditMode &&
                !isEditProjectServicesMode && (
                  <Button
                    variant="contained"
                    size="large"
                    onClick={() => {
                      setIsEditMode(true);
                    }}
                  >
                    Redigera
                  </Button>
                )}
            </Stack>
            {fetchedProject.id === 0 && id ? (
              <Typography variant="h4" gutterBottom>
                Projektet kunde inte hittas !
              </Typography>
            ) : isEditMode && fetchedProject.id > 0 ? (
              <ProjectForm
                fetchProjectByParamsId={fetchProjectByParamsId}
                setIsEditMode={setIsEditMode}
                isEditMode={isEditMode}
                fetchedProject={fetchedProject}
              />
            ) : (
              <ProjectView
                isEditProjectServicesMode={isEditProjectServicesMode}
                setIsEditProjectServicesMode={setIsEditProjectServicesMode}
                project={fetchedProject}
              />
            )}
          </Box>
        </>
      ) : (
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
              }}
            >
              Avbryt
            </Button>
          </Box>
          <ProjectForm
            fetchProjectByParamsId={fetchProjectByParamsId}
            setIsEditMode={setIsEditMode}
            isEditMode={isEditMode}
            fetchedProject={emptyIProjectWithDetails}
          />
        </>
      )}
    </>
  );
};
