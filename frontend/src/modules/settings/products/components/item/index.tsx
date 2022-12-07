import {
  alpha,
  Box,
  Collapse,
  Divider,
  Grid,
  IconButton,
  IconButtonProps,
  Menu,
  MenuItem,
  MenuProps,
  Paper,
  styled,
  TextField,
} from "@mui/material";
import { forwardRef, HTMLAttributes } from "react";
import React from "react";
import MoreVertIcon from "@mui/icons-material/MoreVert";
import EditIcon from "@mui/icons-material/Edit";
import FileCopyIcon from "@mui/icons-material/FileCopy";
import DragIndicatorIcon from "@mui/icons-material/DragIndicator";
import DeleteIcon from "@mui/icons-material/Delete";
import { UniqueIdentifier } from "@dnd-kit/core";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import { CategoryType } from "../sortableItem";
import ProductItems from "../productItems";
import { deleteCategory } from "api/actions/settings.actions";
import { useMutation } from "react-query";

const PaperElement = styled(Paper)(({ theme }) => ({
  padding: theme.spacing(1),
}));

export interface Props extends Omit<HTMLAttributes<HTMLLIElement>, "id"> {
  // activeId: string | number;
  id: UniqueIdentifier;
  item: CategoryType | null;
  handleProps?: any;
  wrapperRef?(node: HTMLLIElement): void;
  // disableInteraction?: boolean;
  // ghost?: boolean;
}

export const StyledMenu = styled((props: MenuProps) => (
  <Menu
    elevation={0}
    anchorOrigin={{
      vertical: "bottom",
      horizontal: "right",
    }}
    transformOrigin={{
      vertical: "top",
      horizontal: "right",
    }}
    {...props}
  />
))(({ theme }) => ({
  "& .MuiPaper-root": {
    borderRadius: 6,
    marginTop: theme.spacing(1),
    minWidth: 180,
    color: theme.palette.mode === "light" ? "rgb(55, 65, 81)" : theme.palette.grey[300],
    boxShadow:
      "rgb(255, 255, 255) 0px 0px 0px 0px, rgba(0, 0, 0, 0.05) 0px 0px 0px 1px, rgba(0, 0, 0, 0.1) 0px 10px 15px -3px, rgba(0, 0, 0, 0.05) 0px 4px 6px -2px",
    "& .MuiMenu-list": {
      padding: "4px 0",
    },
    "& .MuiMenuItem-root": {
      "& .MuiSvgIcon-root": {
        fontSize: 18,
        color: theme.palette.text.secondary,
        marginRight: theme.spacing(1.5),
      },
      "&:active": {
        backgroundColor: alpha(theme.palette.primary.main, theme.palette.action.selectedOpacity),
      },
    },
  },
}));

interface ExpandMoreProps extends IconButtonProps {
  expand: boolean;
}

const ExpandMore = styled((props: ExpandMoreProps) => {
  const { expand, ...other } = props;
  return <IconButton {...other} />;
})(({ theme, expand }) => ({
  transform: !expand ? "rotate(0deg)" : "rotate(180deg)",
  marginLeft: "auto",
  transition: theme.transitions.create("transform", {
    duration: theme.transitions.duration.shortest,
  }),
}));

const Item = forwardRef<HTMLDivElement, Props>(({ id, item, style, wrapperRef, handleProps, ...props }, ref) => {
  const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
  const open = Boolean(anchorEl);

  const [expanded, setExpanded] = React.useState(false);

  const handleClick = (event: React.MouseEvent<HTMLElement>) => {
    setAnchorEl(event.currentTarget);
  };
  const handleClose = () => {
    setAnchorEl(null);
  };

  const handleExpandClick = () => {
    setExpanded(!expanded);
  };

  const { mutate: removeCategory } = useMutation(deleteCategory, {
    onSuccess: () => {
      alert("Udało sie usunąć kategorie");
    },
    onError: (err: any) => {
      alert(err);
    },
  });

  return (
    <li ref={wrapperRef} {...props}>
      <div ref={ref} style={style}>
        <Grid container component={PaperElement}>
          <Grid item xs={2}>
            <IconButton {...handleProps} sx={{ px: 3 }} disableRipple>
              <DragIndicatorIcon />
            </IconButton>
            <ExpandMore
              disabled={!(item?.positions && item?.positions.length > 0)}
              expand={expanded}
              onClick={handleExpandClick}
              aria-expanded={expanded}
              aria-label="show more"
            >
              <ExpandMoreIcon />
            </ExpandMore>
          </Grid>
          <Grid item xs={9}>
            <Box sx={{ mx: 3 }}>
              <TextField fullWidth id="name" defaultValue={item?.name || ""} size="small" disabled={true} />
            </Box>
          </Grid>
          <Grid item xs={1}>
            <IconButton onClick={handleClick}>
              <MoreVertIcon />
            </IconButton>
            <StyledMenu
              id="demo-customized-menu"
              MenuListProps={{
                "aria-labelledby": "demo-customized-button",
              }}
              anchorEl={anchorEl}
              open={open}
              onClose={handleClose}
            >
              <MenuItem
                onClick={() => {
                  handleClose();
                }}
                disableRipple
              >
                <EditIcon />
                Edit
              </MenuItem>
              <MenuItem onClick={handleClose} disableRipple>
                <FileCopyIcon />
                Duplicate
              </MenuItem>
              <Divider sx={{ my: 0.5 }} />
              <MenuItem
                onClick={() => {
                  item && removeCategory(item.id);
                  handleClose();
                }}
                disableRipple
              >
                <DeleteIcon />
                Remove
              </MenuItem>
            </StyledMenu>
          </Grid>
        </Grid>
        <Collapse in={expanded} timeout="auto" unmountOnExit>
          {item?.positions && item?.positions.length > 0 ? <ProductItems products={item?.positions} /> : null}
        </Collapse>
      </div>
    </li>
  );
});

export default Item;
