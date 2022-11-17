//This type uses a generic (<T>).  For more information on generics see: https://www.typescriptlang.org/docs/handbook/2/generics.html
//You probably wont need this for the scope of this class :)
export type ApiResponse<T> = {
  data: T;
  errors: Error[];
  hasErrors: boolean;
};

export type Error = {
  property: string;
  message: string;
};

export type AnyObject = {
  [index: string]: any;
};

export type UserDto = {
  id: number;
  firstName: string;
  lastName: string;
  userName: string;
  accountBalance: number;
  email: string;
  phoneNumber: string;
  dateOfBirth: Date;
  socialId: number;
};
export type EmployeeCreateDto = {
  userId: number;
  positionId: number;
  salary: number;
  employed: Boolean;
};
export type EmployeeUpdateDto = {
  // id: number;
  userId: number;
  positionId:number;
  salary: number;
  employed: Boolean;
};
export type EmployeeGetDto = {
  id: number;
  userId: number;
  positionId: number;
  salary: number;
  employed: Boolean;
};

export type UserCreateDto = {
  firstName: string;
  lastName: string;
  userName: string;
  accountBalance: number;
  email: string;
  phoneNumber: string;
  dateOfBirth: Date | undefined;
  socialId: number;
};
export type UserUpdateDto = {
  firstName: string;
  lastName: string;
  userName: string;
  accountBalance: number;
  email: string;
  phoneNumber: string;
  dateOfBirth: Date;
  socialId: number;
};
