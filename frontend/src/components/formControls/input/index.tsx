import { TextField, StandardTextFieldProps } from "@mui/material";

type Props = StandardTextFieldProps & {
  id: string;
  errors?: any;
  register?: any;
  minLength?: number;
  maxLength?: number;
};

const Input: React.FC<Props> = ({ id, maxLength, register, variant = "outlined", errors, ...props }) => {
  return (
    <TextField
      id={id}
      variant={variant}
      {...props}
      {...register(id)}
      inputProps={{ maxLength: maxLength }}
      error={Boolean(errors[id])}
    />
  );
};

export default Input;
