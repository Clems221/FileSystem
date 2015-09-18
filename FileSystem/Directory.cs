using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    class Directory : File
    {
        public List<File> Contenu = new List<File>();

        public Directory(string name, bool racine) : base(name, racine)
        { }

        public Directory(string name, Directory parent) : base(name, parent)
        { }


        public bool mkdir(string name)
        {
            if (base.canWrite())
            {
                Directory newDirectory = new Directory(name, this);
                Contenu.Add(newDirectory);
                return true;
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
                Contenu.Add(new File(name, this));
                return true;
            }
            else
            {
                return false;
            }
        }

        //méthode permettant de se déplacer sur un fichier
        public File newcd(string nom)
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


    }
}
