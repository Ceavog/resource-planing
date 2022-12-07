import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import Link from "@mui/material/Link";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { backendEndpoints } from "config/routes";
import FormInput from "components/forms/text-control/text-control";
import { useForm, SubmitHandler, FormProvider } from "react-hook-form";
import { API } from "api";

type FormData = {
  email: string;
  password: string;
};

const Register = () => {
  const methods = useForm<FormData>();

  const onSubmitHandler: SubmitHandler<FormData> = (values: FormData) => {
    const { email, password } = values;

    if (email && password) {
      API.post(backendEndpoints.registerUser.replace(":login", email).replace(":password", password))
        .then((res) => {
          console.log(res);
        })
        .catch((err) => {
          console.log(err);
        });
    }
  };

  return (
    <Container component="main" maxWidth="xs">
      <Box
        sx={{
          marginTop: 8,
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
        }}
      >
        <Avatar sx={{ m: 1, bgcolor: "secondary.main" }}>
          <LockOutlinedIcon />
        </Avatar>
        <Typography component="h1" variant="h5">
          Sign Up
        </Typography>
        <FormProvider {...methods}>
          <Box sx={{ mt: 1 }} component="form" noValidate autoComplete="off" onSubmit={methods.handleSubmit(onSubmitHandler)}>
            <FormInput label="Email Address" type="email" name="email" focused required fullWidth margin="normal" />
            <FormInput type="password" label="Password" name="password" required focused fullWidth margin="normal" />
            <Button type="submit" fullWidth variant="contained" sx={{ mt: 3, mb: 2 }}>
              Sign Up
            </Button>
            <Grid container>
              <Grid item xs>
                <Link href="/login" variant="body2">
                  You've already created an account? Sign In
                </Link>
              </Grid>
            </Grid>
          </Box>
        </FormProvider>
      </Box>
    </Container>
  );
};

export default Register;
