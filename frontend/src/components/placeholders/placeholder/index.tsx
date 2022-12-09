import { Box } from "@mui/material";
import { ISx } from "config/theme";

type Props = {
  image?: React.ReactNode;
  message?: React.ReactNode;
};

const classes: ISx = {
  root: {
    display: "flex",
    justifyContent: "center",
    alignItems: "center",
    padding: 5,
    width: "100%",
    height: "100%",

    "&$inline": {
      px: 2,
    },
  },
  content: {
    display: "flex",
    alignItems: "center",
    flexDirection: "column",

    "&$inline": {
      flexDirection: "row",
    },
  },
  image: {
    lineHeight: 1,
  },
  message: {
    marginTop: 1,
    ml: 1,
    // "& > *": {
    //   ...typography.h1,
    // },

    "&$inline": {
      marginTop: 0,
      marginLeft: 1,
      //   "& > *": { ...typography.h5 },
    },
    "&$centered": {
      textAlign: "center",
    },
  },
};

const Placeholder: React.FC<Props> = ({ image, message }) => {
  return (
    <Box sx={classes.root}>
      <Box sx={classes.content}>
        {image && <Box sx={classes.image}>{image}</Box>}
        {message && <Box sx={classes.message}>{message}</Box>}
      </Box>
    </Box>
  );
};

export default Placeholder;
