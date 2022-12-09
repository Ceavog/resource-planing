import { Box, Skeleton, Stack, Tab, Tabs, Typography } from "@mui/material";
import { getCategories, getProducts } from "api/actions/settings.actions";
import { useState } from "react";
import { useQuery } from "react-query";
import ArrowRightIcon from "@mui/icons-material/ArrowRight";
import ProductRow from "./productRow";
import { a11yProps } from "../../common/utils";
import TabPanel from "./tabPanel";
import { groupBy } from "lodash";

const productsList = [1, 2, 3, 4, 5, 6, 7, 8, 9];
const placeholderCategiesData = [
  {
    id: 1,
    name: "Tabby",
  },
  {
    id: 2,
    name: "Melba",
  },
  {
    id: 3,
    name: "Emmet",
  },
  {
    id: 4,
    name: "Cherise",
  },
  {
    id: 5,
    name: "Clare",
  },
];

const Order = () => {
  const [value, setValue] = useState(0);
  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setValue(newValue);
  };

  const { data: categories, isLoading: loadingCategories } = useQuery(["categories"], getCategories);
  const { data: productsData, isLoading: loadingProducts } = useQuery(["products"], getProducts);

  const loading = loadingCategories || loadingProducts;

  const products = groupBy(productsData, (item) => item.categoryId);
  const categoriesGrouped = categories?.map((item) => {
    if (products[item.id]) {
      return { ...item, positions: products[item.id] };
    } else {
      return item;
    }
  });

  return (
    <Box
      sx={{
        maxWidth: 1280,
        mx: "auto",
        my: 8,
        borderRadius: "8px",
        boxShadow: "rgba(0, 0, 0, 0.05) 0px 6px 24px 0px, rgba(0, 0, 0, 0.08) 0px 0px 0px 1px",
      }}
    >
      <Box sx={{ flexGrow: 1, display: "flex" }}>
        <Tabs
          orientation="vertical"
          variant="scrollable"
          value={value}
          onChange={handleChange}
          sx={{ borderRight: 1, borderColor: "divider", flex: "240px 0" }}
        >
          {(loading ? placeholderCategiesData : categoriesGrouped)?.map((category, index) => (
            <Tab
              key={index}
              sx={{ textTransform: "none", justifyContent: "space-between" }}
              icon={<ArrowRightIcon color="action" />}
              iconPosition="end"
              label={loading ? <Skeleton animation="wave" variant="text" width={65} height={17} /> : category.name}
              {...a11yProps(index)}
            />
          ))}
        </Tabs>
        {categoriesGrouped?.map((category, index) => (
          <TabPanel value={value} index={index} key={index}>
            <Box width="100%">
              <Typography variant="h6" component="p" sx={{ mb: 5 }}>
                {category.name}
              </Typography>
              <Stack spacing={2}>
                {category.positions.map((product) => (
                  <ProductRow product={product} key={product.id} loading={loading} />
                ))}
              </Stack>
            </Box>
          </TabPanel>
        ))}
      </Box>
    </Box>
  );
};

export default Order;
