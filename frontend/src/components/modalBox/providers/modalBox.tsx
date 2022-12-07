import React, { useState } from "react";

type ModalBoxType = {
  open: boolean;
  body: React.ReactNode;
  title: string;
  size: number | null;
  actionModalBox(openValue: boolean, body: React.ReactNode, title: string, size?: number): void;
};

const initialData: ModalBoxType = {
  open: false,
  body: null,
  title: "",
  size: null,
  actionModalBox: () => null,
};

export const ModalBoxContext = React.createContext<ModalBoxType>(initialData);

type Props = {
  children: React.ReactNode;
};

export const ModalBoxProvider: React.FC<Props> = (props) => {
  const [open, setOpen] = useState<boolean>(initialData.open);
  const [body, setBody] = useState<React.ReactNode>(null);
  const [title, setTitle] = useState<string>("");
  const [size, setSize] = useState<number | null>(null);

  const actionModalBox = (openValue: boolean, body: React.ReactNode, title: string, size: number) => {
    setOpen(openValue);
    setBody(body);
    setTitle(title);
    setSize(size);
  };

  const values: ModalBoxType = {
    open,
    body,
    title,
    size,
    actionModalBox,
  };

  return <ModalBoxContext.Provider value={values}>{props.children}</ModalBoxContext.Provider>;
};
