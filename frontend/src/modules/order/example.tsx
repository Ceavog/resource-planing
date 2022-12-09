import { Box } from "@mui/material";
import API from "api";
import Button from "components/button";
import { useEffect } from "react";

const Example = () => {
  const login = async () => {
    const response1 = await API.post("/LoginUser?login=admin@admin.pl&password=admin");
    console.log(response1);
  };
  const example = async () => {
    const response = await API.get("example2");
    console.log(response);
  };
  const refresh = async () => {
    const response2 = await API.get("/RefreshToken");
    console.log(response2);
  };

  // useEffect(() => {
  //   example();
  // }, []);

  return (
    <Box>
      <Button
        onClick={() => {
          login();
        }}
      >
        login
      </Button>
      <Button
        onClick={() => {
          example();
        }}
      >
        example
      </Button>
      <Button
        onClick={() => {
          refresh();
        }}
      >
        refresh
      </Button>
    </Box>
  );
};

export default Example;
