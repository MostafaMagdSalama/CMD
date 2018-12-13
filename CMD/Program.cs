using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine( "Welcome to my CMD Lite program \n If you need a help Just write help");
            //string variable to get input from user 
            string input;
            // assign current directory to c:/User/(username of computer)
            Directory.SetCurrentDirectory(Directory.GetDirectoryRoot("rootdir")+"Users/"+Environment.UserName);
            //default directory
            string d = Directory.GetDirectoryRoot("rootdir") + "Users/" + Environment.UserName;
            //i will use inputstring array to getting input in more one word
            string[] inputstring;
            //infinite while loop 
            
                while (true)
                {
                    //show the current directory
                    Console.Write(Directory.GetCurrentDirectory() + "> ");
                    //get input from user
                    input = Console.ReadLine();
                    inputstring = input.Split(' ');
                //check the input
                if (input == "cd")
                {
                    Directory.SetCurrentDirectory(d);
                }
                else if (input[0] == 'c' && input[1] == 'd')
                {
                    string[] arr = input.Split(' ');
                    Directory.SetCurrentDirectory(Directory.GetCurrentDirectory() + "/" + arr[1]);
                }
                else if (input == "clear")
                {
                    Console.Clear();
                    //write this again to still in program not clear
                    Console.WriteLine("Welcome to my CMD Lite program \n If you need a help Just write help ");
                    //show the current directory
                    Console.Write(Directory.GetCurrentDirectory() + "> ");
                }
                else if (input == "showfiles" || input == "ls")
                {
                    // i not a file name it's a directory i make this (System.IO.Path.GetFileName(i)) to extract file name 
                    string[] arr = Directory.GetFiles(Directory.GetCurrentDirectory());
                    foreach (string i in arr)
                    {
                        Console.WriteLine(System.IO.Path.GetFileName(i));
                    }
                }
                else if (inputstring[0] == "echo")
                {
                    string[] arr = input.Split(' ');
                    foreach (string i in arr)
                    {
                        if (i != "echo")
                        {
                            Console.Write(i + " ");

                        }
                    }
                    //this is equivalent to \n to write at next line 
                    Console.WriteLine();
                }
                else if (inputstring[0] == "search")
                {
                    bool c = false;
                    string[] arr = Directory.GetFiles(Directory.GetCurrentDirectory());

                    foreach (string i in arr)
                    {
                        if (System.IO.Path.GetFileName(i) == inputstring[1])
                        {
                            Console.WriteLine("yes i found it");
                            c = true;
                        }

                    }
                    if (c == false)
                    {
                        Console.WriteLine("Not foud in this directory");
                    }

                }
                else if (inputstring[0] == "shutdown")
                {
                    //to shutdown the computer
                    Process.Start("shutdown", "/s /t 0");
                }
                else if (inputstring[0] == "restart")
                {
                    //to restart the computer
                    System.Diagnostics.Process.Start("shutdown.exe", "-r -t 0");
                }

                else if (inputstring[0] == "osinfo")
                {
                    Console.WriteLine("ServicePack Name : " + System.Environment.OSVersion.ServicePack);
                    Console.WriteLine(" Version : " + System.Environment.OSVersion.Version);
                    Console.WriteLine("ServicePack Name : " + System.Environment.OSVersion.VersionString);
                }
                else if (inputstring[0] == "startproces")
                {
                    Process.Start(inputstring[1]);
                }
                else if (inputstring[0] == "killproces")
                {
                    foreach (Process p in Process.GetProcesses())
                    {
                        if (inputstring[1] == p.ProcessName)
                        {
                            p.Kill();
                        }

                    }
                }
                else if (inputstring[0] == "createfile")
                {
                    FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "/" + inputstring[1], FileMode.Create, FileAccess.Write);
                    if (inputstring.Length > 1)
                    {
                        StreamWriter sw = new StreamWriter(fs);
                        for (int i = 2; i < inputstring.Length; i++)
                        {
                            sw.WriteLine(inputstring[i]);
                        }

                        sw.Flush();

                    }
                    fs.Flush();
                    fs.Close();
                }
                else if (inputstring[0] == "copyfile")
                {
                    System.IO.File.Copy(Directory.GetCurrentDirectory() + "/" + inputstring[1], inputstring[2] + "/" + inputstring[1], true);
                }
                else if (inputstring[0] == "movefile")
                {
                    System.IO.File.Move(Directory.GetCurrentDirectory() + "/" + inputstring[1], inputstring[2] + "/" + inputstring[1]);
                }
                else if (inputstring[0] == "deletefile")
                {
                    System.IO.File.Delete(Directory.GetCurrentDirectory() + "/" + inputstring[1]);
                }
                else if (inputstring[0]=="help")
                {
                    help();

                }



                }
            
          
        }
        public static void help()
        {
            Console.WriteLine("cd folder_name");
            Console.WriteLine("showfiles or ls ");
            Console.WriteLine("echo text (to print a text ) ");
            Console.WriteLine("search file_name");
            Console.WriteLine("Shutdown");
            Console.WriteLine("Restart");
            Console.WriteLine("osifo");
            Console.WriteLine("startproces proces_name");
            Console.WriteLine("killproces proces_name");
            Console.WriteLine("createproces file_name");
            Console.WriteLine("createfile file_name");
            Console.WriteLine("copyfile file_name destination");
            Console.WriteLine("movefile file_name destination");
            Console.WriteLine("deletefile file_name");
        }
       
    }
}
