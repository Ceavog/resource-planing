import { Box, Container, Typography } from "@mui/material";
import { useUser } from "api/providers/user-provider";

const Profile = () => {
  const userContext = useUser();
  const user = userContext?.state.authUser;

  return (
    <Container>
      <Box
        maxWidth="lg"
        sx={{
          maxHeight: "20rem",
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
          p: "2rem",
          mx: "auto",
        }}
      >
        <Typography variant="h2" component="h1" sx={{ color: "#1f1e1e", fontWeight: 500 }}>
          Profile Page
        </Typography>
        <Box sx={{ mt: 2 }}>
          <Typography gutterBottom>
            <strong>Id:</strong> {user?.id}
          </Typography>
          <Typography gutterBottom>
            <strong>Full Name:</strong> {"Nie ma na razie"}
          </Typography>
          <Typography gutterBottom>
            <strong>Email Address:</strong> {user?.login}
          </Typography>
          <Typography gutterBottom>
            <strong>Role:</strong> {user?.role}
          </Typography>
        </Box>
      </Box>
    </Container>
  );
};

export default Profile;
