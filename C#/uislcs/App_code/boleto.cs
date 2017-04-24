using System;
using System.Text.RegularExpressions;

/// <summary>
/// ** essa classe deve ser herdada **
/// Armazena funções comuns a todos os boletos como a montagem
/// da linha digitável e calculo de digitos verificadores
/// </summary>
    public partial class BoletoBase {

        protected string _linhadigitavel = "", _codigodebarras = "";

        public string linhadigitavel {
            get { return _linhadigitavel; }
            set { _codigodebarras = value; }
        }
        public string codigodebarras {
            get { return _codigodebarras; }
            set { _codigodebarras = value; }
        }

		/// <summary>
		/// formata valores numericos
		/// </summary>
		/// <param name="numero">12,3</param>
		/// <param name="formato">0000f</param>
		/// <returns>0123</returns>
        protected string formata(string numero, string formato)
        {
            numero = numero.Replace(",", "").Replace(".", "");
            if (Regex.IsMatch(formato, "[0]+f"))
            {
                return Regex.Replace(formato, "[0-9]{" + Convert.ToString(numero.Length) + "}f", numero);
            }
            if (Regex.IsMatch(formato, "f[0]+"))
            {
                return Regex.Replace(formato, "f[0-9]{" + Convert.ToString(numero.Length) + "}", numero);
            }
            else
            {
                return "";
            }
        }

		/// <summary>
		/// calcula o digito verificador do código de barras
		/// </summary>
        protected string dv_cb(string strNumero)
        { //bb
            int mult = 2, res = 0, tot = 0;
            for (int i = strNumero.Length - 1; i >= 0; --i)
            {
                if (mult == 10) { mult = 2; }
                int num = Convert.ToInt32(strNumero.Substring(i, 1)) * mult;
                tot += num;
                mult++;
            }
            res = 11 - (tot % 11);
            if (res == 0 || res == 10 || res == 11) { return "1"; }
            else { return res.ToString(); }
        }

		/// <summary>
		/// calcula digito verificador módulo 10, usado na linha digitável
		/// </summary>
        protected string Calculo_DV10(String strNumero)
        {
            Int32 mult = 2, res = 0, tot = 0;
            for (int i = strNumero.Length - 1; i >= 0; --i)
            {
                int num = Convert.ToInt32(strNumero.Substring(i, 1)) * mult;
                while (num > 9)
                {
                    string st1 = num.ToString();
                    num = Convert.ToInt32(st1.Substring(0, 1)) + Convert.ToInt32(st1.Substring(st1.Length - 1, 1));
                }
                tot += num; mult = mult == 2 ? 1 : 2;
            }
            /*res = DezenaSuperior - tot; ex 50-43=7 || 10-(43%10)=7 || 10-3=7*/
            res = 10 - (tot % 10);
            switch (res)
            {
                case 0: return "0";
                default: return res.ToString();
            }
        }

		/// <summary>
		/// Calcula digito verificador módulo 11
		/// </summary>
        protected string Calculo_DV11_BB(String strNumero)
        {
            int mult = 9, res = 0, tot = 0;
            for (int i = strNumero.Length - 1; i >= 0; --i)
            {//de 9 a 2 da direita para a esquerda, primeiro 9.
                if (mult == 1) { mult = 9; }
                //soma os resultados da multiplicação.
                tot += Convert.ToInt32(strNumero.Substring(i, 1)) * mult;
                mult--;
            }
            //(divisao do total por 11) = resto
            res = tot % 11;
            //verifica as exceções ( 0 -> DV=0    10 -> DV=X (para o BB) e retorna o DV
            switch (res)
            {
                case 0: return "0";
                case 10: return "X";
                default: return res.ToString();
            }
        }

		/// <summary>
		/// monta a linha digitável a partir do codigo de barras do banco
		/// </summary>
		protected string Linha_Digitavel(string bml, string dv_cb, string vencimento, string valor)
		{ //bb
			string res, st1 = bml.Substring(0, 9), st2 = bml.Substring(9, 10), st3 = bml.Substring(19, 10);
			st1 += Calculo_DV10(st1); st2 += Calculo_DV10(st2); st3 += Calculo_DV10(st3);
			res = String.Format("{0} {1} {2} {3} {4}{5}", st1, st2, st3, dv_cb, vencimento, valor);
			res = res.Insert(5, ".").Insert(17, ".").Insert(30, ".");
			return res;
		}
    }

/// <summary>
/// ** Cria código de barras e linha digitavel do banco do brasil **
/// </summary>
public partial class bb : BoletoBase 
{
    string _nossonumero;

    public bb(string convenio, string nossonumero, string agencia, string conta, string carteira, string vencimento, string valor, tipo Conv_NN) {
        _codigodebarras = Monta_CodBarras_BB(convenio, nossonumero, agencia, conta, carteira, vencimento, valor, Conv_NN);
    }
    public enum tipo { cv8_nn9, cv7_nn10, cv6_nn5, cv6_nn17 }
    protected string Monta_CodBarras_BB(string convenio, string nossonumero, string agencia, string conta, string carteira, string vencimento, string valor, tipo Conv_NN)
    {
        string banco = "001", moeda = "9"; valor = formata(valor, "0000000000f"); //10

        DateTime ven = DateTime.Parse(vencimento);
        TimeSpan ts = ven.Subtract(DateTime.Parse("7/10/1997"));
        vencimento = ts.Days.ToString();
        string livre_zeros = "000000"; //Zeros usados quando convenio de 7 e 8 digitos
        string livre = "";
        string linha;
        string dvcb;
        
        switch ((int)Conv_NN)
        {
            case 0: //cv8_nn9
                convenio = formata(convenio, "00000000f");  //8
                nossonumero = formata(nossonumero, "000000000f"); //9
                livre = livre_zeros + convenio + nossonumero + carteira; //6+8+9+2=25
                //montando o nosso numero que aparecerá no boleto
                _nossonumero = convenio + nossonumero + "-" + Calculo_DV11_BB(convenio + nossonumero);
                break;
            case 1: //cv7_nn10
                convenio = formata(convenio, "0000000f"); //7
                nossonumero = formata(nossonumero, "0000000000f"); //10
                livre = livre_zeros + convenio + nossonumero + carteira; //6+7+10+2=25
                //montando o nosso numero que aparecerá no boleto
                _nossonumero = convenio + nossonumero;
                break;
            case 2: //cv6_nn5
                nossonumero = formata(nossonumero, "00000f"); // Nosso número de até 5 dígitos
                livre = convenio + nossonumero + agencia + conta + carteira; //6+5+4+8+2=25
                //montando o nosso numero que aparecerá no boleto
                _nossonumero = convenio + nossonumero + "-" + Calculo_DV11_BB(convenio + nossonumero);
                break;
            case 3: //cv6_nn17
                nossonumero = formata(nossonumero, "00000000000000000f"); // Nosso número de até 17 dígitos
                livre = convenio + nossonumero + "21"; //6+17+2=25
                //montando o nosso numero que aparecerá no boleto
                _nossonumero = nossonumero;
                break;
        }
        linha = banco + moeda + vencimento + valor + livre; //3+1+4+10+25 = 43
        dvcb = dv_cb(linha);
        linha = linha.Insert(4, dvcb); //44

        string BBBML25 = banco + moeda + livre;
        _linhadigitavel= Linha_Digitavel(BBBML25, dvcb, vencimento, valor);
        //BoletoDados bd = new BoletoDados(conta, moeda, valor, vencimento, banco, agencia, conta, nossonumero, "referencia", "instruções", "sacado", "cpf", "endereço", "cidade", "cep", _LinhaDigitavel, _CodigodeBarras);
        return linha;
    }
}

/// <summary>
/// ** Cria código de barras e linha digitavel do bancoob **
/// usado na inicialização (overload) de um objeto que ARMAZENA DADOS e não está em uma generic.list
/// </summary>
/// <example>
///	bancoob bcb = new bancoob(carteira, agencia, modalidade, codigo, nossonumero, parcela, vencimento, valor);
///	_linhadigitavel = bcb.linhadigitavel;
///	_codigodebarras = bcb.codigodebarras;
/// </example>
public partial class bancoob : BoletoBase
{
    string _carteira, _agencia, _modalidade, _cedente, _nossonumero, _numerodaparcela, _vencimento, _valor;
    public bancoob(string carteira, string agencia, string modalidade, string cedente, string nossonumero, string numerodaparcela, string vencimento, string valor)
    {
        _codigodebarras = Monta_CodBarras_SICOOB(carteira, agencia, modalidade, cedente, nossonumero, numerodaparcela, vencimento, valor);
        _carteira = carteira;
        _agencia = agencia;
        _modalidade = modalidade;
        _cedente = cedente;
        _numerodaparcela = numerodaparcela;
        _vencimento = vencimento;
        _valor = valor;
    }
    protected string Monta_CodBarras_SICOOB(string carteira, string agencia, string modalidade, string cedente, string nossonumero, string numerodaparcela, string vencimento, string valor)
    {
        string banco = "756", moeda = "9";
        valor = formata(valor, "0000000000f"); //10
        nossonumero = formata(nossonumero, "00000000f"); //8
        cedente = formata(cedente, "0000000f"); //7

        DateTime ven = DateTime.Parse(vencimento);
        TimeSpan ts = ven.Subtract(DateTime.Parse("7/10/1997"));
        vencimento = ts.Days.ToString();

        string livre = "";
        string codigo;
        string dv;

        livre = carteira + agencia + modalidade + cedente + nossonumero + numerodaparcela; //(1+4)+(2+7+8+3) = 5+20 = 25
		codigo = banco + moeda + vencimento + valor + livre; //3+1+4+10+25 = 43

		dv = dv_cb(codigo);
		codigo = codigo.Insert(4, dv); //44

        string BBBML25 = banco + moeda + livre;
        _linhadigitavel = Linha_Digitavel(BBBML25, dv, vencimento, valor);
        _nossonumero = nossonumero;

		return codigo;
    }
}