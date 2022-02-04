create project structure:
    dotnet new sln -n "VSCodeIntro"  
    dotnet new console -n "IntroUI"
    dotnet new classlib -n "IntroLibrary"
    dotnet sln VSCodeIntro.sln add ./IntroLibrary/IntroLibrary.csproj
    dotnet sln VSCodeIntro.sln add ./IntroUI/IntroUI.csproj
    dotnet add IntroUI/IntroUI.csproj reference IntroLibrary/IntroLibrary.csproj

to add assets:
    cd location
    View > Command Palette >.NET: Generate Assets for Build and Debug

to open vscode for specific location:
    cd location
    Code .