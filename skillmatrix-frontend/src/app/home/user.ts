import { ISkill } from "../interfaces/ISkill";



export interface IUser {

  firstName: string;
  lastName: string;
  userName: string;
  skills: ISkill[] | undefined;
}

