import { useContext, useEffect, useState } from "react";
import {
  closestCenter,
  DndContext,
  DragEndEvent,
  DragOverlay,
  DragStartEvent,
  KeyboardSensor,
  PointerSensor,
  UniqueIdentifier,
  useSensor,
  useSensors,
} from "@dnd-kit/core";
import { arrayMove, SortableContext, sortableKeyboardCoordinates, verticalListSortingStrategy } from "@dnd-kit/sortable";
import SortableItem, { CategoryType } from "./components/sortableItem";
import { Box, Grid, Stack, Typography } from "@mui/material";
import AddCategoryForm from "./components/forms/addCategoryForm";
import { ModalBoxContext } from "components/modalBox/providers/modalBox";
import Button from "components/button";
import AddProductForm from "./components/forms/addProductForm";
import { useQuery } from "react-query";
import { getCategories, getProducts } from "api/actions/settings.actions";
import { groupBy } from "lodash";
import { DisplayLoadingContext } from "components/loadingProgress/providers/loading-provider";

const SettingsProducts = () => {
  const { actionModalBox } = useContext(ModalBoxContext);
  const { displayLoader } = useContext(DisplayLoadingContext);
  const sensors = useSensors(
    useSensor(PointerSensor),
    useSensor(KeyboardSensor, {
      coordinateGetter: sortableKeyboardCoordinates,
    }),
  );

  const [items, setItems] = useState<CategoryType[]>([]);
  const [activeId, setActiveId] = useState<UniqueIdentifier | null>(null);

  const { data: categories, isLoading: loadingCategories } = useQuery(["categories"], getCategories);
  const { data: productsData, isLoading: loadingProducts } = useQuery(["products"], getProducts);

  const products = groupBy(productsData, (item) => item.categoryId);
  const categoriesGrouped = categories?.map((item) => {
    if (products[item.id]) {
      return { ...item, positions: products[item.id] };
    } else {
      return item;
    }
  });

  useEffect(() => {
    displayLoader(loadingProducts);
  });

  useEffect(() => {
    if (!(loadingCategories && loadingProducts) && categoriesGrouped) {
      setItems(categoriesGrouped);
    }
  }, [loadingCategories, loadingProducts]);

  const activeItem = activeId ? items?.find(({ id }) => id === activeId) || null : null;

  function handleDragStart({ active }: DragStartEvent) {
    setActiveId(active.id);
  }

  function handleDragEnd({ active, over }: DragEndEvent) {
    if (over && active.id !== over.id) {
      setItems((items) => {
        const oldIndex = items.findIndex(({ id }) => id === active.id);
        const newIndex = items.findIndex(({ id }) => id === over.id);
        return arrayMove(items, oldIndex, newIndex);
      });
    }
    setActiveId(null);
  }

  let content;
  if (loadingCategories && loadingProducts) {
    content = <></>;
  } else {
    content = (
      <Box sx={{ "& li": { listStyleType: "none" } }}>
        <DndContext sensors={sensors} collisionDetection={closestCenter} onDragStart={handleDragStart} onDragEnd={handleDragEnd}>
          <SortableContext items={items.map((i) => i.id)} strategy={verticalListSortingStrategy}>
            <Stack spacing={2}>
              {items.map((item) => (
                <SortableItem id={item.id} item={item} key={item.id} />
              ))}
            </Stack>
          </SortableContext>
          <DragOverlay>{activeId ? <SortableItem id={activeId} item={activeItem} /> : null}</DragOverlay>
        </DndContext>
      </Box>
    );
  }

  return (
    <Box sx={{ maxWidth: 1048, mx: "auto", mt: 8 }}>
      <Grid container justifyContent="space-between" alignItems="center" sx={{ mb: 4 }}>
        <Typography variant="h4" fontWeight="600" fontSize={24}>
          Kategorie i produkty
        </Typography>
        <Box>
          <Button
            sx={{ mr: 1 }}
            variant="contained"
            onClick={() => {
              actionModalBox(true, <AddProductForm />, "Nowy produkt");
            }}
          >
            Dodaj produkt
          </Button>
          <Button
            variant="contained"
            onClick={() => {
              actionModalBox(true, <AddCategoryForm />, "Nowa kategoria");
            }}
          >
            Dodaj kategorie
          </Button>
        </Box>
      </Grid>
      {content}
    </Box>
  );
};

export default SettingsProducts;
