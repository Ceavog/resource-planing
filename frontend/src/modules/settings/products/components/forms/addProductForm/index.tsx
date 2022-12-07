import { ButtonGroup, Grid } from "@mui/material";
import Button from "components/button";
import Input from "components/formControls/input";
import Select from "components/formControls/select";
import { DisplayLoadingContext } from "components/loadingProgress/providers/loading-provider";
import { ModalBoxContext } from "components/modalBox/providers/modalBox";
import { useContext } from "react";
import { useForm } from "react-hook-form";
import { useMutation, useQuery } from "react-query";
import { addProduct, getCategories } from "api/actions/settings.actions";

// type AddProductFormType = {
//   name: string;
//   price: number;
//   section: number;
//   userId: number;
//   categoryId: number;
// };

const AddProductForm = () => {
  const { actionModalBox } = useContext(ModalBoxContext);
  const { displayLoader } = useContext(DisplayLoadingContext);
  const {
    handleSubmit,
    register,
    formState: { errors },
    setValue,
  } = useForm({ defaultValues: { section: "test", userId: 1 } });

  const { data, isLoading } = useQuery(["categories"], getCategories);

  const { mutate } = useMutation(addProduct, {
    onSuccess: () => {
      alert("Udało sie dodać kategorie");
      actionModalBox(false, null, "");
    },
    onError: (err: any) => {
      alert(`Nie udało się - ${err.response.data}`);
    },
  });

  displayLoader(isLoading);

  if (isLoading) {
    return <>Loading...</>;
  }

  const onSubmit = async (data: any) => {
    mutate(data);
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <Grid container spacing={4}>
        <Grid item xs={12}>
          <Input id="name" label="Nazwa" placeholder="Nazwa" register={register} errors={errors} required />
        </Grid>
        <Grid item xs={12}>
          <Input type="number" id="price" label="Cena" placeholder="Cena" register={register} errors={errors} required />
        </Grid>
        <Grid item xs={12}>
          <Select
            id="categoryId"
            label="Kategoria"
            defaultValue={""}
            options={data?.map((category: any) => {
              return { value: category.id, label: category.name };
            })}
            register={register}
            setValue={setValue}
            placeholder="test"
            required
          />
        </Grid>
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

export default AddProductForm;
