namespace task_26 {
    internal enum enum_size { XS, S, M, L, XL }
    internal class card {
        string title;
        string content;
        int person_id;
        enum_size size;
        internal string property_title { get => title; set => title = value; }
        internal string property_content { get => content; set => content = value; }
        internal int property_person_id { get => person_id; set => person_id = value; }
        internal enum_size property_size { get => size; set => size = value; } 
        internal card(string title, string content, int person_id, enum_size size) {
            this.title = title;
            this.content = content;
            this.person_id = person_id;
            this.size = size;
        }
    }
}