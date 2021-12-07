import { Injectable } from "@angular/core";
import { BaseModel } from "../models/base.model";
import { CreateUserModel, UserModel } from "../models/user.model";
import { ApiClient } from "./api.client";

@Injectable()
export class UserService {

    constructor(private readonly api: ApiClient) { }

    public async list(): Promise<UserModel[]> {
        return this.api.get("users").then(data => BaseModel.convertArray(UserModel, data));
    }

    public async create(model: CreateUserModel): Promise<UserModel> {
        return this.api.post("users", model).then(data => new UserModel(data));
    }

    public async get(id: string): Promise<UserModel> {
        return this.api.get(`users/${id}`).then(data => new UserModel(data));
    }

    public async getByUsername(username: string): Promise<UserModel> {
        return this.api.get(`users/${username}`).then(data => new UserModel(data));
    }

    public async update(model: UserModel): Promise<UserModel> {
        return this.api.put(`users/${model.id}`, model).then(data => new UserModel(data));
    }

    public async delete(id: string): Promise<void> {
        return this.api.delete(`users/${id}`);
    }

}
