type EnvironmentName = "dev";

type Environment = {
  backendUrl: string;
};

const environment = "dev";

const config: Record<EnvironmentName, Environment> = {
  dev: {
    backendUrl: "http://localhost:8000",
  },
};

export default config[environment];
