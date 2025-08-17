# Exhibit A CSV Processor

## Overview
This is a C# console application that processes a CSV file containing song play events.  
It calculates **distinct play counts** and the number of **clients** who generated them, then writes the results to an output CSV file.

## Project Structure
```
exhibitA-csv-processor/
 ├─ input/
 │  └─ exhibitA-input.csv    (tab-delimited)
 ├─ output/
 │  └─ results.csv
 ├─ Program.cs
 ├─ exhibitA-csv-processor.csproj
 ├─ exhibitA-csv-processor.sln
 └─ README.md
```

## Input Format
The input file (`exhibitA-input.csv`) should contain rows in the following format:

```
PLAY_ID,SONG_ID,CLIENT_ID,PLAY_TS
44BB190BC2493964E053CF0A000AB546,6164,1,09/08/2016 09:16:00
44BB190BC24A3964E053CF0A000AB546,544,3,10/08/2016 13:54:00
44BB190BC24B3964E053CF0A000AB546,9648,3,08/08/2016 06:08:00
...
```

- **PLAY_ID**: Unique identifier for each play event  
- **SONG_ID**: Identifier for the song played  
- **CLIENT_ID**: Identifier for the client/user who played the song  
- **PLAY_TS**: Timestamp of the play (DD/MM/YYYY HH:MM:SS format)

## Output Format
The program generates `results.csv` in the `output/` directory, with the format:

```
DISTINCT_PLAY_COUNT,CLIENT_COUNT
281,1
293,1
300,2
305,5
...
```

Where:
- **DISTINCT_PLAY_COUNT** = Number of unique plays  
- **CLIENT_COUNT** = Number of clients who had that distinct play count  

## Requirements
- [.NET 6.0 SDK or higher](https://dotnet.microsoft.com/download)

## How to Run
1. Clone or download this repository.
2. Place `exhibitA-input.csv` inside the `input` folder.
3. Open a terminal in the project directory and build the application:
   ```bash
   dotnet build
   ```
4. Run the application:
   ```bash
   dotnet run
   ```
5. The results will be written to:
   ```
   output/results.csv
   ```

## Example Run
If the input contains:
```
PLAY_ID,SONG_ID,CLIENT_ID,PLAY_TS
44BB190BC2493964E053CF0A000AB546,6164,1,09/08/2016 09:16:00
44BB190BC24A3964E053CF0A000AB546,544,3,10/08/2016 13:54:00
```

The output may look like:
```
DISTINCT_PLAY_COUNT,CLIENT_COUNT
281,1
293,1
```

## Notes
- Ensure the input and output directories exist before running.
- If your input file has a different name, update the path in `Program.cs`.
- The program is designed to handle large datasets efficiently.
