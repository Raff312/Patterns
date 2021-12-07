import { Component, OnInit } from "@angular/core";
import { SubjectModel } from "../models/subject.model";

@Component({
    selector: "subject",
    templateUrl: "./subject.component.html"
})
export class SubjectComponent implements OnInit {

    public subjects: SubjectModel[];

    public ngOnInit(): void {
        console.log("HEREEEEEEEEEEEEEE");
    }

}
