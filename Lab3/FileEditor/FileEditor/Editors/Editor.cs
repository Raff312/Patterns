using FileEditor.Documents;

namespace FileEditor.Editors {
    public abstract class Editor {
        public abstract Document CreateDocument();
        public abstract void OpenDocument();
    }

    public enum ActionType {
        Create,
        Open
    }
}