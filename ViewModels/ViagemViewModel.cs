using System;
using System.ComponentModel.DataAnnotations;

namespace TheWorld.ViewModels
{
    public class ViagemViewModel
    {
        public int Id { get; set; }

        [Required, StringLength(255, MinimumLength = 3)]
        public string Nome { get; set; }

        public DateTime Criada { get; set; } = DateTime.UtcNow;
    }
}