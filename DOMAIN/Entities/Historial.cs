namespace DOMAIN.Entities
{
    public class Historial : DatosSeguridad
    {
        public Historial()
        {
        }

        public Historial(Guid id) : base(id)
        {
        }

        public string usuario_soporte { set; get; }
        public string comentario_trabajo_realizado { set; get; }
        public Guid id_Ticket { set; get; }

        public Tikect Tikect { set; get; }

    }
}