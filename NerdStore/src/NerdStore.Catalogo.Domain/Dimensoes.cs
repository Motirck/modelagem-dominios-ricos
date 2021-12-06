using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    /// <summary>
    /// Dimensoes é um objeto de valor, ou seja não será persistido no banco.
    /// Será utilizado para agregação de valor para alguma entidade (como a Produto)
    /// e a Produto sim é persistida no banco de dados.
    /// </summary>
    public class Dimensoes
    {
        public decimal Altura { get; private set; }
        public decimal Largura { get; private set; }
        public decimal Profundidade { get; private set; }

        public Dimensoes(decimal altura, decimal largura, decimal profundidade)
        {
            AssertionConcern.ValidarSeMenorQue(altura, 1, "O campo Altura não pode ser menor ou igual a 0");
            AssertionConcern.ValidarSeMenorQue(largura, 1, "O campo Largura não pode ser menor ou igual a 0");
            AssertionConcern.ValidarSeMenorQue(profundidade, 1, "O campo Profundidade não pode ser menor ou igual a 0");

            Altura = altura;
            Largura = largura;
            Profundidade = profundidade;
        }

        public string DescricaoFormatada()
        {
            return $"LxAxP: {Largura} x {Altura} x {Profundidade}";
        }

        public override string ToString()
        {
            return DescricaoFormatada();
        }
    }
}
