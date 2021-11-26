using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
     /// <summary>
     /// Classe base de toda entidade, ou seja, toda tabela tera esse campos por default
     /// </summary>
    public abstract class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        private DateTime? createdAt;
        public DateTime? CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value is null ? DateTime.UtcNow : value; }
        }
        
        public DateTime? UpdatedAt { get; set; }
    }
}