using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileSystem;

namespace TU
{
    [TestClass]
    public class TU
    {

        public Directory current;
        public File OK;

        public Directory OKDirectory;
        public Directory HIHI;
        public Directory YOLO;
        public File CFile;




        [TestInitialize]
        public void SetUp()
        {
            current = new Directory("/", true);
            current.mkdir("OK");
            current.mkdir("HIHI");
            current.mkdir("YOLO");
            current.createNewFile("CFile");
            OK = current.cd("OK");
            OKDirectory = (Directory)OK;
            OKDirectory.chmod(7);
            OKDirectory.mkdir("NouvDossier");



            CFile = current.cd("CFile");
            HIHI = (Directory)current.cd("HIHI");
        }


        [TestMethod]
        public void cd()
        {
            File recup = current.cd("OK");
            Assert.AreEqual(recup, OK);
        }
        [TestMethod]
        public void Chmod()
        {

            Assert.AreEqual(OKDirectory, OK);
        }

        [TestMethod]
        public void IsFile()
        {
            Assert.IsTrue(CFile.IsFile());
        }

        [TestMethod]
        public void IsDirectory()
        {
            Assert.IsTrue(HIHI.IsDirectory());
        }
    }
}
