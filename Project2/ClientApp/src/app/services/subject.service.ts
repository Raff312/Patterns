import { Injectable } from "@angular/core";
import { BaseModel } from "../models/base.model";
import { CreateSubjectModel, SubjectModel } from "../models/subject.model";
import { ApiClient } from "./api.client";

@Injectable()
export class SubjectService {

    constructor(private readonly api: ApiClient) { }

    public async list(): Promise<SubjectModel[]> {
        return this.api.get("subjects").then(data => BaseModel.convertArray(SubjectModel, data));
    }

    public async create(model: CreateSubjectModel): Promise<SubjectModel> {
        return this.api.post("subjects", model).then(data => new SubjectModel(data));
    }

    public async get(id: string): Promise<SubjectModel> {
        return this.api.get(`subjects/${id}`).then(data => new SubjectModel(data));
    }

    public async update(model: SubjectModel): Promise<SubjectModel> {
        return this.api.put(`subjects/${model.id}`, model).then(data => new SubjectModel(data));
    }

    public async delete(id: string): Promise<void> {
        return this.api.delete(`subjects/${id}`);
    }

}
