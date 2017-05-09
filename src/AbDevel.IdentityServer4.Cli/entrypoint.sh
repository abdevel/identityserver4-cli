#! /bin/bash
cd /app

if [ ! -f $PWD/vsdbg/vsdbg ]; then
    apt update
    apt install -y zip
    curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l $PWD/vsdbg
fi

dotnet restore AbDevel.IdentityServer4.Cli.csproj

dotnet publish -c Debug -o /is4auth --runtime debian.8-x64

ln -s /is4auth/is4auth /sbin/is4auth

dotnet watch publish -c Debug -o /is4auth --runtime debian.8-x64
