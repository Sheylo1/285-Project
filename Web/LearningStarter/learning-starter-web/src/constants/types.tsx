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
};