using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IPL_Censorship_Analyzer
{
    class Program
    {

        //  Main Entry Point

        static void Main(string[] args)
        {
            Console.WriteLine("IPL and Censorship Analyzer");


            //  Process JSON input
            Console.WriteLine("Processing JSON input...");
            string jsonInputPath = "ipl_matches.json";
            CreateDummyJsonFile(jsonInputPath);
            string censoredJson = ProcessJsonFile(jsonInputPath);
            string censoredJsonPath = "censored_ipl_matches.json";
            File.WriteAllText(censoredJsonPath, censoredJson);
            Console.WriteLine($"Censored JSON saved to: {censoredJsonPath}\n");

            //  Process CSV input
            Console.WriteLine("Processing CSV input...");
            string csvInputPath = "ipl_matches.csv";
            CreateDummyCsvFile(csvInputPath);
            string censoredCsv = ProcessCsvFile(csvInputPath);
            string censoredCsvPath = "censored_ipl_matches.csv";
            File.WriteAllText(censoredCsvPath, censoredCsv);
            Console.WriteLine($"Censored CSV saved to: {censoredCsvPath}\n");

            Console.WriteLine("Processing complete. Press any key to exit...");
            Console.ReadKey();
        }


        //  Masking Logic - used by both JSON and CSV processors

        static string MaskTeamName(string teamName)
        {
            if (string.IsNullOrWhiteSpace(teamName))
                return teamName;

            string[] parts = teamName.Split(' ');
            if (parts.Length <= 1)
                return teamName;

            // Replace the last word with ***
            parts[parts.Length - 1] = "***";
            return string.Join(" ", parts);
        }

        static string RedactPlayerName(string name)
        {
            return "REDACTED";
        }

        //  JSON Processing

        static string ProcessJsonFile(string inputPath)
        {
            string json = File.ReadAllText(inputPath);
            JArray matches = JArray.Parse(json);

            foreach (JObject match in matches)
            {
                // Mask team names
                string team1 = (string)match["team1"];
                string team2 = (string)match["team2"];

                match["team1"] = MaskTeamName(team1);
                match["team2"] = MaskTeamName(team2);

                // Mask winner
                string winner = (string)match["winner"];
                match["winner"] = MaskTeamName(winner);

                // Redact player of the match
                match["player_of_match"] = RedactPlayerName((string)match["player_of_match"]);

                // Mask keys in score object
                JObject score = (JObject)match["score"];
                if (score != null)
                {
                    JObject newScore = new JObject();
                    foreach (JProperty prop in score.Properties())
                    {
                        string newKey = MaskTeamName(prop.Name);
                        newScore[newKey] = prop.Value;
                    }
                    match["score"] = newScore;
                }
            }

            return matches.ToString(Formatting.Indented);
        }

        //  CSV Processing

        static string ProcessCsvFile(string inputPath)
        {
            string[] lines = File.ReadAllLines(inputPath);
            StringBuilder result = new StringBuilder();

            // Write header as-is
            result.AppendLine(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] columns = lines[i].Split(',');

                if (columns.Length < 7) continue; // skip invalid rows

                // Columns:
                // 0: match_id
                // 1: team1
                // 2: team2
                // 3: score_team1
                // 4: score_team2
                // 5: winner
                // 6: player_of_match

                columns[1] = MaskTeamName(columns[1]);          // team1
                columns[2] = MaskTeamName(columns[2]);          // team2
                columns[5] = MaskTeamName(columns[5]);          // winner
                columns[6] = RedactPlayerName(columns[6]);      // player_of_match

                result.AppendLine(string.Join(",", columns));
            }

            return result.ToString();
        }


        //  Create Dummy JSON File

        static void CreateDummyJsonFile(string path)
        {
            var data = new[]
            {
                new
                {
                    match_id = 101,
                    team1 = "Mumbai Indians",
                    team2 = "Chennai Super Kings",
                    score = new Dictionary<string, int>
                    {
                        { "Mumbai Indians", 178 },
                        { "Chennai Super Kings", 182 }
                    },
                    winner = "Chennai Super Kings",
                    player_of_match = "MS Dhoni"
                },
                new
                {
                    match_id = 102,
                    team1 = "Royal Challengers Bangalore",
                    team2 = "Delhi Capitals",
                    score = new Dictionary<string, int>
                    {
                        { "Royal Challengers Bangalore", 200 },
                        { "Delhi Capitals", 190 }
                    },
                    winner = "Royal Challengers Bangalore",
                    player_of_match = "Virat Kohli"
                }
            };

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(path, json);
            Console.WriteLine("Dummy JSON file created: " + path);
        }


        //  Create Dummy CSV File

        static void CreateDummyCsvFile(string path)
        {
            string[] lines = new[]
            {
                "match_id,team1,team2,score_team1,score_team2,winner,player_of_match",
                "101,Mumbai Indians,Chennai Super Kings,178,182,Chennai Super Kings,MS Dhoni",
                "102,Royal Challengers Bangalore,Delhi Capitals,200,190,Royal Challengers Bangalore,Virat Kohli"
            };

            File.WriteAllLines(path, lines);
            Console.WriteLine("Dummy CSV file created: " + path);
        }
    }
}
