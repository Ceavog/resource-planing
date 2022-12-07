import { useState } from "react";
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
import { Box, Stack } from "@mui/material";
import { ProductType } from "../sortableItem";
import ProductSortableItem from "./productSortableItem";

type Props = {
  products: ProductType[];
};

const ProductItems: React.FC<Props> = ({ products }) => {
  const [activeId, setActiveId] = useState<UniqueIdentifier | null>(null);
  const [items, setItems] = useState(products);

  const sensors = useSensors(
    useSensor(PointerSensor),
    useSensor(KeyboardSensor, {
      coordinateGetter: sortableKeyboardCoordinates,
    }),
  );

  const activeItem = activeId ? items.find(({ id }) => id === activeId) || null : null;

  return (
    <Box>
      <DndContext sensors={sensors} collisionDetection={closestCenter} onDragStart={handleDragStart} onDragEnd={handleDragEnd}>
        <SortableContext items={items.map((i) => i.id)} strategy={verticalListSortingStrategy}>
          <Stack spacing={2}>
            {items.map((item) => (
              <ProductSortableItem id={item.id} item={item} key={item.id} />
            ))}
          </Stack>
        </SortableContext>
        <DragOverlay>{activeId ? <ProductSortableItem id={activeId} item={activeItem} /> : null}</DragOverlay>
      </DndContext>
    </Box>
  );

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
};

export default ProductItems;
