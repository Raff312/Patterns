import { Injectable } from "@angular/core";
import { BaseModel } from "../models/base.model";
import { SubjectModel } from "../models/subject.model";
import { ApiClient } from "./api.client";

@Injectable()
export class SubjectService {

    constructor(private readonly api: ApiClient) { }

    public async list(): Promise<SubjectModel[]> {
        return this.api.get("subjects").then(data => BaseModel.convertArray(SubjectModel, data));
    }

    public async getSubject(id: string): Promise<SubjectModel> {
        return this.api.get(`subjects/${id}`).then(data => new SubjectModel(data));
    }

}
