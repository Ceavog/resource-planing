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
import { object, string, TypeOf } from "zod";
import { useNavigate, useLocation } from "react-router-dom";
import { zodResolver } from "@hookform/resolvers/zod";
import { useMutation, useQuery } from "react-query";
import { useUser } from "api/providers/user-provider";
import { useEffect } from "react";
import { requestIndentity, requestLogin } from "api";

const loginSchema = object({
  login: string().min(1, "Login is required"),
  password: string(),
  // .min(1, "Password is required")
  // .min(8, "Password must be more than 8 characters")
  // .max(32, "Password must be less than 32 characters"),
});

export type LoginInput = TypeOf<typeof loginSchema>;

const Login = () => {
  const navigate = useNavigate();
  const location = useLocation();

  const from = ((location.state as any)?.from.pathname as string) || "/";

  const methods = useForm<LoginInput>({
    resolver: zodResolver(loginSchema),
  });

  const userContext = useUser();

  const query = useQuery(["authUser"], requestIndentity, {
    enabled: false,
    retry: 1,
    onSuccess: (data) => {
      userContext?.dispatch({ type: "SET_USER", payload: data });
    },
  });

  const { mutate: loginUser, isLoading } = useMutation((userData: LoginInput) => requestLogin(userData), {
    onSuccess: () => {
      query.refetch();
      alert("You successfully logged in");
      navigate(from);
    },
    onError: (error: any) => {
      if (Array.isArray((error as any).response.data.error)) {
        (error as any).response.data.error.forEach((el: any) => alert(el.message));
      } else {
        alert((error as any).response.data.message);
      }
    },
  });

  const {
    reset,
    handleSubmit,
    formState: { isSubmitSuccessful },
  } = methods;

  useEffect(() => {
    if (isSubmitSuccessful) {
      reset();
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [isSubmitSuccessful]);

  const onSubmitHandler: SubmitHandler<LoginInput> = (values) => {
    loginUser(values);
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
          <Box sx={{ mt: 1 }} component="form" noValidate autoComplete="off" onSubmit={handleSubmit(onSubmitHandler)}>
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
