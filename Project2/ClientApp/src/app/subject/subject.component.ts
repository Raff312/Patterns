import { Component, OnDestroy, OnInit, TemplateRef, ViewChild } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Subscription } from "rxjs";
import { CheckpointModel } from "../models/checkpoint.model";
import { SubjectModel } from "../models/subject.model";
import { SubjectService } from "../services/subject.service";

@Component({
    selector: "subject",
    templateUrl: "./subject.component.html"
})
export class SubjectComponent implements OnInit, OnDestroy {

    @ViewChild("readOnlyTemplate", {static: false}) readOnlyTemplate: TemplateRef<unknown> | undefined;
    @ViewChild("editTemplate", {static: false}) editTemplate: TemplateRef<unknown> | undefined;

    public subject: SubjectModel;
    public subjectId: string;
    public editedCheckpoint: CheckpointModel;
    public isNewRecord = false;

    private readonly subscriptions: Subscription[] = [];

    constructor(
        private readonly activatedRoute: ActivatedRoute,
        private readonly subjectService: SubjectService
    ) { }

    public ngOnInit(): void {
        const routeSubscription = this.activatedRoute.params.subscribe(routeParams => {
            this.subjectId = routeParams.subjectId;
            this.loadSubject();
        });
        this.subscriptions.push(routeSubscription);
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

    private async loadSubject(): Promise<void> {
        this.subject = await this.subjectService.get(this.subjectId);
    }

}
