# MarsRover
Cambium Interview Test

The solution uses .NET 5. Please [download](https://dotnet.microsoft.com/download) if missing. 

### Instruction: 

1. Run UnitTests in MarsRoverTest Project
    - For any issues please raise an [issue](https://github.com/alexandruhapco/MarsRover/issues).
2. Set MarsRoverBlazor.Server as a StartUp application.
3. Run it.
4. Input Rover directives into the field with a placeholder "1 2 N|LMLMLMLMM".
5. Press "Start Mission" to execute a single line command.   
    1. Incorrect directives won't do anything, any response to the UI is missing
    2. Incorrect means something that doesn't match to this pattern **"^[0-9]+ [0-9]+ [NESW][|][LRM]+$"**
    3. Also a proper Validator should be added to the Controller 
    4. On the right side of the UI in a textarea you'll see a translated list of directives.
6. Enjoy amazing animation of a Rover moving and spinning!
7. It's time to try a CSV file. The expected format of CSV one command per line: 
    - 1 2 N|LMLMLMLMM
    - 3 3 E|MMRMMRMRRM
8. Choose a file with the "Choose file" button.
9. Upload a file with the "Upload csv File" button.
10. In the textarea below it line by line will appear all directives from the file and they will be executed one by one.
11. Well Done! Mars colonization is coming!

