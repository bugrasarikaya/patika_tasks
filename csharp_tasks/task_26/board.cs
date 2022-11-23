namespace task_26 {
    internal class board {
        Dictionary<int, string> dictionary_people = new Dictionary<int, string> {
                {1,  "person_name_1" },
                {2,  "person_name_2" },
                {3,  "person_name_3" },
                {4,  "person_name_4" },
                {5,  "person_name_5" },
                {6,  "person_name_6" }
        };
        Dictionary<int, string> dictionary_lines = new Dictionary<int, string> {
            {0, "TODO"},
            {1, "IN PROGRESS"},
            {2, "DONE"}
        };
        List<List<card>> lines = new List<List<card>> {
            new List<card>() { // TODO Line
                new card("title_1", "content_1", 1, enum_size.XS),
                new card("title_2", "content_2", 2, enum_size.S)
            },
            new List<card>() { // IN PROGRESS Line
                new card("title_3", "content_3", 3, enum_size.M),
                new card("title_4", "content_4", 4, enum_size.M)
            },
             new List<card>() { // DONE Line
                new card("title_5", "content_5", 5, enum_size.L),
                new card("title_6", "content_6", 6, enum_size.XL)
            }
        };
        internal void add_card(string title, string content, int person_id, enum_size size) {
            lines[1].Add(new card(title, content, person_id, size));
        }
        internal bool check_person(int person_id) {
            return dictionary_people.ContainsKey(person_id);
        }
        internal void delete_card(int[] array_index) {
            lines[array_index[0]].RemoveAt(array_index[1]);
        }
        internal void move_card(int[] old_index, int new_index) {
            lines[new_index].Add(lines[old_index[0]][old_index[1]]);
            lines[old_index[0]].RemoveAt(old_index[1]);
        }
        internal int[]? search_card(string title) {
            int index_0, index_1;
            index_0 = index_1 = -1;
            index_0 = lines.FindIndex(list_card => list_card.Any(card => card.property_title == title));
            if (index_0 >= 0) index_1 = lines[index_0].FindIndex(card => card.property_title == title);
            if (index_0 >= 0 && index_1 >= 0) return new int[] { index_0, index_1 };
            else return null;
        }
        internal int[]? search_card(int person_id) {
            int index_0, index_1;
            index_0 = index_1 = -1;
            index_0 = lines.FindIndex(list_card => list_card.Any(card => card.property_person_id == person_id));
            if (index_0 >= 0) index_1 = lines[index_0].FindIndex(card => card.property_person_id == person_id);
            if (index_0 >= 0 && index_1 >= 0) return new int[] { index_0, index_1 };
            else return null;
        }
        internal void update_card(int[] array_index, string title, string content, enum_size size) {
            lines[array_index[0]][array_index[1]].property_title = title;
            lines[array_index[0]][array_index[1]].property_content = content;
            lines[array_index[0]][array_index[1]].property_size = size;
        }
        internal void list() {
            for (int i = 0; i < 3; i++) {
                Console.WriteLine(dictionary_lines[i] + " Line");
                Console.WriteLine("************************");
                if (lines[i].Count > 0) {
                    foreach (card card in lines[i]) {
                        Console.WriteLine("Başlık       : " + card.property_title);
                        Console.WriteLine("İçerik       : " + card.property_content);
                        Console.WriteLine("Atana Kişi   : " + dictionary_people[card.property_person_id]);
                        Console.WriteLine("Büyüklük     : " + card.property_size);
                        Console.WriteLine("-");
                    }
                } else Console.WriteLine("~ BOŞ ~");
            }
        }
    }
}