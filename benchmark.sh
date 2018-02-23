#! /bin/bash
# ======= runs complete benchmarking =======

# iteration times
ITER=10

# build items
(cd ./C && make)
(cd ./CS && make release)

# benchmark
echo C
./C/benchmark $ITER
echo "C#"
dotnet run -c Release --project ./CS $ITER
