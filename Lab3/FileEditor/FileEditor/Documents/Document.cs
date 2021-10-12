namespace FileEditor.Documents {
    public abstract class Document {
        public abstract void New();
        public abstract void Open();
        public abstract void SaveAs();
        public abstract void Clear();
        public abstract void Close();
    }

    public enum DocumentType {
        Txt,
        Png
    }
}