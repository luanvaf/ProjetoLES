using Domain.Dtos.Helps;
using System.Text.Json.Serialization;

namespace Domain.Dtos.Inputs
{
    /// <summary>
    /// Dto responsável por receber os dados de criação do usuário
    /// </summary>
    public class DtoCreateUserInput
    {
        /// <summary>
        /// Nome completo
        /// </summary>
        public string CompleteName { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Crm { get; set; }
        /// <summary>
        /// Senha
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Confirmação de senha
        /// </summary>
        public string ConfirmPassword { get; set; }
        [JsonIgnore]
        public DtoUserRoleType Role { get;  protected set; }

    }
}
