import {
  Autocomplete,
  Box,
  CircularProgress,
  ListItem,
  ListItemText,
  Stack,
  TextField,
} from "@mui/material";
import { Fragment, useState } from "react";
import { getAllServices } from "../services/serviceServices";
import { IService } from "../interfaces/IService";
import { IProjectService } from "../interfaces/IProjectService";
import { useAppContext } from "./hooks/useAppContext";

export const ProjectServiceForm = () => {
  const { currentProject } = useAppContext();
  const [openServices, setOpenServices] = useState(false);
  const [loadingServices, setLoadingServices] = useState(false);
  const [allServices, setAllServices] = useState<IService[]>([]);
  const [newProjectService, setNewProjectService] = useState<IProjectService>({
    projectId: currentProject.id!,
    serviceId: 0,
    service: {
      id: 0,
      serviceType: "",
      hourlyCost: 0,
    },
  });

  const handleProjectServiceSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    // lägg till ny tjänst till projektet. addProjectService
    // behövs ej ta bort
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
      <Box
        component={"form"}
        width={"90%"}
        onSubmit={handleProjectServiceSubmit}
        padding={2}
      >
        <Stack direction={"row"} spacing={2}>
          <Stack width={"60%"}>
            <Autocomplete
              fullWidth
              open={openServices}
              loading={loadingServices}
              onOpen={handleOpenServices}
              onClose={handleCloseServices}
              getOptionLabel={(s: IService) => s.serviceType}
              isOptionEqualToValue={(s, value) =>
                s.serviceType === value.serviceType
              }
              options={allServices}
              renderOption={(props, option, state) => {
                return (
                  <ListItem {...props} key={state.index}>
                    <ListItemText
                      primary={option.serviceType}
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
                  setNewProjectService({
                    ...newProjectService,
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
            />{" "}
          </Stack>
          <Stack width={"30%"}>
            <TextField label="Antal timmar" />
          </Stack>{" "}
        </Stack>
      </Box>
    </>
  );
};
