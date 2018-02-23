# C# building

debug: restore
	dotnet build --no-restore -c Debug

release: restore
	dotnet build --no-restore -c Release

restore:
	dotnet restore

clean:
	rm -fR bin/*

.PHONY: clean debug
