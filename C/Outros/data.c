#include <stdio.h>
#include <time.h>

#define DATA 11



data_atual(char data[])
{
	time_t rawtime;
	struct tm *local;

	time(&rawtime);
	local = localtime(&rawtime);
	strftime(data, DATA, "%d/%m/%Y", local);
}

int main()
{
	char data[DATA];

	data_atual(data);
	printf("%s\n", data);
	
	getch();
	return 0;
}
