using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    public class Directory : File
    {
        public List<File> Contenu = new List<File>();

        public Directory(string name, bool racine) : base(name, racine)
        { }

        public Directory(string name, Directory parent) : base(name, parent)
        { }


        public bool mkdir(string name)

        {
            if (this.canWrite())
            {
                if (Contenu.Count() == 0)
                {
                    Directory newDirectory = new Directory(name, this);
                    Contenu.Add(newDirectory);
                    return true;
                }
                else
                {
                    foreach (File file in Contenu)
                    {
                        if (file.Name != name)
                        {
                            Directory newDirectory = new Directory(name, this);
                            Contenu.Add(newDirectory);
                            return true;

                        }
                        else
                        {
                            Console.WriteLine("Vous ne pouvez pas créér de dossier!");
                            return false;
                        }
                    }
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public bool createNewFile(string name)
        {
            if (this.canWrite())
            {
                if (Contenu.Count() == 0)
                {
                    Contenu.Add(new File(name, this));
                    return true;
                }
                else
                {
                    foreach (File file in Contenu)
                    {
                        if (file.Name != name)
                        {
                            Contenu.Add(new File(name, this));
                            return true;

                        }
                        else
                        {
                            Console.WriteLine("Vous ne pouvez pas créér de fichier!");
                            return false;
                        }
                    }
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        //méthode permettant de se déplacer sur un fichier
        public File cd(string nom)
        {
            if (this.canRead())
            {
                foreach (File charge in Contenu)
                {
                    if (charge.Name == nom)
                    {
                        return charge;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        //méthode pour afficher la liste de fichiers
        public List<File> ls()
        {
            return this.Contenu;
        }


        public bool renameTo(string newName, string nameFolder)
        {


            if (canWrite())
            {
                this.Name = newName;
                return true;
            }
            else
            {
                return false;
            }


        }

        //méthode pour supprimer un fichier
        public bool delete(string nom)
        {
            foreach (File charge in Contenu)
            {
                if (charge.Name == nom)
                {
                    Contenu.Remove(charge);
                    return true;
                }
            }
            return false;
        }

        public List<File> search(string nom)
        {
            List<File> recherche = new List<File>();

            foreach (File encours in Contenu)
            {
                if (encours.Name == nom)
                {
                    recherche.Add(encours);
                }

                if (encours.isDirectory())
                {
                    List<File> autre = new List<File>();
                    Directory other = (Directory)encours;
                    autre = other.search(nom);
                    foreach (File courants in autre)
                    {
                        recherche.Add(courants);
                    }
                }
            }
            return recherche;
        }

    }
}
