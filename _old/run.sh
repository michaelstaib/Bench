#!/bin/sh

rm -rf BenchmarkDotNet.Artifacts
rm -rf bin
rm -rf obj

dotnet run -c release

rm -rf bin
rm -rf obj
