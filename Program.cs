using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;


    class Program
    {
        static void Main(string[] args)
        {
            /* program reads every line as a "text file"
                 * obtain name of file by using user on console
                 * orginal file exists and can be read
                 * if not, display exception to leave or enter new file name
                 * if already exists... then display exception to either overwrite or
                 * change file name
                 * display to the user the name of the orginial file 
                 * use a list to find the file, use a loop to traverse through the files
                 * if not found or any type of error use try/catch */

            string path = "sample.txt";
            string path2 = "new.txt";
            string fileInput;
            string overrideInput = "yes";
            string data;

            while (File.Exists(path) == File.Exists(path))
            {
                overrideInput = "yes";

                Console.WriteLine("What file do you want to read from?");
                fileInput = Console.ReadLine();
                try
                {
                    if (File.Exists(fileInput) == File.Exists(path))
                    {

                        using (StreamReader sr = new StreamReader("sample.txt")) //connecting to the text file, we want to save all the data
                        {
                            data = sr.ReadToEnd();// to put the info in
                            Console.WriteLine(data);
                            sr.Close();
                        }
                        Console.WriteLine("What is your new file path?");
                        path2 = Console.ReadLine();
                        if (File.Exists(path2))
                        {
                            Console.WriteLine("Would you like to overwrite the file");
                            overrideInput = Console.ReadLine();
                        }
                        if (overrideInput == "yes" || overrideInput == "Yes")
                        {
                            using (StreamWriter sw = new StreamWriter("new.txt")) //deletes the previous file and makes a new file 
                            {
                                sw.Write(data);
                                sw.Close();
                            }
                        }
                    }
                    else
                    {
                        fileErrors(path);
                    }

                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                    fileErrors(path);
                }
                Console.WriteLine("Would you like to continue? (yes/no)");

                Console.WriteLine("This is the name of the file you copied:" + fileInput);
                Console.WriteLine("And this is the file it copied to:" + path2);
                Console.ReadLine();
            }


        }
    public static void fileErrors(string pathway)
    {
        //if there isnt anything return null
        //if file exists, return what to do
        //if file doesnt exist, abort or reenter             
        pathway = "sample.txt";
        if (!File.Exists(pathway))
        {
            throw new SystemException("This file doesn't exist");
        }
        else if (pathway == null)
        {
            throw new SystemException("There is nothing here");
        }

    }
            

}
     
    
    public class IOException : SystemException
{
    public IOException(string message) : base(message)
    {
        Console.WriteLine("This input is invalid.");
    }
}

