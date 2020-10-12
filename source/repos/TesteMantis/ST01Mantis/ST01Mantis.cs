using NUnit.Framework;
using NUnit.Core;

namespace SeleniumTests
{
    public class ST01Mantis
    {
        [Suite] public static TestSuite Suite
        {
            get
            {
                TestSuite suite = new TestSuite("ST01Mantis");
                suite.Add(new CT01ValidandoLayout());
                suite.Add(new CT02CriandoProblema());
                suite.Add(new CT03TelaDeProblemas());
                return suite;
            }
        }
    }
}
