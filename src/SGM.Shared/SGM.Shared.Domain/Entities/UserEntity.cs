using SGM.Shared.Domain.Entities.Enums;

namespace SGM.Shared.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public string CPF { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Role AcessLevel { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}    