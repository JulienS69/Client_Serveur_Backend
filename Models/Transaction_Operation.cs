namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Transaction_Operation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdTransaction { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateTransaction { get; set; }

        [StringLength(50)]
        public string Montant { get; set; }

        public int IdCompte { get; set; }

        public virtual Compte Compte { get; set; }
    }
}
