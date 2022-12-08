import { CategoryType, ProductType } from "modules/settings/products/components/sortableItem";
import API from "..";

export const getProducts = async (): Promise<ProductType[]> => {
  const response = await API.get("/GetAllProductsByUserId?id=1");
  return response.data.value;
};

type AddProductVars = {
  name: string;
  price: number;
  section: number;
  userId: number;
  categoryId: number;
};

export const addProduct = async (addProductVars: AddProductVars) => {
  return await API.post("/AddProduct", addProductVars);
};

export const deleteProduct = async (id: number) => {
  return await API.post(`/DeleteProductById?id=${id}`);
};

type UpdateProductVars = {
  id: number;
  name?: string;
  price?: number;
  section?: number;
  userId?: number;
  categoryId?: number;
};

export const updateProduct = async (updateProductVars: UpdateProductVars) => {
  return await API.put("/UpdateProduct", updateProductVars);
};

type AddCategoryVars = {
  name: string;
  userId: number;
};

export const getCategories = async (): Promise<CategoryType[]> => {
  const response = await API.get(`/GetAllCategoriesForUserId?id=${1}`);
  const categories = response.data.map((cat: any) => ({ ...cat, positions: [] }));

  return categories;
};

export const addCategory = async (addCategoryVars: AddCategoryVars) => {
  return await API.post("/AddCategory", addCategoryVars);
};

export const deleteCategory = async (id: number) => {
  return await API.delete(`/DeleteCategoryById?id=${id}`);
};

type UpdateCategoryVars = {
  name: string;
  userId: number;
};

export const updateCategory = async (updateCategoryVars: UpdateCategoryVars) => {
  return await API.put("/UpdateCategory", updateCategoryVars);
};
