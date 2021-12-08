/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, OnInit, TemplateRef, ViewChild } from "@angular/core";
import { Router } from "@angular/router";
import { AppState } from "../app.state";
import { SubjectModel } from "../models/subject.model";
import { CreateUserModel, UserModel, UserType } from "../models/user.model";
import { SubjectService } from "../services/subject.service";
import { UserService } from "../services/user.service";

@Component({
    selector: "users",
    templateUrl: "./users.component.html",
    styleUrls: ["./users.component.scss"]
})
export class UsersComponent implements OnInit {

    @ViewChild("readOnlyTemplate", {static: false}) readOnlyTemplate: TemplateRef<unknown> | undefined;
    @ViewChild("editTemplate", {static: false}) editTemplate: TemplateRef<unknown> | undefined;

    public userTypes: "teachers" | "students" = "teachers";

    public subjectsMap = new Map<string, string>();
    public subjects: SubjectModel[];
    public users: UserModel[];
    public editedUser: UserModel;
    public isNewRecord = false;

    constructor(
        public readonly appState: AppState,
        private readonly router: Router,
        private readonly userService: UserService,
        private readonly subjectService: SubjectService
    ) { }

    public async ngOnInit(): Promise<void> {
        if (!this.appState.initComplete) {
            this.router.navigate(["/"]);
        }

        await this.updateUsers();
        await this.loadSubjects();
    }

    private async loadSubjects(): Promise<void> {
        this.subjects = await this.subjectService.list();
        this.subjects.forEach(x => {
            this.subjectsMap[x.id] = x.name;
        });
    }

    public async onUserTypesChange(type: "teachers" | "students"): Promise<void> {
        this.isNewRecord = false;
        this.editedUser = null;
        this.userTypes = type;
        await this.updateUsers();
    }

    public createUser(type: number): void {
        const user = new UserModel();
        user.firstName = "";
        user.secondName = "";
        user.middleName = "";
        user.username = "";
        user.password = "";
        user.userType = type;
        this.users.push(user);
        this.isNewRecord = true;
    }

    public loadTemplate(user: UserModel): TemplateRef<unknown> | undefined {
        if (this.editedUser && this.editedUser.id === user.id) {
            return this.editTemplate;
        }

        return this.readOnlyTemplate;
    }

    public editUser(user: UserModel): void {
        this.editedUser = new UserModel(user);
    }

    public async deleteUser(user: UserModel): Promise<void> {
        await this.userService.delete(user.id);
        await this.updateUsers();
    }

    public async saveUser(): Promise<void> {
        if (this.isNewRecord) {
            const createUser = new CreateUserModel();
            createUser.firstName = this.editedUser.firstName;
            createUser.secondName = this.editedUser.secondName;
            createUser.middleName = this.editedUser.firstName;
            createUser.username = this.editedUser.username;
            createUser.password = this.editedUser.password;
            createUser.userType = this.userTypes === "students" ? UserType.Student : UserType.Teacher;
            await this.userService.create(createUser);
            await this.updateUsers();
            this.isNewRecord = false;
        } else {
            await this.userService.update(this.editedUser);
            await this.updateUsers();
        }

        this.editedUser = null;
    }

    public cancel() {
        if (this.isNewRecord) {
            this.users.pop();
            this.isNewRecord = false;
        }

        this.editedUser = null;
    }

    public onChange(event: any, id: string): void {
        const checked = !!event.currentTarget.checked;
        if (checked) {
            if (!this.editedUser.subjectIds) {
                this.editedUser.subjectIds = [];
            }

            if (!this.editedUser.subjectIds.includes(id)) {
                this.editedUser.subjectIds.push(id);
            }
        } else {
            if (this.editedUser.subjectIds.includes(id)) {
                this.editedUser.subjectIds = this.editedUser.subjectIds.filter(x => x !== id);
            }
        }
    }

    private async updateUsers(): Promise<void> {
        if (this.userTypes === "teachers") {
            await this.loadTeachers();
        } else {
            await this.loadStudents();
        }
    }

    private async loadStudents(): Promise<void> {
        this.users = (await this.userService.list()).filter(x => x.userType === UserType.Student);
    }

    private async loadTeachers(): Promise<void> {
        this.users = (await this.userService.list()).filter(x => x.userType === UserType.Teacher);
    }

}
