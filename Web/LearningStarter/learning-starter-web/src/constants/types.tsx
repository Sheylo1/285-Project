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
  accountBalance: number;
  id: number;
  firstName: string;
  lastName: string;
  userName: string;
  dateOfBirth: Date;
  email: string;
  phoneNumber: number;
};

export type BetCategoryGetDto = {
  id: number;
  name: string;
};

export type BetCategoryCreateDto = {
  name: string;
};

export type BetCategoryUpdateDto = {
  name: string;
};

export type BetCreateDto ={
  name: string;
  betCategoryId: number;
  createdDate: string;
  closedDate: string | undefined;
  commentId: number | undefined;
  betDisputeCall: boolean;
  escrowSystemId: number | undefined;
};

export type BetGetDto = {
  id: number;
  name: string;
  betCategoryId: number;
  createdDate: string;
  closedDate: string;
  commentId: number;
  betDisputeCall: boolean;
  escrowSystemId: number;
};

export type BetUpdateDto = {
  name: string;
  betDisputeCall: boolean;
}

export type BetDeleteDto = {
  id: number;
  accountBalance: number;
  email: string;
  phoneNumber: string;
  dateOfBirth: Date;
};

export type CommentGetDto = {
  id: number;
  createdAt: string;
  commentText: string;
  createdByUserId: number;
  createdByUserName: string;
};

export type CommentCreateDto = {
  id: number;
  createdAt: string;
  commentText: string;
};

export type CommentUpdateDto = {
  id: number;
  createdAt: string;
  commentText: string;
};

export type CommentDeleteDto = {

  id: number;
  createdAt: string;
  commentText: string;
};
export type EmployeeCreateDto = {

  userId: number;
  positionId: number;
  salary: number;
  employed: Boolean;
};
export type EmployeeUpdateDto = {

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
};

export type UserUpdateDto = {
  firstName: string;
  lastName: string;
  userName: string;
  accountBalance: number;
  email: string;
  phoneNumber: string;
  dateOfBirth: Date;
};
