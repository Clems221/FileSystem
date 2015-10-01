using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    public class File
    {

        public string Name { get; set; }
        public Directory Parent = null;
        public int Permissions = 4;
        public string ParentPath = "";
        public bool Racine = false;

        public File(string name, Directory parent)
        {
            this.Name = name;
            this.Parent = parent;

        }
        public File(string name, bool racine)
        {
            this.Name = name;
            this.Racine = racine;
            this.Permissions = 7;

            Console.WriteLine("#######################");
            Console.WriteLine("----System Started-----");
            Console.WriteLine("#######################");
            Console.WriteLine();


        }




        //méthode pour connaître le chemin complet du fichier sur lequel l'utilisateur se trouve
        public string getPath()
        {


            string unPath = this.Name;
            File parent2 = Parent;

            while (parent2 != null)
            {
                unPath = parent2.Name + "/" + unPath;
                parent2 = parent2.Parent;
            }

            return unPath;
        }


        /*
        //méthode pour chercher un fichier en donnant son nom
         public List<File> search(string name)
         {
            foreach (File recherche in Contenu)

         }
        */


        public File getRoot()
        {
            if (this.Name != " C: ")
            {
                return this.Parent;
            }
            else
            {
                Console.Write("Vous vous trouvez à la racine -->");
                return this;
            }

        }

        //méthode pour avoir le nom du fichier
        public string getName()
        {
            return this.Name;
        }



        // méthode pour avoir le fichier parent
        public File getParent()
        {
            if (this.Name != " C: ")
            { return this.Parent; }
            else
            {
                Console.WriteLine("Impossible de remonter plus haut");

                return this;
            }
        }



        public int getPermission()
        {
            return this.Permissions;
        }


        //booléen pour savoir si c'est un fichier
        public bool isFile()
        {
            if (typeof(Directory) == this.GetType())
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal List<File> newls()
        {
            throw new NotImplementedException();
        }
        

        //booléen pour savoir si c'est un répertoire
        public virtual bool isDirectory()
        {
            if (typeof(File) == this.GetType())
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //méthode pour définir les droits
        public void chmod(int permission)
        {
            this.Permissions = permission;
        }

        public bool renameTo(string newName)
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




        public bool canWrite()
        {
            return (Permissions & 2) > 0;
        }
        public bool canExecute()
        {
            return (Permissions & 1) > 0;
        }



        public bool canRead()
        {
            return (Permissions & 4) > 0;
        }




    }
}
