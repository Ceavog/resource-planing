import React, { useState } from "react";

type LoadingComponentType = {
  open: boolean;
  displayLoader(value: boolean): void;
};

const initialData: LoadingComponentType = {
  open: false,
  displayLoader: () => null,
};

export const DisplayLoadingContext = React.createContext<LoadingComponentType>(initialData);

type Props = {
  children: React.ReactNode;
};

export const DisplayLoadingProvider: React.FC<Props> = (props) => {
  const [open, setOpen] = useState<boolean>(false);

  const displayLoader = (value: boolean) => {
    setOpen(value);
  };

  const values: LoadingComponentType = {
    open,
    displayLoader,
  };

  return <DisplayLoadingContext.Provider value={values}>{props.children}</DisplayLoadingContext.Provider>;
};
