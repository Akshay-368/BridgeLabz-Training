using System;


//  CUSTOM EXCEPTION CLASS
//  Requirement: RobotSafetyException must inherit from Exception
//  and display the message when thrown/caught

public class RobotSafetyException : Exception
{
    public RobotSafetyException(string message) : base(message)
    {
        // The message is automatically carried by base Exception
    }
}

//  MAIN AUDITOR CLASS
//  Contains the required method CalculateHazardRisk

public class RobotHazardAuditor
{
    /// <summary>
    /// Calculates the hazard risk score for a factory robot.
    /// Throws RobotSafetyException if any input is invalid.
    /// </summary>
    /// <param name="armPrecision">Precision of robot arm (must be 0.0 to 1.0)</param>
    /// <param name="workerDensity">Number of nearby workers (must be 1 to 20)</param>
    /// <param name="machineryState">State of machinery (must be "Worn", "Faulty", or "Critical")</param>
    /// <returns>Hazard risk score as double</returns>
    public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
    {
        // Validation 1: armPrecision must be between 0.0 and 1.0
        if (armPrecision < 0.0 || armPrecision > 1.0)
        {
            throw new RobotSafetyException("Error: Arm precision must be 0.0-1.0");
        }

        // Validation 2: workerDensity must be between 1 and 20
        if (workerDensity < 1 || workerDensity > 20)
        {
            throw new RobotSafetyException("Error: Worker density must be 1-20");
        }

        // Validation 3: machineryState must be one of the allowed values (case-sensitive)
        double machineRiskFactor;
        if (machineryState == "Worn")
        {
            machineRiskFactor = 1.3;
        }
        else if (machineryState == "Faulty")
        {
            machineRiskFactor = 2.0;
        }
        else if (machineryState == "Critical")
        {
            machineRiskFactor = 3.0;
        }
        else
        {
            throw new RobotSafetyException("Error: Unsupported machinery state");
        }

        // Formula:
        // Hazard Risk = ((1.0 - armPrecision) * 15.0) + (workerDensity * machineRiskFactor)
        double riskScore = ((1.0 - armPrecision) * 15.0) + (workerDensity * machineRiskFactor);

        return riskScore;
    }
}


//  USER INTERFACE CLASS - contains Main method

public class UserInterface
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Factory Robot Hazard Analyzer");


        RobotHazardAuditor auditor = new RobotHazardAuditor();

        try
        {
            // Step 1: Get arm precision
            Console.Write("Enter Arm Precision (0.0 - 1.0): ");
            double armPrecision = double.Parse(Console.ReadLine().Trim());

            // Step 2: Get worker density
            Console.Write("Enter Worker Density (1 - 20): ");
            int workerDensity = int.Parse(Console.ReadLine().Trim());

            // Step 3: Get machinery state
            Console.Write("Enter Machinery State (Worn/Faulty/Critical): ");
            string machineryState = Console.ReadLine().Trim();

            // Step 4: Calculate risk
            double riskScore = auditor.CalculateHazardRisk(armPrecision, workerDensity, machineryState);

            // Step 5: Display result
            Console.WriteLine($"\nRobot Hazard Risk Score: {riskScore}");
        }
        catch (RobotSafetyException ex)
        {
            // Requirement: Catch and display the exception message
            Console.WriteLine(ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input format. Please enter valid numbers.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
