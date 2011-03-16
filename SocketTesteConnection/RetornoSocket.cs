namespace SocketTesteConnection
{
    public class RetornoSocket
    {
        private readonly bool existeErro;

        private readonly string resposta;

        public RetornoSocket(string resposta, bool existeErro)
        {
            this.resposta = resposta;
            this.existeErro = existeErro;
        }

        public bool ExisteErro
        {
            get
            {
                return existeErro;
            }
        }

        public string Resposta
        {
            get
            {
                return resposta;
            }
        }

        public string[] RespostaArray
        {
            get
            {
                return resposta.Replace("\r", "").Split('\n');
            }
        }
    }
}