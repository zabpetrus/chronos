using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Chronos.Domain.Entities._Base.Interface;
using Chronos.Domain.Entities._Base.Main;
using Microsoft.AspNetCore.Identity;

[Table("Usuarios")]
public class Usuario : IdentityUser<long>, IEntity<IdentityUser<long>, Entity>
{
    [Required]
    [MaxLength(100)]
    public string Nome { get; set; } = String.Empty;

    [Required]
    [MaxLength(255)]
    private string _sal;
    public string Sal
    {
        get => _sal;
        private set => _sal = value;
    }

    [Required]
    [MaxLength(255)]
    private string _senhaHash;
    public string SenhaHash
    {
        get
        {
            if (string.IsNullOrEmpty(_sal))
            {
                throw new InvalidOperationException("Sal não está definido.");
            }
            return _senhaHash;
        }
        private set => _senhaHash = value;
    }

    [Required]
    [MaxLength(512)]
    public string Token { get; set; }

    [Required]
    [MaxLength(512)]
    public string RefreshToken { get; set; } = String.Empty;

    public ICollection<string> Perfis { get; private set; } = new List<string>();

  
    // Define a senha e gera o hash
    public void DefinirSenha(string senha)
    {
        if (string.IsNullOrEmpty(_sal))
        {
            GerarSal();
        }
        SenhaHash = GerarHash(senha, _sal);
    }

    // Adiciona um perfil ao usuário
    public void AdicionarPerfil(string perfil)
    {
        if (!Perfis.Contains(perfil))
        {
            Perfis.Add(perfil);
        }
    }

    // Remove um perfil do usuário
    public void RemoverPerfil(string perfil)
    {
        if (Perfis.Contains(perfil))
        {
            Perfis.Remove(perfil);
        }
    }

    // Método para gerar o hash
    private string GerarHash(string senha, string sal)
    {
        using (var hashAlgorithm = SHA256.Create())
        {
            var senhaComSal = senha + sal;
            var senhaBytes = Encoding.UTF8.GetBytes(senhaComSal);
            var hashBytes = hashAlgorithm.ComputeHash(senhaBytes);
            return Convert.ToBase64String(hashBytes);
        }
    }

    // Método para gerar um novo Sal
    private void GerarSal()
    {
        using (var rng = RandomNumberGenerator.Create())
        {
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            Sal = Convert.ToBase64String(saltBytes);
        }
    }

    // Método para gerar e atribuir um token
    public void GerarToken(string novoToken)
    {
        Token = novoToken;
    }

    // Método para gerar e atribuir um refresh token
    public void GerarRefreshToken(string novoRefreshToken)
    {
        RefreshToken = novoRefreshToken;
    }
}
