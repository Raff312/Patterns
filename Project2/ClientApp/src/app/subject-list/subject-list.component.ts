import { Component, OnInit, TemplateRef, ViewChild } from "@angular/core";
import { Router } from "@angular/router";
import { AppState } from "../app.state";
import { CreateSubjectModel, SubjectModel } from "../models/subject.model";
import { SubjectService } from "../services/subject.service";

@Component({
    selector: "subject-list",
    templateUrl: "./subject-list.component.html"
})
export class SubjectListComponent implements OnInit {

    @ViewChild("readOnlyTemplate", {static: false}) readOnlyTemplate: TemplateRef<unknown> | undefined;
    @ViewChild("editTemplate", {static: false}) editTemplate: TemplateRef<unknown> | undefined;

    public subjects: SubjectModel[];
    public editedSubject: SubjectModel;
    public isNewRecord = false;

    constructor(
        private readonly appState: AppState,
        private readonly subjectService: SubjectService,
        private readonly router: Router
    ) { }

    public async ngOnInit(): Promise<void> {
        await this.loadSubjects();
    }

    public createSubject(): void {
        const subject = new SubjectModel();
        subject.name = "";
        subject.isExam = false;
        this.subjects.push(subject);
        this.isNewRecord = true;
    }

    public loadTemplate(subject: SubjectModel): TemplateRef<unknown> | undefined {
        if (this.editedSubject && this.editedSubject.id === subject.id) {
            return this.editTemplate;
        }

        return this.readOnlyTemplate;
    }

    public onRowClick(subject: SubjectModel, event: MouseEvent): void {
        let walker = null;
        if (event) {
            walker = event.target as HTMLElement;
        }

        while (walker) {
            if (walker.classList.contains("btn")) return;
            if (walker.classList.contains("form-control")) return;
            if (walker.classList.contains("form-check-input")) return;
            walker = walker.parentElement;
        }

        this.router.navigate(["/subjects", subject.id]);
    }

    public editSubject(subject: SubjectModel): void {
        this.editedSubject = new SubjectModel(subject);
    }

    public async deleteSubject(subject: SubjectModel): Promise<void> {
        await this.subjectService.delete(subject.id);
        await this.loadSubjects();
    }

    public async saveSubject(): Promise<void> {
        if (this.isNewRecord) {
            const createModel = new CreateSubjectModel();
            createModel.name = this.editedSubject.name;
            createModel.isExam = this.editedSubject.isExam;
            await this.subjectService.create(createModel);
            await this.loadSubjects();
            this.isNewRecord = false;
        } else {
            await this.subjectService.update(this.editedSubject);
            await this.loadSubjects();
        }

        this.editedSubject = null;
    }

    public cancel() {
        if (this.isNewRecord) {
            this.subjects.pop();
            this.isNewRecord = false;
        }

        this.editedSubject = null;
    }

    private async loadSubjects(): Promise<void> {
        this.subjects = await this.subjectService.list();
    }

}
