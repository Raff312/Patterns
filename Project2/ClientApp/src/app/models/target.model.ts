import { BaseModel } from "./base.model";

export class TargetModel extends BaseModel {

    public date: Date;
    public name: string;
    public maxPoint: number;
    public currentPoint: number;
    public theme: string;

    constructor(data?: ITargetModel) {
        super();
        if (data) {
            this.mapFromJson(data);
        }
    }

}

export interface ITargetModel {
    date: Date;
    name: string;
    maxPoint: number;
    currentPoint: number;
    theme: string;
}
