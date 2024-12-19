import { User } from './User';

export type UserForm = User & {
  ConfirmPassword: string;
  IsCheckedAgreement: boolean;
};
