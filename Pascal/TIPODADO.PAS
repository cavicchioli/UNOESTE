
Type
    TpData = record
                 d,m: byte;   {2}
                 a: word;  {2}
             end;
    TpHora = record
                  h,m: byte;   {2}
              end;
    TpPassagem = record
                       NumPassagem: longint;         {4}
                       Origem, Destino: String[20]; {40}
                       Poltrona: byte;               {1}
                       Data: TpData;                 {4}
                       Horario: TpHora;              {2}
                       Distancia: Real;              {6}
                       Fumante: boolean;             {1}
                 end;                               {58}

    {========================================================}

    TYPE
        TpProduto = Record
                       Codigo: Longint;  {Byte}
                       Descricao: String[20];
                       Preco: Real;
                       Baixas: Array[1..6] of byte;
                    end;

    {========================================================}

    TYPE
        TpProduto = Record
                       Codigo: Longint;  {Byte}
                       Descricao: String[20];
                       Preco: Real;
                       Baixas: Array[1..6,1..4] of byte;
                    end;

    {========================================================}