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
};

export type CommentGetDto = {
  id: number;
  createdAt: string;
  commentText: string;
  createdByUserId: number;
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

