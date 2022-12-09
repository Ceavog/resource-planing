import AppBar from "@mui/material/AppBar";
import Box from "@mui/material/Box";
import Toolbar from "@mui/material/Toolbar";
import Container from "@mui/material/Container";
import Button from "@mui/material/Button";
import { Link } from "react-router-dom";

function Navi() {
  return (
    <AppBar position="static">
      <Container>
        <Toolbar disableGutters>
          <Box sx={{ flexGrow: 1, display: "flex", justifyContent: "space-between" }}>
            <Box>
              {/* <Button sx={{ my: 2, color: "white" }} component={Link} to="/example">
                Example
              </Button> */}
              <Button sx={{ my: 2, color: "white" }} component={Link} to="/order">
                Zamów
              </Button>
              <Button sx={{ my: 2, color: "white" }} component={Link} to="/register">
                Rejestracja
              </Button>
              <Button sx={{ my: 2, color: "white" }} component={Link} to="/login">
                Logowanie
              </Button>
            </Box>
            <Box>
              <Button sx={{ my: 2, color: "white" }} component={Link} to="/settings">
                Ustawienia
              </Button>
              <Button sx={{ my: 2, color: "white" }} component={Link} to="/profile">
                Profil
              </Button>
              <Button onClick={() => {}} sx={{ my: 2, color: "white" }}>
                Wyloguj
              </Button>
            </Box>
          </Box>
        </Toolbar>
      </Container>
    </AppBar>
  );
}
export default Navi;
