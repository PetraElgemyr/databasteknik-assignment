import {
  Autocomplete,
  Box,
  Button,
  CircularProgress,
  ListItem,
  ListItemText,
  Stack,
  TextField,
  Typography,
} from "@mui/material";
import { Fragment, useState } from "react";
import { getAllServices } from "../services/serviceServices";
import { IService } from "../interfaces/IService";
import { IProjectService } from "../interfaces/IProjectService";
import { useAppContext } from "./hooks/useAppContext";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import { createNewProjectServiceWithProjectId } from "./helpers/projectServiceHelper";
import { createNewProjectService } from "../services/projectServicesServices";

interface IProjectServiceFormProps {
  existingProjectServices: IProjectService[];
  columns: GridColDef[];
}

export const ProjectServiceForm = ({
  existingProjectServices,
  columns,
}: IProjectServiceFormProps) => {
  const { currentProject } = useAppContext();
  const [openServices, setOpenServices] = useState(false);
  const [loadingServices, setLoadingServices] = useState(false);
  const [allServices, setAllServices] = useState<IService[]>([]);
  const [projectServicesWithNew, setProjectServicesWithNew] = useState<
    IProjectService[]
  >(existingProjectServices);
  const [newFormProjectService, setNewFormProjectService] =
    useState<IProjectService>(
      createNewProjectServiceWithProjectId(currentProject.id!)
    );
  const [isSubmitted, setIsSubmitted] = useState(false);

  const postProjectService = async () => {
    const createdProjectService = await createNewProjectService(
      newFormProjectService
    );

    if (createdProjectService) {
      setProjectServicesWithNew([
        ...projectServicesWithNew,
        createdProjectService,
      ]);
      setNewFormProjectService(
        createNewProjectServiceWithProjectId(currentProject.id!)
      );
    }
  };

  const validateProjectService = (projectService: IProjectService): boolean => {
    if (!projectService.serviceId || projectService.serviceId === 0) {
      return false;
    }

    if (!projectService.estimatedHours || projectService.estimatedHours === 0) {
      return false;
    }

    return true;
  };

  const handleProjectServiceSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    setIsSubmitted(true);
    const isValid = validateProjectService(newFormProjectService);
    if (isValid) {
      postProjectService();
      setIsSubmitted(false);
    }
  };

  const handleOpenServices = async () => {
    setOpenServices(true);
    setLoadingServices(true);
    const res = await getAllServices();
    setAllServices(res);
    setLoadingServices(false);
  };

  const handleCloseServices = () => {
    setOpenServices(false);
    setLoadingServices(false);
  };

  return (
    <>
      <Typography variant="h6" gutterBottom>
        Projektets tjänster
      </Typography>
      <DataGrid
        rowSelection={false}
        getRowId={(row) => `${row.projectId}-${row.serviceId}}`}
        rows={projectServicesWithNew}
        columns={columns}
        pageSizeOptions={[5]}
      />

      <Box
        component={"form"}
        width={"100%"}
        onSubmit={handleProjectServiceSubmit}
        paddingTop={4}
      >
        <Stack direction={"row"} spacing={2}>
          <Stack width={"65%"}>
            <Autocomplete
              fullWidth
              open={openServices}
              loading={loadingServices}
              onOpen={handleOpenServices}
              onClose={handleCloseServices}
              value={newFormProjectService.service}
              getOptionLabel={(s: IService) =>
                s.id !== 0 ? `${s.serviceType} - ${s.serviceName}` : "Ej vald"
              }
              isOptionEqualToValue={(s, value) =>
                `${s.serviceType} - ${s.serviceName}` ===
                `${value.serviceType} - ${value.serviceName}`
              }
              options={allServices}
              renderOption={(props, option, state) => {
                return (
                  <ListItem {...props} key={state.index}>
                    <ListItemText
                      primary={`${option.serviceType} - ${option.serviceName}`}
                      secondary={`${option.hourlyCost} kr/h`}
                    />
                  </ListItem>
                );
              }}
              disableClearable
              onChange={(
                event: React.SyntheticEvent<Element, Event>,
                value: IService | null
              ) => {
                if (event && value) {
                  setNewFormProjectService({
                    ...newFormProjectService,
                    serviceId: value.id,
                    service: value,
                  });
                }
              }}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label={"Välj tjänst"}
                  slotProps={{
                    input: {
                      ...params.InputProps,
                      endAdornment: (
                        <Fragment>
                          {loadingServices ? (
                            <CircularProgress color="inherit" size={20} />
                          ) : null}
                          {params.InputProps.endAdornment}
                        </Fragment>
                      ),
                    },
                  }}
                />
              )}
            />
          </Stack>
          <Stack width={"35%"}>
            <TextField
              helperText={
                isSubmitted &&
                (!newFormProjectService.estimatedHours ||
                  newFormProjectService.estimatedHours === 0)
                  ? "Antalet timmar måste fyllas i"
                  : ""
              }
              error={
                isSubmitted &&
                (!newFormProjectService.estimatedHours ||
                  newFormProjectService.estimatedHours === 0)
              }
              type="number"
              label="Antal timmar"
              value={newFormProjectService.estimatedHours}
              onChange={(e) => {
                setNewFormProjectService({
                  ...newFormProjectService,
                  estimatedHours: parseInt(e.target.value),
                });
              }}
            />
          </Stack>
        </Stack>
        <Button type="submit" variant="contained">
          Lägg till tjänst
        </Button>
      </Box>
    </>
  );
};
