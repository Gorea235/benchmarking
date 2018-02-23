import math
import time
import sys

tmp = 0


def to_bench(iter):
    global tmp
    for i in range(iter):
        tmp += math.sqrt(i)


def benchmark(func, iter, numBenchmarks):
    mean_time = 0
    total_time = 0
    for i in range(numBenchmarks):
        # start benchmark
        start = time.time()

        # call function to benchmark
        func(iter)

        # end benchmark
        end = time.time()

        diff = (end - start)
        total_time += diff

        if mean_time:
            mean_time = (mean_time + diff) / 2
        else:
            mean_time = diff
    return mean_time


if __name__ == "__main__":
    iter = int(sys.argv[1])
    benches = int(sys.argv[2])
    bench = benchmark(to_bench, iter, benches)
    print("{} benchmarks with {} iterations each: avg {}s".format(
        benches, iter, bench))
