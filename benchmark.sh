#! /bin/bash
# ======= runs complete benchmarking =======

# iteration/benchmark times
ITER=10000000
BENCHES=1000

# build items
(cd ./C && make)
(cd ./CS && make release)

# benchmark
echo "======================= Performing Benchmarks ======================="
echo "----------- benchmarking C -----------"
./C/bin/benchmark $ITER $BENCHES
echo "----------- benchmarking C# -----------"
dotnet run -c Release --project ./CS $ITER $BENCHES
echo "----------- benchmarking Python 2 -----------"
python2 ./Python/main.py $ITER 100
echo "----------- benchmarking Python 3 -----------"
python3 ./Python/main.py $ITER 100
