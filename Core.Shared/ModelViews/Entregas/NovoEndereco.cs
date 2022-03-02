namespace Core.Shared.ModelViews
{
    public class NovoEndereco
    {
        /// <exemple>49000000</exemple>
        public int CEP { get; set; }

        /// <exemple>RS</exemple>
        public string Estado { get; set; }
        
        /// <exemple>Caxias do Sul</exemple>
        public string Cidade { get; set; }

        /// <exemple>Rua Sinimbu</exemple>
        public string Logradouro { get; set; }

        /// <exemple>555</exemple>
        public string Numero { get; set; }

        /// <exemple>Apto. 101</exemple>
        public string Complemento { get; set; }
    }
}