using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PigLatin
{
    [TestClass]
    public class PigLatinTests
    {
        [TestMethod]
        public void WhenTranslatingASingleWordThenTheFirstLetterIsMovedToTheEndAndFormatted()
        {
            var inputs = new List<string> {"pig", "zillion"};
            var expectedResults = new List<string> {"igpay", "illionzay"};

            for (var i = 0; i < inputs.Count; i++)
            {
                var input = inputs[i];
                var result = PigLatinTranslator.Translate(input);

                Assert.AreEqual(expectedResults[i], result);
            }
        }

        [TestMethod]
        public void WhenTranslatingAndTheWordStartsWithAVowelThenAYIsAppended()
        {
            var inputs = new List<string> { "earring" };
            var expectedResults = new List<string> { "earringay" };

            for (var i = 0; i < inputs.Count; i++)
            {
                var input = inputs[i];
                var result = PigLatinTranslator.Translate(input);

                Assert.AreEqual(expectedResults[i], result);
            }
        }

        [TestMethod]
        public void WhenTranslatingAWordAndTheWordStartsWithAConsonantClusterThenTheClusterIsMovedToTheEndAndAYAppended()
        {
            var inputs = new List<string> { "clasp", "chrome"};
            var expectedResults = new List<string> { "aspclay", "omechray"};

            for (var i = 0; i < inputs.Count; i++)
            {
                var input = inputs[i];
                var result = PigLatinTranslator.Translate(input);

                Assert.AreEqual(expectedResults[i], result);
            }
        }

        [TestMethod]
        public void WhenTranslatingMultipleWordsThenEachWordIsTransformedCorrectly()
        {
            var inputs = new List<string> { "wear it with confidence" };
            var expectedResults = new List<string> { "earway itay ithway onfidencecay" };

            for (var i = 0; i < inputs.Count; i++)
            {
                var input = inputs[i];
                var result = PigLatinTranslator.Translate(input);

                Assert.AreEqual(expectedResults[i], result);
            }
        }

        [TestMethod]
        public void SingleWordCases()
        {
            var inputs = new List<string> { "Wear," };
            var expectedResults = new List<string> { "Earway," };

            for (var i = 0; i < inputs.Count; i++)
            {
                var input = inputs[i];
                var result = PigLatinTranslator.Translate(input);

                Assert.AreEqual(expectedResults[i], result);
            }
        }

        [TestMethod]
        public void WhenTranslatingMultipleWordsThenCapitilizationAndPunctuationIsMaintained()
        {
            var inputs = new List<string> { "Wear, it with confidence." };
            var expectedResults = new List<string> { "Earway, itay ithway onfidencecay." };

            for (var i = 0; i < inputs.Count; i++)
            {
                var input = inputs[i];
                var result = PigLatinTranslator.Translate(input);

                Assert.AreEqual(expectedResults[i], result);
            }
        }
    }
}
