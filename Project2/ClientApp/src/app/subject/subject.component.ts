import { Component } from "@angular/core";
import { SubjectModel } from "../models/subject.model";

@Component({
    selector: "subject",
    templateUrl: "./subject.component.html"
})
export class SubjectComponent {

    public subjects: SubjectModel[];

}
