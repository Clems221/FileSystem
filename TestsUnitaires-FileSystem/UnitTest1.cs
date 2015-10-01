using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileSystem;
using System.Collections.Generic;
using System.Linq;


namespace TU
{
    [TestClass]
    public class TU
    {

        public Directory current;
        public File NouvFile;

        public Directory Dossier1;
        public Directory Dossier2;
        public Directory Dossier3;
        public File CFile;




        [TestInitialize]
        public void SetUp()
        {
            current = new Directory("/", true);
            current.mkdir("Dossier1");
            current.mkdir("Dossier2");
            current.mkdir("Dossier3");
            current.createNewFile("CFile");
            NouvFile = current.cd("NouvFile");
            Dossier1 = (Directory)NouvFile;
            //Dossier1.chmod(7);
            //Dossier1.mkdir("NouvDossier");



            CFile = current.cd("CFile");
            Dossier2 = (Directory)current.cd("Dossier2");
        }


        [TestMethod]
        public void cd()
        {
            File recup = current.cd("Dossier1");
            Assert.AreEqual(recup.Name, "Dossier1");
        }
        [TestMethod]
        public void ls()
        {
            List<File> listels = current.ls();
            Assert.AreEqual(listels.Count(), 4);
        }
        [TestMethod]
        public void mkdir()
        {
            current.chmod(7);

            Assert.IsTrue(current.mkdir("Dossier1"));
        }
        [TestMethod]
        public void Chmod()
        {
            Assert.AreEqual(NouvFile, Dossier1);
        }
        
        [TestMethod]
        public void CreateNewFile()
        {
            Assert.IsTrue(current.createNewFile("Test"));
        }

        [TestMethod]
        public void delete()
        {
            bool fichier = current.delete("Dossier1");
            Assert.IsTrue(fichier, "Dossier1");
        }

        [TestMethod]
        public void renameTo()
        {
            Assert.IsTrue(current.renameTo("NouveauDossier1", "Dossier1"));
        }
        /*
        [TestMethod]
        public void getName()
        {
            Assert.IsTrue();
        }
        
        [TestMethod]
        public void IsFile()
        {
            Assert.IsTrue(CFile.IsFile());
        }
        
        [TestMethod]
        public void IsDirectory()
        {
            Assert.IsTrue(current.IsDirectory(Dossier1));
        }
        
        

        [TestMethod]
        public void getPermission()
        {
            Assert.IsTrue();
        }
        [TestMethod]
        public void getParent()
        {
            Assert.IsTrue();
        }*/

    }
}
