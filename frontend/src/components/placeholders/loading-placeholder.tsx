import { Box, CircularProgress, Container } from "@mui/material";

const LoadingPlaceholder = () => {
  return (
    <Container sx={{ height: "95vh" }}>
      <Box display="flex" alignItems="center" justifyContent="center" sx={{ height: "100%" }}>
        <CircularProgress />
      </Box>
    </Container>
  );
};
export default LoadingPlaceholder;
