using System.Windows.Forms;

namespace FactoryMethod {
    public abstract class App {
        public abstract Document CreateDocument();
        public abstract void OpenDocument();
    }

    public class TxtApplication : App {
        private readonly Form _parentForm;
        
        public TxtApplication(Form parentForm) {
            _parentForm = parentForm;
        }

        public override Document CreateDocument() {
            var document = new TxtDocument(_parentForm);
            document.New();
            return document;
        }

        public override void OpenDocument() {
            var document = new TxtDocument(_parentForm);
            document.Open();
        }
    }

    public class PngApplication : App {
        private readonly Form _parentForm;

        public PngApplication(Form parentForm) {
            _parentForm = parentForm;
        }

        public override Document CreateDocument() {
            var document = new PngDocument(_parentForm);
            document.New();
            return document;
        }

        public override void OpenDocument() {
            var document = new PngDocument(_parentForm);
            document.Open();
        }
    }

    public enum ActionType {
        Create,
        Open
    }
}