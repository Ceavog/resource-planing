import Avatar from "@mui/material/Avatar";
import Button from "@mui/material/Button";
import Link from "@mui/material/Link";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import FormInput from "components/forms/text-control/text-control";
import { useForm, SubmitHandler, FormProvider } from "react-hook-form";
import { useAuthContext } from "services/auth";

type FormData = {
  login: string;
  password: string;
};

const Login = () => {
  const methods = useForm<FormData>();
  const auth = useAuthContext();

  const onSubmitHandler: SubmitHandler<FormData> = (values: FormData) => {
    const { login, password } = values;

    if (login && password) {
      auth?.login({ login, password });
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
          Sign In
        </Typography>
        <FormProvider {...methods}>
          <Box sx={{ mt: 1 }} component="form" noValidate autoComplete="off" onSubmit={methods.handleSubmit(onSubmitHandler)}>
            <FormInput label="Email Address" type="email" name="login" focused required fullWidth margin="normal" />
            <FormInput type="password" label="Password" name="password" required focused fullWidth margin="normal" />
            <Button type="submit" fullWidth variant="contained" sx={{ mt: 3, mb: 2 }}>
              Sign In
            </Button>
            <Grid container>
              <Grid item xs>
                <Link href="#" variant="body2">
                  Forgot password?
                </Link>
              </Grid>
              <Grid item>
                <Link href="#" variant="body2">
                  {"Don't have an account? Sign Up"}
                </Link>
              </Grid>
            </Grid>
          </Box>
        </FormProvider>
      </Box>
    </Container>
  );
};

export default Login;
