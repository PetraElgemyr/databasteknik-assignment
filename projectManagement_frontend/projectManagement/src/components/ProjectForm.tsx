import {
  Autocomplete,
  Box,
  ListItem,
  ListItemText,
  Stack,
  TextField,
} from "@mui/material";
import Button from "@mui/material/Button";
import { useAppContext } from "./hooks/useAppContext";
import { FormEvent, useCallback, useEffect, useState } from "react";
import { defaultCustomer, ICustomer } from "../interfaces/ICustomer";
import { getAllCustomers } from "../services/customerServices";
import {
  defaultProjectManager,
  IProjectManager,
} from "../interfaces/IProjectManager";
import { getAllProjectManagers } from "../services/userServices";
import { getStatusTypes } from "../services/statusTypeServices";
import { defaultStatusType, IStatusType } from "../interfaces/IStatusType";
import { AdapterDayjs } from "@mui/x-date-pickers/AdapterDayjs";
import { LocalizationProvider } from "@mui/x-date-pickers/LocalizationProvider";
import { DatePicker } from "@mui/x-date-pickers/DatePicker";
import dayjs, { Dayjs } from "dayjs";
import {
  createNewProject,
  updateExistingProject,
} from "../services/projectServices";
import { IProjectWithDetails } from "../interfaces/IProjectWithDetails";
import { useNavigate } from "react-router-dom";
import "dayjs/locale/sv";
import { IService } from "../interfaces/IService";
import { getAllServices } from "../services/serviceServices";
dayjs.locale("sv");

interface IProjectFormProps {
  fetchedProject: IProjectWithDetails;
  isEditMode: boolean;
  setIsEditMode: (isEditMode: boolean) => void;
  fetchProjectByParamsId: () => void;
}

export const ProjectForm = ({
  fetchedProject,
  isEditMode,
  setIsEditMode,
  fetchProjectByParamsId,
}: IProjectFormProps) => {
  const [submitted, setSubmitted] = useState<boolean>(false);
  const { currentProject, setCurrentProject } = useAppContext();
  const navigate = useNavigate();

  const [customers, setCustomers] = useState<ICustomer[]>([]);
  const [openCustomers, setOpenCustomers] = useState(false);
  const [currentCustomer, setCurrentCustomer] =
    useState<ICustomer>(defaultCustomer);

  const [projectManagers, setProjectManagers] = useState<IProjectManager[]>([]);
  const [openManagers, setOpenManagers] = useState(false);
  const [currentProjectManager, setCurrentProjectManager] =
    useState<IProjectManager>(defaultProjectManager);

  const [statusTypes, setStatusTypes] = useState<IStatusType[]>([]);
  const [openStatuses, setOpenStatuses] = useState(false);
  const [currentStatus, setCurrentStatus] =
    useState<IStatusType>(defaultStatusType);

  const [services, setServices] = useState<IService[]>([]);
  const [openServices, setOpenServices] = useState(false);
  // const [selectedService, setSelectedService] =
  //   useState<IService>(emptyService);

  const postNewProject = async () => {
    const createdProject = await createNewProject(currentProject);
    if (createdProject) {
      setIsEditMode(false);
      setSubmitted(false);
      navigate(`/projects/${createdProject.id}`);
    }
  };

  const updateProjectRequest = async () => {
    const updatedProject = await updateExistingProject(currentProject);

    if (updatedProject) {
      setSubmitted(false);
      setIsEditMode(false);
      fetchProjectByParamsId();
    }
  };

  const validateProjectForm = (): boolean => {
    if (
      currentProject.customerId === 0 ||
      currentProject.userId === 0 ||
      currentProject.statusTypeId === 0 ||
      currentProject.projectSchedule.startDate === null ||
      (currentProject.projectSchedule.endDate &&
        currentProject.projectSchedule.endDate <
          currentProject.projectSchedule.startDate) ||
      currentProject.projectName.trim().length === 0 ||
      currentProject.totalCost === 0 ||
      currentProject.description === ""
    ) {
      return false;
    }

    return true;
  };

  const handleSubmit = (e: FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    setSubmitted(true);
    const isValid = validateProjectForm();

    if (!isValid) {
      return;
    }

    if (isEditMode && fetchedProject.id > 0) {
      updateProjectRequest();
    } else if (!currentProject.id && !isEditMode) {
      postNewProject();
    }
  };

  const getCustomers = async () => {
    const res = await getAllCustomers();
    return res;
  };

  const fetchStatuses = async () => {
    const res = await getStatusTypes();
    return res;
  };

  const handleStartDateChange = (newValue: Dayjs | null, dateName: string) => {
    if (newValue) {
      // const luxonDate = DateTime.fromJSDate(newValue.toDate());
      const newDate = newValue.toDate();

      if (dateName === "startDate") {
        setCurrentProject({
          ...currentProject,
          projectSchedule: {
            ...currentProject.projectSchedule,
            startDate: newDate,
          },
        });
      }
      if (dateName === "endDate") {
        setCurrentProject({
          ...currentProject,
          projectSchedule: {
            ...currentProject.projectSchedule,
            endDate: newDate,
          },
        });
      }
    }
  };

  const updateProjectIdIfFetchedProjectExists = useCallback(async () => {
    if (fetchedProject.id > 0) {
      setCurrentProject((prev) => ({ ...prev, id: fetchedProject.id }));
    }
  }, [fetchedProject.id, setCurrentProject]);

  const setCurrentCustomerStatusesAndManagerIfProjectFetched =
    useCallback(async () => {
      const fetchedCustomers = await getCustomers();
      const fetchedManagers = await getAllProjectManagers();
      const fetchedStatuses = await fetchStatuses();
      const fetchedServices = await getAllServices();

      if (fetchedServices) {
        setServices(fetchedServices);
      }

      if (fetchedCustomers) {
        setCustomers(fetchedCustomers);
      }
      if (fetchedManagers) {
        setProjectManagers(fetchedManagers);
      }
      if (fetchedStatuses) {
        setStatusTypes(fetchedStatuses);
      }

      if (fetchedProject.id !== 0) {
        updateProjectIdIfFetchedProjectExists();

        setCurrentCustomer(
          fetchedCustomers.find((c) => c.id === currentProject.customerId) ||
            defaultCustomer
        );

        setCurrentProjectManager(
          fetchedManagers.find((pm) => pm.id === currentProject.userId) ||
            defaultProjectManager
        );

        setCurrentStatus(
          fetchedStatuses.find((s) => s.id === currentProject.statusTypeId) ||
            defaultStatusType
        );
      }
    }, [
      fetchedProject.id,
      currentProject.customerId,
      currentProject.userId,
      currentProject.statusTypeId,
      updateProjectIdIfFetchedProjectExists,
    ]);

  useEffect(() => {
    setCurrentCustomerStatusesAndManagerIfProjectFetched();
  }, [setCurrentCustomerStatusesAndManagerIfProjectFetched]);

  return (
    <>
      <Box
        component={"form"}
        width={"100%"}
        onSubmit={handleSubmit}
        padding={2}
      >
        <Stack direction={"row"} spacing={2} width={"100%"} marginBottom={2}>
          <Stack width={"20%"}>
            <TextField
              fullWidth
              disabled
              label={"Projektnummer"}
              value={fetchedProject.id ? fetchedProject.id : currentProject.id}
            />
          </Stack>
          <Stack width={"80%"}>
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
        </Stack>

        <Stack direction={"row"} spacing={2} width={"100%"} marginBottom={2}>
          <Stack width={"38%"}>
            <Autocomplete
              fullWidth
              open={openCustomers}
              onOpen={() => setOpenCustomers(true)}
              onClose={() => setOpenCustomers(false)}
              value={currentCustomer}
              getOptionLabel={(c: ICustomer) =>
                c.id !== 0 ? c.customerName : "Ej vald"
              }
              isOptionEqualToValue={(c, value) =>
                c.customerName === value.customerName && c.id === value.id
              }
              options={customers}
              renderOption={(props, option, state) => {
                return (
                  <ListItem {...props} key={state.index}>
                    <ListItemText primary={option.customerName} />
                  </ListItem>
                );
              }}
              onChange={(
                event: React.SyntheticEvent<Element, Event>,
                value: ICustomer | null
              ) => {
                if (event && value) {
                  setCurrentCustomer(value);

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
                  helperText={
                    submitted &&
                    currentProject.userId === 0 &&
                    "Du måste välja en kund"
                  }
                  error={submitted && currentProject.customerId === 0}
                />
              )}
            />
          </Stack>

          <Stack width={"24%"}>
            <TextField
              fullWidth
              label="Förväntad kostnad"
              type="number"
              slotProps={{
                inputLabel: {
                  shrink: true,
                },
              }}
              error={
                submitted &&
                (currentProject.totalCost <= 0 || !currentProject.totalCost)
              }
              helperText={
                submitted &&
                currentProject.totalCost <= 0 &&
                "Fältet får inte lämnas tomt"
              }
              value={currentProject.totalCost}
              onChange={(e) => {
                setCurrentProject({
                  ...currentProject,
                  totalCost: parseInt(e.target.value),
                });
              }}
            />
          </Stack>

          <Stack width={"38%"}>
            <Autocomplete
              fullWidth
              open={openManagers}
              onOpen={() => setOpenManagers(true)}
              onClose={() => setOpenManagers(false)}
              value={currentProjectManager}
              getOptionLabel={(pm: IProjectManager) =>
                pm.id !== 0 ? pm.name : "Ingen vald"
              }
              isOptionEqualToValue={(pm, value) =>
                pm.id === value.id && pm.name === value.name
              }
              options={projectManagers}
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
                  setCurrentProjectManager(value);

                  setCurrentProject({
                    ...currentProject,
                    userId: value.id,
                  });
                }
              }}
              renderInput={(params) => (
                <TextField
                  {...params}
                  helperText={
                    submitted &&
                    currentProject.userId === 0 &&
                    "Du måste välja en projektledare"
                  }
                  error={submitted && currentProject.userId === 0}
                  label={"Projektledare"}
                />
              )}
            />
          </Stack>
        </Stack>

        <Stack direction={"row"} spacing={2} marginBottom={2}>
          <Stack width={"30%"}>
            <Autocomplete
              open={openStatuses}
              onOpen={() => setOpenStatuses(true)}
              onClose={() => setOpenStatuses(false)}
              value={currentStatus}
              options={statusTypes}
              getOptionLabel={(s) =>
                s.id !== 0 ? s.statusName : "Ingen status vald"
              }
              isOptionEqualToValue={(option, value) =>
                option.id === value.id && option.statusName === value.statusName
              }
              renderInput={(params) => (
                <TextField
                  label="Status"
                  {...params}
                  helperText={
                    submitted &&
                    currentProject.statusTypeId === 0 &&
                    "Du måste välja en status"
                  }
                  error={submitted && currentProject.statusTypeId === 0}
                />
              )}
              renderOption={(props, option) => (
                <ListItem {...props} key={option.id}>
                  <ListItemText primary={option.statusName} />
                </ListItem>
              )}
              disableClearable
              onChange={(event, value) => {
                if (event && value) {
                  setCurrentStatus(value);
                  setCurrentProject({
                    ...currentProject,
                    statusTypeId: value.id,
                  });
                }
              }}
            />
          </Stack>
          <LocalizationProvider dateAdapter={AdapterDayjs} adapterLocale="sv">
            <Stack width={"40%"}>
              <DatePicker
                format="YYYY-MM-DD"
                label="Startdatum"
                value={dayjs(
                  currentProject.projectSchedule.startDate.toString()
                )}
                onChange={(newValue) => {
                  if (newValue)
                    handleStartDateChange(
                      newValue.set("hour", 12),
                      "startDate"
                    );
                }}
              />
            </Stack>
            <Stack width={"40%"}>
              <DatePicker
                label="Slutdatum"
                minDate={dayjs(
                  currentProject.projectSchedule.startDate?.toString()
                )}
                value={
                  currentProject.projectSchedule.endDate
                    ? dayjs(currentProject.projectSchedule.endDate.toString())
                    : null
                }
                onChange={(newValue) => {
                  if (newValue)
                    handleStartDateChange(newValue.set("hour", 12), "endDate");
                }}
                slotProps={{
                  textField: {
                    error:
                      submitted &&
                      currentProject.projectSchedule.endDate &&
                      currentProject.projectSchedule.endDate <
                        currentProject.projectSchedule.startDate &&
                      true,

                    helperText:
                      submitted &&
                      currentProject.projectSchedule.endDate &&
                      currentProject.projectSchedule.endDate <
                        currentProject.projectSchedule.startDate &&
                      "Slutdatumet kan inte vara tidigare än startdatumet",
                  },
                }}
              />
            </Stack>
          </LocalizationProvider>
        </Stack>
        {!isEditMode && !currentProject.id && (
          <Stack width={"100%"} spacing={2} direction={"row"} marginBottom={2}>
            <Stack width={"65%"}>
              <Autocomplete
                fullWidth
                open={openServices}
                onClose={() => setOpenServices(false)}
                onOpen={() => setOpenServices(true)}
                value={currentProject.projectService.service}
                getOptionLabel={(s: IService) =>
                  s.id !== 0 ? `${s.serviceType} - ${s.serviceName}` : "Ej vald"
                }
                isOptionEqualToValue={(s, value) =>
                  `${s.serviceType} - ${s.serviceName}` ===
                  `${value.serviceType} - ${value.serviceName}`
                }
                options={services}
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
                    setCurrentProject({
                      ...currentProject,
                      projectService: {
                        ...currentProject.projectService,
                        serviceId: value.id,
                        service: value,
                      },
                    });
                  }
                }}
                renderInput={(params) => (
                  <TextField
                    error={
                      submitted &&
                      !isEditMode &&
                      !currentProject.id &&
                      !currentProject.projectService.serviceId
                    }
                    helperText={
                      submitted &&
                      !isEditMode &&
                      !currentProject.id &&
                      !currentProject.projectService.serviceId &&
                      "Obligatoriskt fält när du skapar ett projekt"
                    }
                    {...params}
                    label={"Välj tjänst"}
                  />
                )}
              />
            </Stack>

            <Stack width={"35%"}>
              <TextField
                helperText={
                  submitted &&
                  (!currentProject.projectService.estimatedHours ||
                    currentProject.projectService.estimatedHours <= 0) &&
                  !isEditMode
                    ? "Antalet timmar måste fyllas i"
                    : ""
                }
                error={
                  submitted &&
                  (!currentProject.projectService.estimatedHours ||
                    currentProject.projectService.estimatedHours <= 0) &&
                  !isEditMode
                }
                type="number"
                label="Antal timmar"
                value={currentProject.projectService.estimatedHours}
                onChange={(e) => {
                  setCurrentProject({
                    ...currentProject,
                    projectService: {
                      ...currentProject.projectService,
                      estimatedHours: parseInt(e.target.value),
                    },
                  });
                }}
              />
            </Stack>
          </Stack>
        )}

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
            error={submitted && currentProject.description.trim().length === 0}
            helperText={
              submitted &&
              currentProject.description.trim().length === 0 &&
              "Beskrivning fattas"
            }
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
            {isEditMode ? "Spara" : "Lägg till"}
          </Button>
        </Stack>
      </Box>
    </>
  );
};
