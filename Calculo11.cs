 public class CalculoCodigoTrocaPF
    {
        public static int GeraCodigoAutorizacaoPf(string certificado, string valor)
        {
            int[] intPesos1 = { 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] intPesos2 = { 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 9, 8, 7, 6, 5, 4, 3, 2 };

            string strText = certificado.PadLeft(25, '0') + valor.PadLeft(8, '0');

            if (strText.Length > 33)

                throw new Exception("Número não suportado pela função!");

            int intSoma = 0;
            int intIdx = 0;

            for (int intPos = strText.Length - 1; intPos >= 0; intPos--)

            {
                intSoma += Convert.ToInt32(strText[intPos].ToString()) * intPesos1[intIdx];
                intIdx++;
            }

            int intResto = (intSoma * 10) % 11;
            var strText2 = strText + intSoma;

            for (int intPos = strText.Length - 1; intPos >= 0; intPos--)
            {
                intSoma += Convert.ToInt32(strText2[intPos].ToString()) * intPesos2[intIdx];
                intIdx++;
            }

            int intFinal = (intSoma * 10) % 11;
            int intDigito = intFinal;

            if (intDigito >= 10)
                intDigito = 0;

            return intDigito + int.Parse(valor, NumberStyles.HexNumber);
        }
    }