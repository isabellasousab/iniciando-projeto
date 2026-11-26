using System.Text;

namespace cadastro_clientes.Model;

public class Cliente
{
    private int _idCliente;
    private string _nome = "";
    private string _cpf = "";
    private string _email = "";
    private string _telefone = "";
    private string _dataNascimento = "";
    private bool _ativo;

    public Cliente(
        int idCliente,
        string nome,
        string cpf,
        string email,
        string telefone,
        string dataNascimento,
        bool ativo
        )
    {
        IdCliente = idCliente;
        Nome = nome;
        Cpf = cpf;
        Email = email;
        Telefone = telefone;
        DataNascimento = dataNascimento;
        Ativo = ativo;
    }

    public int IdCliente
    {
        get
        {
            return _idCliente;
        }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException(
                    "O identificador deve ser maior que zero."
                );
            }

            _idCliente = value;
        }
    }

    public string Nome
    {
        get
        {
            return _nome;
        }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "O nome do produto é obrigatório."
                );
            }

            _nome = value;
        }
    }

    public string Cpf
    {
        get
        {
            return _cpf;
        }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "O cpf do cliente é obrigatório."
                );
            }

            _cpf = value;
        }
    }

    public string Email
    {
        get
        {
            return _email;
        }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "O email do cliente é obrigatório."
                );
            }

            _email = value;
        }
    }

    public string Telefone
    {
        get
        {
            return _telefone;
        }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(
                    "O telefone do cliente é obrigatório."
                );
            }

            _telefone = value;
        }
    }

    public string DataNascimento
    {
        get
        {
            return _dataNascimento;
        }
        private set
        {
            _dataNascimento = value;
        }
    }

    public bool Ativo
    {
        get
        {
            return _ativo;
        }
        private set
        {
            _ativo = value;
        }
    }
}
