import { Component, OnInit } from "@angular/core";
import { SubjectModel } from "../models/subject.model";
import { SubjectService } from "../services/subject.service";

@Component({
    selector: "subject-list",
    templateUrl: "./subject-list.component.html"
})
export class SubjectListComponent implements OnInit {

    public subjects: SubjectModel[];

    constructor(private readonly subjectService: SubjectService) { }

    public async ngOnInit(): Promise<void> {
        this.subjects = await this.subjectService.list();
    }

}
