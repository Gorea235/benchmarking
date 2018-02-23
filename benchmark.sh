#! /bin/bash
# ======= runs complete benchmarking =======

# iteration/benchmark times
ITER=1000000000
BENCHES=10

# build items
(cd ./C && make)
(cd ./CS && make release)

# benchmark
echo "======================= Performing Benchmarks ======================="
echo "----------- benchmarking C -----------"
./C/bin/benchmark $ITER $BENCHES
echo "----------- benchmarking C# -----------"
dotnet run -c Release --project ./CS $ITER $BENCHES
