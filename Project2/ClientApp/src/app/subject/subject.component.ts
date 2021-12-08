import { Component, OnDestroy, OnInit, TemplateRef, ViewChild } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { Subscription } from "rxjs";
import { AppState } from "../app.state";
import { CheckpointModel } from "../models/checkpoint.model";
import { SubjectModel } from "../models/subject.model";
import { UserModel, UserType } from "../models/user.model";
import { SubjectService } from "../services/subject.service";
import { UserService } from "../services/user.service";

@Component({
    selector: "subject",
    templateUrl: "./subject.component.html",
    styleUrls: ["./subject.component.scss"]
})
export class SubjectComponent implements OnInit, OnDestroy {

    @ViewChild("readOnlyTemplate", { static: false }) readOnlyTemplate: TemplateRef<unknown> | undefined;
    @ViewChild("editTemplate", { static: false }) editTemplate: TemplateRef<unknown> | undefined;

    public subject: SubjectModel;
    public subjectId: string;
    public editedCheckpoint: CheckpointModel;
    public isNewRecord = false;

    public users: UserModel[];
    public selectedUserId = "";
    public currentUser: UserModel;
    public setMode = false;

    private readonly subscriptions: Subscription[] = [];

    constructor(
        public readonly appState: AppState,
        private readonly activatedRoute: ActivatedRoute,
        private readonly subjectService: SubjectService,
        private readonly userService: UserService,
        private readonly router: Router
    ) { }

    public ngOnInit(): void {
        if (!this.appState.initComplete) {
            this.router.navigate(["/"]);
        }

        const routeSubscription = this.activatedRoute.params.subscribe(async routeParams => {
            this.subjectId = routeParams.subjectId;
            await this.loadSubject();
            await this.loadStudents();
        });
        this.subscriptions.push(routeSubscription);
    }

    private async loadStudents(): Promise<void> {
        const allStudents = (await this.userService.list()).filter(x => x.userType === UserType.Student);
        this.users = allStudents.filter(x => x.subjectIds?.includes(this.subject.id));
    }

    public ngOnDestroy(): void {
        this.subscriptions.forEach(x => x.unsubscribe());
    }

    public createCheckpoint(): void {
        if (!this.subject.checkpoints) {
            this.subject.checkpoints = [];
        }

        const checkpoint = new CheckpointModel();
        checkpoint.name = "";
        checkpoint.maxPoint = 0;

        this.subject.checkpoints.push(checkpoint);
        this.isNewRecord = true;
    }

    public loadTemplate(checkpoint: CheckpointModel): TemplateRef<unknown> | undefined {
        if (this.editedCheckpoint && this.editedCheckpoint.id === checkpoint.id) {
            return this.editTemplate;
        }

        return this.readOnlyTemplate;
    }

    public editCheckpoint(checkpoint: CheckpointModel): void {
        this.editedCheckpoint = checkpoint;
    }

    public async deleteCheckpoint(checkpoint: CheckpointModel): Promise<void> {
        this.subject.checkpoints = this.subject.checkpoints.filter(x => x.id !== checkpoint.id);
        await this.subjectService.update(this.subject);
        await this.loadSubject();
    }

    public async saveCheckpoint(): Promise<void> {
        await this.subjectService.update(this.subject);
        await this.loadSubject();
        this.isNewRecord = false;
        this.editedCheckpoint = null;
    }

    public cancel() {
        if (this.isNewRecord) {
            this.subject.checkpoints.pop();
            this.isNewRecord = false;
        }

        this.editedCheckpoint = null;
    }

    public setPoints(): void {
        this.setMode = true;
    }

    public onUserSelected(id: string): void {
        this.currentUser = this.users.find(x => x.id === id);

        if (!this.currentUser.checkpointPoints) {
            this.currentUser.checkpointPoints = new Map<string, number>();
            this.subject.checkpoints.forEach(x => {
                this.currentUser.checkpointPoints[x.id] = 0;
            });
        }
    }

    public async savePoints(): Promise<void> {
        await this.userService.update(this.currentUser);
        this.currentUser = null;
        this.setMode = false;
    }

    private async loadSubject(): Promise<void> {
        this.subject = await this.subjectService.get(this.subjectId);
    }

}
