import { Guid } from "guid-typescript";

export interface Article {
  Id : string;
  Title: string;
  Summary :string;
  CreatedDateTime : string;
  status?:string;
  mainImageUrl?:string;
}
