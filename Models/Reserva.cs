namespace DesafioProjetoHospedagem.Models
{
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (hospedes == null)
            {
                throw new ArgumentNullException(nameof(hospedes), "A lista de hóspedes não pode ser nula.");
            }

            if (hospedes.Any(hospede => hospede == null))
            {
                throw new ArgumentException("A lista de hóspedes não pode conter elementos nulos.", nameof(hospedes));
            }

            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new InvalidOperationException("Não há vagas suficientes na suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = Suite.ValorDiaria * DiasReservados;

            if (DiasReservados >= 10)
            {
                valor -= (valor * 10 / 100);
            }

            return valor;
        }
    }
}