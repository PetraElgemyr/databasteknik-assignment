import { Box, Paper, Stack, Typography } from "@mui/material";
import { IProjectWithDetails } from "../interfaces/IProjectWithDetails";
import { formatDateHelper } from "./helpers/dateHelper";
import { DataGrid } from "@mui/x-data-grid/DataGrid";
import { IProjectService } from "../interfaces/IProjectService";
import { useCallback, useEffect, useState } from "react";
import { getAllProjectServicesByProjectId } from "../services/projectServicesServices";
import { GridColDef } from "@mui/x-data-grid";

interface IProjectViewProps {
  project: IProjectWithDetails;
}

export const ProjectView = ({ project }: IProjectViewProps) => {
  const [services, setServices] = useState<IProjectService[]>([]);

  const columns: GridColDef[] = [
    { field: "projectId", headerName: "Projektnummer", width: 150 },
    { field: "serviceId", headerName: "Tjänstens ID", width: 150 },
    {
      field: "service.serviceName",
      headerName: "Tjänst",
      width: 250,
      valueGetter: (value, row) => {
        return row.service.serviceType;
      },
    },
    {
      field: "service.hourlyCost",
      headerName: "Timpris (sek)",
      width: 150,
      valueGetter: (value, row) => {
        return row.service.hourlyCost;
      },
    },
  ];

  const fetchServicesForProject = useCallback(async () => {
    const res = await getAllProjectServicesByProjectId(project.id.toString());
    setServices(res);
  }, [setServices, project.id]);

  useEffect(() => {
    fetchServicesForProject();
  }, [fetchServicesForProject]);

  return (
    <>
      <Box>
        <Typography variant="h4" gutterBottom>
          Projektnummer: {project.id} - {project.projectName}
        </Typography>
        <Stack spacing={3} direction="row">
          <Typography variant="h6" gutterBottom>
            Startdatum {formatDateHelper(project.projectSchedule.startDate)}
          </Typography>
          {project.projectSchedule.endDate && (
            <Typography variant="h6" gutterBottom>
              Slutdatum {formatDateHelper(project.projectSchedule.endDate)}
            </Typography>
          )}
        </Stack>
        <Box>
          <Typography gutterBottom>
            Beskrivning {project.description}
          </Typography>
        </Box>
        <Stack spacing={3} direction="row" width={"100%"}>
          <Stack width={"50%"}>
            <Paper>
              <Box padding={3}>
                <Typography variant="h6" gutterBottom>
                  Projektledare
                </Typography>
                <Typography gutterBottom>
                  Namn: {project.user.firstName} {project.user.lastName}
                </Typography>
                <Typography gutterBottom>
                  Mejladress: {project.user.email}
                </Typography>
                <Typography gutterBottom>
                  Telefonnummer:
                  {project.user.phoneNumber
                    ? project.user.phoneNumber
                    : "Saknas"}
                </Typography>
              </Box>
            </Paper>
          </Stack>
          <Stack width={"50%"}>
            <Paper>
              <Box padding={3}>
                <Typography variant="h6" gutterBottom>
                  Kund: {project.customer.customerName}
                </Typography>
                <Typography gutterBottom>
                  Kundnummer: {project.customer.customerType.id}
                </Typography>
                <Typography gutterBottom>
                  Typ: {project.customer.customerType.customerTypeName}
                </Typography>
              </Box>
            </Paper>
          </Stack>
        </Stack>
        <Box>
          <Typography variant="h6" gutterBottom>
            Projektets tjänster
          </Typography>
          <DataGrid
            rowSelection={false}
            getRowId={(row) => `${row.project}-${row.serviceId}}`}
            rows={services}
            columns={columns}
            pageSizeOptions={[5]}
          />
        </Box>
      </Box>
    </>
  );
};
