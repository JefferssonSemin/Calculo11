 public class CalculoCodigoTrocaPF
    {
         public int GeraCodigoAutorizacaoPf( string certificado = "0000000000211634080447267",string valor = "89900")
          {
           
            int[] intPesos1 = { 2,3,4,5,6,7,8,9,0,1,2,3,4,5,6,7,8,9,0,1,2,3,4,5,6,7,8,9,0,1,2,3,4};
            int[] intPesos2 = { 5,4,3,2,1,0,9,8,7,6,5,4,3,2,1,0,9,8,7,6,5,4,3,2,1,0,9,8,7,6,5,4,3,2};

                string strText = certificado.PadLeft(25, '0') + valor.PadLeft(8, '0');

                if (strText.Length > 33)

                    throw new Exception("Número não suportado pela função!");

                int intSoma1 = 0;
                int intIdx1 = 0;
            int intSoma2 = 0;
            int intIdx2 = 0;

            for (int intPos = strText.Length - 1; intPos >= 0; intPos--)

                {
                intSoma1 += Convert.ToInt32(strText[intPos].ToString()) * intPesos1[intIdx1];
                intIdx1++;
                }

                int intResto = (intSoma1 * 10) % 11;
                var strText2 =   strText+ intResto;

                for (int intPos = strText2.Length - 1; intPos >= 0; intPos--)
                {
                intSoma2 += Convert.ToInt32(strText2[intPos].ToString()) * intPesos2[intIdx2];
                intIdx2++;
                }

                int intFinal = (intSoma2 * 10) % 11;
                int intDigito = intFinal;

                if (intDigito >= 10)
                    intDigito = 0;

                return intDigito + int.Parse(valor, NumberStyles.HexNumber);
            }
    }