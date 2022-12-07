import React from "react";
import { useSortable } from "@dnd-kit/sortable";
import { CSS } from "@dnd-kit/utilities";
import { UniqueIdentifier } from "@dnd-kit/core";
import ProductItem from "../productItem";
import { ProductType } from "../../sortableItem";

type Props = {
  id: UniqueIdentifier;
  item: ProductType | null;
  // activeId: string | number;
};

// const animateLayoutChanges: AnimateLayoutChanges = ({ isSorting, wasDragging }) => (isSorting || wasDragging ? false : true);

const ProductSortableItem: React.FC<Props> = (props) => {
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
    <ProductItem
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

export default ProductSortableItem;
