import { Box, Grid, Icon, Stack, styled, Tab, Tabs, Typography } from "@mui/material";
import { getCategories, getProducts } from "api/actions/settings.actions";
import { useContext, useState } from "react";
import { useQuery } from "react-query";
import ArrowRightIcon from "@mui/icons-material/ArrowRight";
import AddIcon from "@mui/icons-material/Add";
import { ModalBoxContext } from "components/modalBox/providers/modalBox";
import Button from "components/button";
type ItemType = { id: number; name: string; elements: [] };

interface TabPanelProps {
  children?: React.ReactNode;
  index: number;
  value: number;
}

function TabPanel(props: TabPanelProps) {
  const { children, value, index, ...other } = props;

  return (
    <div
      role="tabpanel"
      hidden={value !== index}
      id={`vertical-tabpanel-${index}`}
      aria-labelledby={`vertical-tab-${index}`}
      {...other}
    >
      {value === index && (
        <Box sx={{ p: 3 }}>
          <Typography>{children}</Typography>
        </Box>
      )}
    </div>
  );
}

function a11yProps(index: number) {
  return {
    id: `vertical-tab-${index}`,
    "aria-controls": `vertical-tabpanel-${index}`,
  };
}

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

const Order = () => {
  const [value, setValue] = useState(0);

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setValue(newValue);
  };

  // const [activeCategory, setActiveCategory] = useState<string>("");
  const { actionModalBox } = useContext(ModalBoxContext);
  const { data: categories, isLoading: loadingCategories } = useQuery(["categories"], getCategories, {
    onError: (err) => {
      console.log(err);
    },
  });
  // const { data: productsData, isLoading: loadingProducts } = useQuery(["products"], getProducts, {
  //   onError: (err) => {
  //     console.log(err);
  //   },
  // });

  if (loadingCategories) {
    return <>Loading...</>;
  }

  // const CategoryList = (props: any) => {
  //   return <></>;
  // };

  // const MenuProduct = (props: any) => {
  //   return <></>;
  // };

  return (
    <Box
      sx={{
        maxWidth: 1280,
        mx: "auto",
        my: 16,
        borderRadius: "8px",
        boxShadow: "rgba(0, 0, 0, 0.05) 0px 6px 24px 0px, rgba(0, 0, 0, 0.08) 0px 0px 0px 1px",
      }}
    >
      {/* <Grid container>
        <Grid item xs={3} sx={{ borderRight: "1px solid #e5e7eb" }}>
          <Box sx={{ display: "flex", flexDirection: "column", py: 1 }}>
            {categories?.map((item) => {
              return (
                <Box
                  sx={{
                    display: "flex",
                    justifyContent: "space-between",
                    pl: 4,
                    pr: 2,
                    my: 1,

                    cursor: "pointer",
                  }}
                  key={item.id}
                >
                  <Typography>{item.name}</Typography>
                  <Icon>
                    <ArrowRightIcon color="action" />
                  </Icon>
                </Box>
              );
            })}
          </Box>
        </Grid>
        <Grid item xs={9} sx={{ p: 2 }}>
          <Typography variant="h6" component="p" sx={{ mb: 5 }}>
            Nazwa kategorii
          </Typography>
          <Stack spacing={2}>
            {[1, 2, 3, 4, 5, 6, 7, 8, 9].map((item) => {
              return (
                <Item
                  onClick={() =>
                    actionModalBox(
                      true,
                      <div>
                        <Button variant="contained">Dodaj do zamówienia</Button>
                      </div>,
                      `Produkt ${item}`,
                    )
                  }
                >
                  <Box sx={{ mr: 4 }}>
                    <Typography gutterBottom color="grey.900" fontWeight="500">
                      Produkt {item}
                    </Typography>
                    <Typography gutterBottom variant="body2">
                      It is a long established fact that a reader will be distracted by the readable content of a page when
                      looking at its layout.
                    </Typography>
                    <Typography color="grey.900">24zł</Typography>
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
            })}
          </Stack>
        </Grid>
      </Grid> */}
      <Box sx={{ flexGrow: 1, display: "flex" }}>
        <Tabs
          orientation="vertical"
          variant="scrollable"
          value={value}
          onChange={handleChange}
          sx={{ borderRight: 1, borderColor: "divider" }}
        >
          {categories?.map((category, index) => (
            <Tab
              key={index}
              sx={{ textTransform: "none", justifyContent: "flex-start" }}
              icon={<ArrowRightIcon color="action" />}
              iconPosition="end"
              label={category.name}
              {...a11yProps(index)}
            />
          ))}
        </Tabs>
        {categories?.map((category, index) => (
          <TabPanel value={value} index={index} key={index}>
            <Box width="100%">
              <Typography variant="h6" component="p" sx={{ mb: 5 }}>
                {category.name}
              </Typography>
              <Stack spacing={2}>
                {[1, 2, 3, 4, 5, 6, 7, 8, 9].map((product) => {
                  return (
                    <Item
                      key={product}
                      onClick={() =>
                        actionModalBox(
                          true,
                          <div>
                            <Button variant="contained">Dodaj do zamówienia</Button>
                          </div>,
                          `Produkt ${product}`,
                        )
                      }
                    >
                      <Box sx={{ mr: 4 }}>
                        <Typography gutterBottom color="grey.900" fontWeight="500">
                          Produkt {product}
                        </Typography>
                        <Typography gutterBottom variant="body2">
                          It is a long established fact that a reader will be distracted by the readable content of a page when
                          looking at its layout.
                        </Typography>
                        <Typography color="grey.900">24zł</Typography>
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
                })}
              </Stack>
            </Box>
          </TabPanel>
        ))}
      </Box>
    </Box>
  );
};

export default Order;
