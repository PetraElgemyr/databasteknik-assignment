import Box from "@mui/material/Box";
import { DataGrid, GridColDef } from "@mui/x-data-grid";
import { useAppContext } from "./hooks/useAppContext";
import { formatDateHelper } from "./helpers/dateHelper";

export const ProjectsDataGrid = () => {
  const { projects } = useAppContext();

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
      valueGetter: (value, row) => formatDateHelper(row.endDate),
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
          disableRowSelectionOnClick
          onRowClick={(par) => {
            // ta id till url, hämta projekt med detalj by id och navigera till den länken
            console.log(par.row, "projektnr:", par.id);
          }}
        />
      </Box>
    </>
  );
};
