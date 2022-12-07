import { Button as MuiButton, ButtonProps } from "@mui/material";

type Props = ButtonProps & {};

const Button: React.FC<Props> = (props) => {
  return <MuiButton {...props}>{props.children}</MuiButton>;
};

export default Button;
