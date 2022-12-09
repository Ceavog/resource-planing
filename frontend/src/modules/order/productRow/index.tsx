import AddIcon from "@mui/icons-material/Add";
import { Box, Icon, Skeleton, styled, Typography } from "@mui/material";
import Button from "components/button";
import { ModalBoxContext } from "components/modalBox/providers/modalBox";
import { useContext } from "react";

type ProductRowProps = {
  product: any;
  loading: boolean;
};

const Item = styled(Box)(({ theme }) => ({
  ...theme.typography.body2,
  padding: theme.spacing(1, 1, 1, 2),
  color: theme.palette.text.secondary,
  cursor: "pointer",
  "&:hover": {
    boxShadow: "rgba(0, 0, 0, 0.05) 0px 6px 24px 0px, rgba(0, 0, 0, 0.08) 0px 0px 0px 1px",
    "& .addIcon": {
      transition: "background-color 200ms linear",
      background: " #E5E7EB",
    },
  },
  borderRadius: "8px",
  position: "relative",
}));

const ProductRow: React.FC<ProductRowProps> = ({ product, loading }) => {
  const { actionModalBox } = useContext(ModalBoxContext);

  return (
    <Item
      onClick={() => {
        !loading &&
          actionModalBox(
            true,
            <div>
              <Button variant="contained">Dodaj do zamówienia</Button>
            </div>,
            product.name,
          );
      }}
    >
      <Box sx={{ mr: 4 }}>
        <Typography gutterBottom color="grey.900" fontWeight="500">
          {loading ? <Skeleton animation="wave" variant="text" width={75} height={24} /> : `${product.name}`}
        </Typography>
        <Typography gutterBottom variant="body2">
          {loading ? <Skeleton animation="wave" variant="text" width={180} height={20} /> : "Cheese, pepperoni, mushrooms"}
        </Typography>
        <Typography color="grey.900">
          {loading ? <Skeleton animation="wave" variant="text" width={30} height={24} /> : "24zł"}
        </Typography>
      </Box>
      <Icon
        className="addIcon"
        sx={{
          position: "absolute",
          right: 0,
          top: 0,
          borderRadius: "0 10px 0 10px",
          width: 32,
          height: 32,
          display: "flex",
          alignItems: "center",
          justifyContent: "center",
        }}
      >
        <AddIcon />
      </Icon>
    </Item>
  );
};

export default ProductRow;
