Program Arquivo_Agenda;

Uses NewDelay, Crt;

Type
    Str10 = String[10];
    Str30 = String[30];
    TpRegistro = Record
                       Nome, Endereco: Str30;
                       DtNasc: Str10;
                       Sexo: Char;
                       Ativo: Boolean;
                       QtFilhos: Integer;
                 end;
    TpArquivo = File of TpRegistro;


Procedure VerificaArquivo(var Arq:TpArquivo);
begin
    {$I-}
    Reset(Arq);
    {$I+}
    If (IOResult<>0)
    then ReWrite(Arq);

    Close(Arq);
end;


Procedure Menu;
VAR Arquivo: TpArquivo;
    Opcao: char;
BEGIN
      Assign(Arquivo,'C:\Temp\Dados.dad');
      VerificaArquivo(Arquivo);

      Repeat
         ClrScr;
         Writeln('# # #   M E N U   # # #');
         Writeln('[1] - InclusÆo');
         Writeln('[2] - Relat¢rio');
         Writeln('[3] - Consulta pelo Nome Completo');
         Writeln('[4] - Altera‡Æo');
         Writeln('[5] - ExclusÆo L¢gica');
         Writeln('[6] - ExclusÆo F¡sica');
         Writeln('[7] - Ordena Arquivo');
         Writeln('[8] - Consulta pelo Nome Incompleto');
         Writeln('[9] - Aniversariantes do Dia');
         Writeln('[S] - Sair');
         Write('Op‡Æo ==> ');

         Opcao:=Readkey;

         Case Opcao of
           '1':;
           '2':;
           '3':;
           '4':;
           '5':;
           '6':;
           '7':;
           '8':;
           '9':;
         End;  {Case}

      Until (UpCase(Opcao)='S');
END;


{Programa Principal}
BEGIN
    MENU;
END.
