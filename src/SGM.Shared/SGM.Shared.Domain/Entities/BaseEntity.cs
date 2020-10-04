using System;

namespace SGM.Shared.Domain.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        private DateTime? _createAt;
        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { _createAt = (value != null ? value : DateTime.UtcNow); }
        }

        public DateTime? UpdateAt { get; set; }
    }
}