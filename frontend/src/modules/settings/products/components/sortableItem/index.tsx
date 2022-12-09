import React from "react";
import { useSortable } from "@dnd-kit/sortable";
import { CSS } from "@dnd-kit/utilities";
import Item from "../item";
import { UniqueIdentifier } from "@dnd-kit/core";

export type ProductType = {
  categoryId: number;
  id: number;
  name: string;
  price: number;
};

export type CategoryType = {
  categoryId: number;
  id: number;
  name: string;
  positions: ProductType[];
};

type Props = {
  id: UniqueIdentifier;
  item: CategoryType | null;
  // activeId: string | number;
};

// const animateLayoutChanges: AnimateLayoutChanges = ({ isSorting, wasDragging }) => (isSorting || wasDragging ? false : true);

const SortableItem: React.FC<Props> = (props) => {
  const {
    attributes,
    //  isDragging,
    //  isSorting,
    listeners,
    setDraggableNodeRef,
    setDroppableNodeRef,
    transform,
    transition,
  } = useSortable({
    id: props.id,
    // animateLayoutChanges
  });

  const style = {
    transform: CSS.Transform.toString(transform),
    transition,
  };

  return (
    <Item
      ref={setDraggableNodeRef}
      wrapperRef={setDroppableNodeRef}
      style={style}
      // ghost={isDragging}
      // disableInteraction={isSorting}
      handleProps={{
        ...attributes,
        ...listeners,
      }}
      {...props}
    />
  );
};

export default SortableItem;
