import { FormControl, MenuItem, TextField } from "@mui/material";

type Props = {
  id: string;
  options: any;
  placeholder?: string;
  register?: any;
  defaultValue?: any;
  setValue: any;
  label: string;
  required?: boolean;
};

const Select: React.FC<Props> = ({ id, register, defaultValue, setValue, label, options, ...props }) => {
  return (
    <FormControl sx={{ minWidth: 120 }}>
      {/* <InputLabel id="demo-simple-select-error-label">Age</InputLabel> */}
      <TextField
        select
        inputRef={register(id)}
        onChange={(e) => setValue(id, e.target.value, true)}
        label={label}
        defaultValue={defaultValue}
        {...props}
      >
        {options.map((option: any) => (
          <MenuItem key={option.label} value={option.value}>
            {option.label}
          </MenuItem>
        ))}
      </TextField>
      {/* <FormHelperText>Error</FormHelperText> */}
    </FormControl>
  );
};

export default Select;
