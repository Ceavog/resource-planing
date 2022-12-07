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
              <Button sx={{ my: 2, color: "white" }} component={Link} to="/market">
                Zamów
              </Button>
              <Button sx={{ my: 2, color: "white" }} component={Link} to="/settings/products">
                Ustawienia
              </Button>
            </Box>
            <Button onClick={() => {}} sx={{ my: 2, color: "white", display: "block" }}>
              Wyloguj
            </Button>
          </Box>
        </Toolbar>
      </Container>
    </AppBar>
  );
}
export default Navi;
