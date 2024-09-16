using DevFreela.API.Enums;

namespace DevFreela.API.Entities {
    public class Project : BaseEntity
    {
        public Project(string title, string description, string idClient, User client, int idFreelancer, decimal totalCost) : base()
         {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;

            Status = ProjectStatusEnum.Created;
            Comments = [];
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string IdClient { get; private set; }
        public User Client { get; private set; }
        public int IdFreelancer { get; private set; }
        public User Freelancer { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime? StartAt { get; private set; }
        public DateTime? CompleteAt { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
        public List<ProjectComment> Comments { get; private set; }
    }
}
