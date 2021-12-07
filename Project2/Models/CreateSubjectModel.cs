using System.ComponentModel.DataAnnotations;

namespace Project2.Models {
    public class CreateSubjectModel {
        public string Name { get; set; } = string.Empty;
        public bool IsExam { get; set; } = false;
    }
}
