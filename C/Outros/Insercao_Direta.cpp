void Insercao_Direta(int vetor[tf], int elem,int &tl, int tf)
{
 int PosAux;

  if (TL< TF)
  {   
	vetor[TL]= elem;
	 PosAux = TL-1;
	  while (vetor[PosAux] > elem && PosAux >= 0)
	  {
		Lista[PosAux+1] = Lista[PosAux];
		Lista[PosAux] = Elemento;
		PosAux--;
	  }
   }
   else printf("VETOR CHEIO");
}
