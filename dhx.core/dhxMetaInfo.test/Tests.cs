using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using System.Reflection;
using System.Collections.Generic;

namespace dhxMetaInfo.test
{
    /// <summary>
    /// Tests
    /// </summary>
    [TestFixture ()]
    public class Tests
    {
        public Tests()
        {
        }

        [SetUp]
        public void BeforeEachTest()
        {
        }

        /***
        [Test]
        public void ReadSchema() {
            var schemaList = GetSchemaList ();

            var templates = new TemplateSnippets ();
            foreach (Schema s in schemaList) {
                var classes = templates.GetClassSequence(s);
                Console.Write( classes);
            }
        }
        ***/

        [Test]
        public void CodeModelImportTest()
        {
            var cm = new CodeModel ();

            try {
                var schemaList = GetSchemaList ();
                Console.Write ("1");
                cm.ImportSchema (schemaList);
                Console.Write ("2");
            } catch (Exception ex) {
                Console.Write (ex.Message);

            }

            Console.Write ("3");

        }

        [Test]
        public void CodeGenTest() {

            try {
                var schemaList = GetSchemaList();
                var cm = new CodeModel();
                cm.ImportSchema( schemaList );

                var eb = new EntityBuilder( cm );

                var code = eb.CreateNameSpacesCode();
     
                Console.Write( code);
            } catch (Exception ex) {
                Console.Write( ex.Message );

            }


        }

        List<Schema> GetSchemaList()
        {
            var dir = System.IO.Path.GetDirectoryName (Assembly.GetExecutingAssembly ().Location);
            Console.WriteLine (dir);
            var sr = File.OpenText (dir + "/data/schemaDefinitions.json");
            var reader = new MetaInfoReader ();
            var schemalist = reader.ReadSchema (sr);
            return schemalist;
        }

    }
}
