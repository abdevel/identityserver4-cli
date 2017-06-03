#! /bin/bash

echo 'Pusblishing IS4 CLI OSX...'
pushd $PWD
cd $PWD/src/AbDevel.IdentityServer4.Cli
dotnet restore && dotnet publish -c Release -o ./publish/macos --runtime osx.10.12-x64
popd
echo 'Pusblished IS4 CLI OSX!'

echo 'Pusblishing IS4 CLI Windows...'
pushd $PWD
cd $PWD/src/AbDevel.IdentityServer4.Cli
dotnet restore && dotnet publish -c Release -o ./publish/win10 --runtime win10-x64
popd
echo 'Pusblished IS4 CLI Windows!'

echo 'Pusblishing IS4 CLI Linux(Debian 8)...'
pushd $PWD
cd $PWD/src/AbDevel.IdentityServer4.Cli
dotnet restore && dotnet publish -c Release -o ./publish/debian --runtime debian.8-x64
popd
echo 'Pusblished IS4 CLI Linux(Debian 8)!'
