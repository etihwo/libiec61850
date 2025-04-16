/*
 *  Copyright 2013-2025 Michael Zillgith, MZ Automation GmbH
 *
 *  This file is part of MZ Automation IEC 61850 SDK
 * 
 *  All rights reserved.
 */

using ModelGenerator;

namespace modeGenerator_example
{

    /// <summary>
    /// This example shows how to handle a large number of information objects
    /// </summary>
    class MainClass
    {
        public static void Main(string[] args)
        {
            string icdFile = "ICDFiles//simpleIO_ltrk_tests.icd";
            string outputFileName = "static_model";

            string accessPointName = null;
            string iedName = null;
            string modelPrefix = "iedModel";
            bool initializeOnce = false;

            Console.WriteLine("Usage: genmodel <ICD file>  [-ied  <ied-name>] [-ap <access-point-name>] [-out <output-name>] [-modelprefix <model-prefix>]");

            if (args.Count() > 0)
            {
                icdFile = args[0];

                for (int i = 1; i < args.Count(); i++)
                {
                    if (args[i] == ("-ap"))
                    {
                        accessPointName = args[i + 1];

                        Console.WriteLine("Select access point " + accessPointName);

                        i++;
                    }
                    else if (args[i] == ("-ied"))
                    {
                        iedName = args[i + 1];

                        Console.WriteLine("Select IED " + iedName);

                        i++;

                    }
                    else if (args[i] == ("-out"))
                    {
                        outputFileName = args[i + 1];

                        Console.WriteLine("Select Output File " + outputFileName);

                        i++;

                    }
                    else if (args[i] == ("-modelprefix"))
                    {
                        modelPrefix = args[i + 1];

                        Console.WriteLine("Select Model Prefix " + modelPrefix);

                        i++;

                    }
                    else if (args[i] == ("-initializeonce"))
                    {
                        initializeOnce = true;

                        Console.WriteLine("Select Initialize Once");

                    }
                    else
                    {
                        Console.WriteLine("Unknown option: \"" + args[i] + "\"");
                    }
                }
            }

            // Creating file streams
            FileStream cOutStream = new FileStream(outputFileName + ".c", FileMode.Create, FileAccess.Write);
            FileStream hOutStream = new FileStream(outputFileName + ".h", FileMode.Create, FileAccess.Write);

            Console.WriteLine("Select ICD File " + icdFile);

            try
            {
                new StaticModelGenerator(icdFile, icdFile, cOutStream, hOutStream, outputFileName, iedName, accessPointName, modelPrefix, initializeOnce);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.ToString());
            }
        }
    }
}