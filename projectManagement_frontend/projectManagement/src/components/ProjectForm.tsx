import {
  Autocomplete,
  Box,
  CircularProgress,
  ListItem,
  ListItemText,
  Stack,
  TextField,
} from "@mui/material";
import Button from "@mui/material/Button";
import { useAppContext } from "./hooks/useAppContext";
import { FormEvent, Fragment, useEffect, useState } from "react";
import { ICustomer } from "../interfaces/ICustomer";
import { getAllCustomers } from "../services/customerServices";
import { IProjectManager } from "../interfaces/IProjectManager";
import { getAllProjectManagers } from "../services/userServices";
import { getStatusTypes } from "../services/statusTypeServices";
import { IStatusType } from "../interfaces/IStatusType";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";
import dayjs, { Dayjs } from "dayjs";
import { DateTime } from "ts-luxon";
import { createNewProject } from "../services/projectServices";

interface IProjectFormProps {
  submitted: boolean;
  setSubmitted: (s: boolean) => void;
}

export const ProjectForm = ({ submitted, setSubmitted }: IProjectFormProps) => {
  const { currentProject, setCurrentProject } = useAppContext();

  const [customers, setCustomers] = useState<ICustomer[]>([]);
  const [openCustomers, setOpenCustomers] = useState(false);
  const [loadingCustomers, setLoadingCustomers] = useState(false);

  const [projectManagers, setProjectManagers] = useState<IProjectManager[]>([]);
  const [openManagers, setOpenManagers] = useState(false);
  const [loadingManagers, setLoadingManagers] = useState(false);

  const [statusTypes, setStatusTypes] = useState<IStatusType[]>([]);
  const [choosenStatus, setChoosenStatus] = useState<IStatusType | undefined>(
    undefined
  );

  const postNewProject = async () => {
    const createdResponse = await createNewProject(currentProject);
    console.log(createdResponse);
  };

  const handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    setSubmitted(true);
    postNewProject();
  };

  const handleOpenCustomers = async () => {
    setOpenCustomers(true);
    setLoadingCustomers(true);
    const res = await getAllCustomers();
    setLoadingCustomers(false);
    setCustomers(res);
  };

  const handleCloseCustomer = () => {
    setOpenCustomers(false);
    // kan tömma customers om jag vill. onödiga anrop dock,  så behåll om d inte ändras så ofta
  };

  const handleOpenManagers = async () => {
    setOpenManagers(true);
    setLoadingManagers(true);
    const res = await getAllProjectManagers();
    setLoadingManagers(false);
    setProjectManagers(res);
  };

  const handleCloseManagers = () => {
    setOpenManagers(false);
    // kan tömma om jag vill. onödiga anrop dock, så behåll om d inte ändras så ofta
  };

  const fetchStatuses = async () => {
    const res = await getStatusTypes();
    setStatusTypes(res);
  };

  const handleStartDateChange = (newValue: Dayjs | null, dateName: string) => {
    if (newValue) {
      const luxonDate = DateTime.fromJSDate(newValue.toDate());
      console.log("Luxon DateTime:", luxonDate.toLocaleString());

      if (dateName === "startDate") {
        setCurrentProject({
          ...currentProject,
          projectSchedule: {
            ...currentProject.projectSchedule,
            startDate: luxonDate,
          },
        });
      }
      if (dateName === "endDate") {
        setCurrentProject({
          ...currentProject,
          projectSchedule: {
            ...currentProject.projectSchedule,
            endDate: luxonDate,
          },
        });
      }
    }
  };

  useEffect(() => {
    fetchStatuses();
  }, []);

  return (
    <>
      <Box
        component={"form"}
        width={"100%"}
        onSubmit={handleSubmit}
        padding={2}
      >
        <Stack direction={"row"} spacing={2} width={"100%"} marginBottom={2}>
          <Stack width={"16%"}>
            <TextField
              fullWidth
              disabled
              label={"Projektnummer"}
              value={currentProject.id}
            />
          </Stack>
          <Stack width={"42%"}>
            <TextField
              fullWidth
              value={currentProject.projectName}
              label={"Projektnamn"}
              error={
                submitted && currentProject.projectName.trim().length === 0
              }
              helperText={
                submitted && currentProject.projectName.trim().length === 0
                  ? "Projektet måste ha ett namn"
                  : ""
              }
              onChange={(e) =>
                setCurrentProject({
                  ...currentProject,
                  projectName: e.target.value,
                })
              }
            />
          </Stack>
          <Stack width={"42%"}>
            <Autocomplete
              fullWidth
              open={openCustomers}
              onOpen={handleOpenCustomers}
              onClose={handleCloseCustomer}
              getOptionLabel={(c: ICustomer) => c.customerName}
              isOptionEqualToValue={(c, value) =>
                c.customerName === value.customerName
              }
              options={customers}
              loading={loadingCustomers}
              renderOption={(props, option, state) => {
                return (
                  <ListItem {...props} key={state.index}>
                    <ListItemText primary={option.customerName} />
                  </ListItem>
                );
              }}
              disableClearable
              onChange={(
                event: React.SyntheticEvent<Element, Event>,
                value: ICustomer | null
              ) => {
                if (event && value) {
                  setCurrentProject({
                    ...currentProject,
                    customerId: value.id,
                  });
                }
              }}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label={"Kunder"}
                  slotProps={{
                    input: {
                      ...params.InputProps,
                      endAdornment: (
                        <Fragment>
                          {loadingCustomers ? (
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
        </Stack>

        <Stack direction={"row"} spacing={2} width={"100%"} marginBottom={2}>
          <Stack width={"40%"}>
            <TextField
              fullWidth
              label="Förväntad kostnad"
              type="number"
              slotProps={{
                inputLabel: {
                  shrink: true,
                },
              }}
              value={currentProject.totalCost}
              onChange={(e) => {
                setCurrentProject({
                  ...currentProject,
                  totalCost: parseInt(e.target.value),
                });
              }}
            />
          </Stack>

          <Stack width={"60%"}>
            <Autocomplete
              fullWidth
              open={openManagers}
              onOpen={handleOpenManagers}
              onClose={handleCloseManagers}
              getOptionLabel={(pm: IProjectManager) => pm.name}
              isOptionEqualToValue={(pm, value) => pm.name === value.name}
              options={projectManagers}
              loading={loadingManagers}
              renderOption={(props, option, state) => {
                return (
                  <ListItem {...props} key={state.index}>
                    <ListItemText primary={option.name} />
                  </ListItem>
                );
              }}
              disableClearable
              onChange={(
                event: React.SyntheticEvent<Element, Event>,
                value: IProjectManager | null
              ) => {
                if (event && value) {
                  setCurrentProject({
                    ...currentProject,
                    userId: value.id,
                  });
                }
              }}
              renderInput={(params) => (
                <TextField
                  {...params}
                  label={"Projektledare"}
                  slotProps={{
                    input: {
                      ...params.InputProps,
                      endAdornment: (
                        <Fragment>
                          {loadingManagers ? (
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
        </Stack>

        <Stack direction={"row"} spacing={2} marginBottom={2}>
          <Stack width={"30%"}>
            <Autocomplete
              options={statusTypes}
              getOptionLabel={(option) => option.statusName}
              value={choosenStatus}
              isOptionEqualToValue={(option, value) => option.id === value.id}
              renderInput={(params) => <TextField label="Status" {...params} />}
              renderOption={(props, option) => (
                <ListItem {...props} key={option.id}>
                  <ListItemText primary={option.statusName} />
                </ListItem>
              )}
              disableClearable
              onChange={(event, value) => {
                if (event && value) {
                  setChoosenStatus(value); // Spara hela objektet
                  setCurrentProject({
                    ...currentProject,
                    statusTypeId: value.id, // Spara endast ID i currentProject
                  });
                }
              }}
            />
          </Stack>
          <LocalizationProvider dateAdapter={AdapterDayjs}>
            <Stack width={"40%"}>
              <DatePicker
                minDate={dayjs()}
                label="Startdatum"
                value={dayjs(
                  currentProject.projectSchedule.startDate.toJSDate()
                )}
                onChange={(newValue) =>
                  handleStartDateChange(newValue, "startDate")
                }
              />
            </Stack>
            <Stack width={"40%"}>
              <DatePicker
                label="Slutdatum"
                minDate={dayjs(
                  currentProject.projectSchedule.startDate?.toJSDate()
                )}
                value={dayjs(
                  currentProject.projectSchedule.endDate?.toJSDate()
                )}
                onChange={(newValue) =>
                  handleStartDateChange(newValue, "endDate")
                }
              />
            </Stack>{" "}
          </LocalizationProvider>
        </Stack>

        <Stack
          direction={"row"}
          spacing={2}
          alignItems={"flex-end"}
          marginBottom={2}
        >
          <TextField
            multiline
            fullWidth
            rows={4}
            label="Beskrivning"
            value={currentProject.description}
            onChange={(e) =>
              setCurrentProject({
                ...currentProject,
                description: e.target.value,
              })
            }
          />
        </Stack>
        <Stack direction={"row"} width={"100%"} justifyContent={"flex-end"}>
          <Button variant="contained" size="large" type="submit">
            Skapa projekt
          </Button>
        </Stack>
      </Box>
    </>
  );
};
