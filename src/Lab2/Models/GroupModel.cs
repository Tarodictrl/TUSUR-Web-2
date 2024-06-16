namespace Lab2.Models
{
    public class GroupModel
    {
        public List<Group> Groups { get; set; } = new List<Group>();
        public Student NewStudent { get; set; } = new Student();
        public bool ShowGroups { get; set; } = false;
        public Group CurrentGroup { get; set; } = new Group();
        public string Message { get; set; } = "";

        public GroupModel(List<Group> groups)
        {
            Groups = groups;
        }

        public GroupModel()
        {
        }
    }
}
