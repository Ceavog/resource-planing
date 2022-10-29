const parseJwtPart = (jwtPart: string) => JSON.parse(atob(jwtPart));

export const parseJwt = (token: string) => {
  const [header, payload] = token.split(".");
  return {
    header: parseJwtPart(header),
    payload: parseJwtPart(payload),
  };
};
