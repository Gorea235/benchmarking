#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include "benchmarking/benchmark.h"

double tmp;

void toBench()
{
    tmp = 0;
    for (long i = 0; i < 1000000000; i++)
        tmp += sqrt(i);
}

int main(int argc, char *argv[])
{
    if (argc != 2)
    {
        printf("benchmark requires int argument\n");
        return 1;
    }
    int num = atoi(argv[1]);
    double bench = benchmark(toBench, NULL, 0, num);
    return 0;
}
