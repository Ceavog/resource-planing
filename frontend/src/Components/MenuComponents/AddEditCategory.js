import {useForm} from "react-hook-form";
import {useEffect} from "react";

function AddCategoryComponent(){

    const { register, handleSubmit} = useForm({defaultValues:{name: "1212"}});

    // useEffect()
    const onSubmit = () =>{
        //handle submit
    }

    return(
        <form onSubmit={handleSubmit(onSubmit)}>
            <input {...register("name", {required: true})}/>
            <input type="submit" value={"add category"}/>
        </form>
    )
}

export default AddCategoryComponent;