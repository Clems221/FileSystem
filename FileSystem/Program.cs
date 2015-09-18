using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class Program
    {
        static void Main(string[] args)
        {

            string commande;
            File enCour = new Directory(" C: ", true);


            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("[" + enCour.Name + "]");
                Console.ResetColor();

                string saisie = Console.ReadLine();
                commande = getCommand(saisie);
                string arg = getArgument(saisie);
                string argBis = getArgumentBis(saisie);



                try
                {

                    Directory current = (Directory)enCour;

                    if (commande == "create" && saisie != null)
                    {
                        bool estOK = current.createNewFile(arg);

                        if (estOK)
                        { Console.WriteLine("Le fichier est créé"); }
                        else
                        { Console.WriteLine("Erreur! Le fichier n'a pas été créé (Vérifiez vos permissions)"); }

                    }


                    else if (commande == "mkdir" && arg != null && saisie != null)
                    {
                        bool estOK = current.mkdir(arg);

                        if (estOK)
                        { Console.WriteLine("Dossier " + "<" + arg + ">" + " créé"); }
                        else
                        {
                            Console.WriteLine("Vous ne disposez pas des droits!");
                        }

                    }


                    if (commande == "ls" && saisie != null)
                    {
                        if (current.canRead())
                        {
                            List<File> list = current.ls();

                            if (list.Count == 0)
                            {
                                Console.WriteLine("Le dossier est vide");
                            }
                            else
                            {
                                foreach (File charge in list)
                                {
                                    if (charge.isFile() == true)
                                    {
                                        Console.WriteLine("(" + charge.getPermission() + ")" + " (f) " + charge.Name);
                                    }
                                    else
                                    {
                                        Console.WriteLine(charge.getPermission() + " (d) " + charge.Name);
                                    }


                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Vous n'avez pas les droits nécessaires");
                        }
                    }
                    else if (commande == "cd" && arg != null && saisie != null)
                    {
                        File suivant = current.newcd(arg);

                        if (suivant == null)
                        {
                            Console.WriteLine("Vous ne pouvez pas vous déplacer");
                        }
                        else
                        {
                            enCour = suivant;

                        }
                    }
                    else if (commande == "remove" && saisie != null && arg != null)
                    {
                        bool estOk = current.delete(arg);
                        if (estOk)
                        {
                            Console.WriteLine("Le fichier est supprimé.");
                        }
                        else

                        {
                            Console.WriteLine("Suppression impossible.");
                        }
                    }
                    if (commande == "rename" && arg != null && saisie != null && argBis != null)
                    {
                        File nvNom = current.newcd(arg);

                        bool estOk = nvNom.renameTo(argBis);

                        if (estOk)
                        {
                            Console.WriteLine("Dossier/Fichier renommé avec succès!");
                        }
                        else
                        {
                            Console.WriteLine("Erreur! Dossier/Fichier impossible à renommer");
                        }
                    }

                }
                catch
                {
                    if (commande == "ls" && saisie != null)
                    {
                        Console.WriteLine("Vous êtes dans un fichier ");
                    }
                }

                if (commande == "path")
                {
                    string lepath = enCour.getPath();
                    Console.WriteLine(lepath);
                }

                if (commande == "parent")
                {
                    enCour = enCour.getParent();
                }
                if (commande == "directory")
                {
                    if (enCour.isDirectory())
                    {
                        Console.WriteLine("C'est un dossier.");
                    }
                    else
                    {
                        Console.WriteLine("Ce n'est pas un dossier.");
                    }
                }

                if (commande == "file")
                {
                    if (enCour.isFile())
                    {
                        Console.WriteLine("C'est un fichier.");
                    }
                    else
                    {
                        Console.WriteLine("Ce n'est pas un fichier.");
                    }
                }
                if (commande == "name")
                {
                    string lenom = enCour.getName();
                    Console.WriteLine("-->" + lenom);
                }
                if (commande == "root")
                {
                    File root = enCour.getRoot();
                    Console.WriteLine(root.Name);

                }


                if (commande == "clear")
                {
                    Console.Clear();
                }

                if (commande == "chmod" && saisie != null)
                {
                    try
                    {
                        enCour.chmod(int.Parse(arg));
                    }
                    catch
                    {
                        Console.WriteLine("Attention, le nombre pour la permission est incorrect.");
                    }
                }
                if (commande == "restart" && saisie != null)
                {
                    Console.WriteLine("Le système va redémarrer");
                }

            } while (commande != "restart");



            Console.ReadLine();
        }


        static string getCommand(string varUser)
        {
            string[] word = varUser.Split(' ');

            if (word.Length > 0)
            {
                return word[0];
            }
            else
            {
                return null;
            }

        }
        static string getArgument(string varUser)
        {
            string[] word = varUser.Split(' ');
            if (word.Length > 1)
            {
                return word[1];
            }
            else
            { return null; }
        }
        static string getArgumentBis(string varUser)
        {
            string[] word = varUser.Split(' ');
            if (word.Length > 2)
            {
                return word[2];
            }
            else
            { return null; }
        }

    }
}
