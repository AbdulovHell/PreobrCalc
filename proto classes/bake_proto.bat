set var=%CD%
protoc --csharp_out="%var%" FiltersBase.proto
pause