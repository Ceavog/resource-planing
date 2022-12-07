import { ButtonGroup, Grid } from "@mui/material";
import Button from "components/button";
import Input from "components/formControls/input";
import { DisplayLoadingContext } from "components/loadingProgress/providers/loading-provider";
import { ModalBoxContext } from "components/modalBox/providers/modalBox";
import { useContext } from "react";
import { useForm } from "react-hook-form";
import { useMutation } from "react-query";
import { addCategory } from "services/api/actions/settings.actions";

type AddCategoryFormValues = {
  name: string;
  userId: number;
};

const AddCategoryForm = () => {
  const { actionModalBox } = useContext(ModalBoxContext);
  const { displayLoader } = useContext(DisplayLoadingContext);
  const {
    handleSubmit,
    register,
    formState: { errors },
  } = useForm({
    defaultValues: {
      name: "",
      userId: 1,
    },
  });

  const { isLoading, mutate } = useMutation(addCategory, {
    onSuccess: () => {
      alert("Udało sie dodać kategorie");
      actionModalBox(false, null, "");
    },
    onError: (err: any) => {
      alert(`Nie udało się - ${err.response.data}`);
    },
  });

  displayLoader(isLoading);

  const onSubmit = async (data: AddCategoryFormValues) => {
    mutate(data);
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <Grid container spacing={2}>
        <Grid item xs={6}>
          <Input id="name" label="Nazwa" placeholder="Nazwa" register={register} errors={errors} required />
        </Grid>
        <Grid item xs={6}></Grid>
      </Grid>
      <Grid container justifyContent="flex-end">
        <ButtonGroup variant="outlined">
          <Button onClick={() => actionModalBox(false, null, "")}>Anuluj</Button>
          <Button variant="contained" type="submit">
            Dodaj
          </Button>
        </ButtonGroup>
      </Grid>
    </form>
  );
};

export default AddCategoryForm;
