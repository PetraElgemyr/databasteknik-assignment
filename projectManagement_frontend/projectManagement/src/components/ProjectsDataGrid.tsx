import Box from "@mui/material/Box";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import { useAppContext } from "./hooks/useAppContext";
import { formatDateHelper } from "./helpers/dateHelper";
import { useNavigate } from "react-router-dom";

interface ProjectsDataGridProps {
  setSelectedProjectId: (id: number | null) => void;
}

export const ProjectsDataGrid = ({
  setSelectedProjectId,
}: ProjectsDataGridProps) => {
  const { projects } = useAppContext();
  const navigate = useNavigate();

  const columns: GridColDef<(typeof projects)[number]>[] = [
    { field: "id", headerName: "Projektnummer", width: 120 },
    {
      field: "projectName",
      headerName: "Projektnamn",
      width: 200,
    },
    {
      field: "customerName",
      headerName: "Kund",
      width: 200,
    },
    {
      field: "statusTypeName",
      headerName: "Status",
      width: 150,
    },
    {
      field: "startDate",
      headerName: "Startdatum",
      width: 150,
      valueGetter: (value, row) => formatDateHelper(row.startDate),
    },

    {
      field: "endDate",
      headerName: "Slutdatum",
      width: 150,
      valueGetter: (value, row) =>
        row.endDate ? formatDateHelper(row.endDate) : "Saknas",
    },
    {
      field: "totalCost",
      headerName: "Beräknad kostnad (SEK)",
      type: "number",
      width: 200,
    },
  ];

  return (
    <>
      <Box sx={{ height: 400, width: "100%" }}>
        <DataGrid
          disableMultipleRowSelection
          checkboxSelection
          disableRowSelectionOnClick
          rows={projects}
          columns={columns}
          initialState={{
            pagination: {
              paginationModel: {
                pageSize: 5,
              },
            },
          }}
          pageSizeOptions={[5]}
          onRowSelectionModelChange={(newSelection) => {
            const selectedId =
              newSelection.length > 0 ? Number(newSelection[0]) : null;
            setSelectedProjectId(selectedId);
          }}
          onRowClick={(par) => {
            navigate(`/projects/${par.id}`);
          }}
        />
      </Box>
    </>
  );
};
