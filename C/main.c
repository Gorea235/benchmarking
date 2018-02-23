#include <stdio.h>
#include <stdlib.h>
#include <math.h>
#include "benchmarking/benchmark.h"

double tmp;

void toBench(int iters)
{
    tmp = 0;
    for (long i = 0; i < iters; i++)
        tmp += sqrt(i);
}

int main(int argc, char *argv[])
{
    if (argc != 3)
    {
        printf("benchmark requires int argument\n");
        return 1;
    }
    int iters = atoi(argv[1]);
    int benches = atoi(argv[2]);
    double bench = benchmark(toBench, iters, benches);
    printf("%d benchmarks with %d iterations each: avg %fs\n", benches, iters, bench);
    return 0;
}
