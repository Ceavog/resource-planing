export interface IUser {
  id: string;
  name: string;
  email: string;
  role: string;
}

export interface GenericResponse {
  status: string;
  message: string;
}

export interface ILoginResponse {
  status: string;
  accessToken: string;
}

export interface IUserResponse {
  status: string;
  data: {
    user: IUser;
  };
}

export interface ILoginVars {
  login: string;
  password: string;
}
