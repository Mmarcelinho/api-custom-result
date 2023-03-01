namespace AspNetCore.WebApi.ViewModels.BooksViewModels;

    public class LivroInput
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "No minimo 5 caracteres")]
        public string Titulo { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "No minimo 5 caracteres")]
        public string Categoria { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Valor deve ser igual ou maior a 0")]
        public int Quantidade { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Valor deve ser igual ou maior a 0")]
        public decimal Preco { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "No minimo 5 caracteres")]
        public string Autor { get; set; }
        
    }
