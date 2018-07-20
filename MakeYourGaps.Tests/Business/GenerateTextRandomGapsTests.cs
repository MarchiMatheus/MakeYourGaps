using MakeYourGaps.Entities.BusinessEntities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace MakeYourGaps.Tests.Business
{
    [TestClass]
    public class GenerateTextRandomGapsTests
    {
        #region [ Private ]

        /// <summary>
        /// Italian text
        /// </summary>
        private string ItalianText { get; set; }

        #endregion

        #region [ Initialize ]

        /// <summary>
        /// Initialize
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.ItalianText = "L'italiano è una língua romanza usata principalmente in Italia. L'italiano è classificato al 21º posto tra le lingue per numero di parlanti nel mondo e, in Italia, è utilizzato da circa 58 milioni di residenti. Viene considerato la lingua materna del 95% dei cittadini italiani residenti in Italia, che spesso lo acquisiscono e lo usano insieme alle varianti regionali dell'italiano, alle lingue regionali e ai dialetti. In Italia viene ampiamente usato per tutti i tipi di comunicazione della vita quotidiana ed è la lingua della quasi totalità dei mezzi di comunicazione nazionali, dell'editoria dell'amministrazione pubblica dello Stato italiano. L'italiano è una delle lingue ufficiali dell'Unione europea ed è lingua ufficiale dell'Italia, di San Marino,della Svizzera, della Città del Vaticano e del Sovrano Militare Ordine di Malta. È inoltre ufficiale, a livello regionale o comunale, in alcune aree di Croazia e Slovenia. L'italiano è diffuso nelle comunità di emigrazione italiana, è ampiamente noto per ragioni pratiche in diverse aree geografiche ed è una delle lingue straniere più studiate nel mondo. Dal punto di vista storico l'italiano è una lingua basata sul fiorentino letterario usato nel Trecento.";
        }

        #endregion

        #region [ Should validade quantity of words in a simple text ]

        /// <summary>
        /// Rule:
        /// Should validate the number of words in the simple given text
        /// Difficulty does not matter
        /// </summary>
        [TestMethod]
        public void ShouldValidateQuantityOfWordsInSimpleText()
        {
            //Arrange
            var text = "Test for counting the quantity of words in a text.";

            //Act
            var quantityOfWords = CountTextWords(text);

            //Assert
            Assert.AreEqual(10, quantityOfWords);
        }

        #endregion

        #region [ Should validade quantity of words in a complex text ]

        /// <summary>
        /// Rule:
        /// Should validate the number of words in the complex given text
        /// Difficulty does not matter
        /// </summary>
        [TestMethod]
        public void ShouldValidateQuantityOfWordsInComplexText()
        {
            //Arrange
            var complexText = "Test for counting , in a complex text, the quantity of words. The idea (of this text) is to represent, in a breaf way, a text that has a certain complexity. Is it working? I hope it's, because it means that i've made this right!";

            //Act
            var quantityOfWords = CountTextWords(complexText);

            //Assert
            Assert.AreEqual(44, quantityOfWords);
        }

        #endregion

        #region [ Should validade quantity of words in a big text ]

        /// <summary>
        /// Rules:
        /// Should validate the number of words in a big text
        /// Difficulty does not matter
        /// </summary>
        [TestMethod]
        public void ShouldValidateQuantityOfWordsInBigText()
        {
            //Arrange


            //Act
            var quantityOfWords = CountTextWords(this.ItalianText);

            //Assert
            Assert.AreEqual(186, quantityOfWords);
        }

        #endregion

        #region [ Should calculate quantity of words removed for Easy difficulty ]

        /// <summary>
        /// Rules:
        /// Should calculate the amount of words to be removed from the given text
        /// Easy difficulty setted
        /// </summary>
        [TestMethod]
        public void ShouldCalculateQuantityOfWordsToRemoveEasyDifficulty()
        {
            //Arrange
            var generateTextRandomGaps = new GenerateTextRandomGaps(this.ItalianText, 1);

            //Act            
            var textWithRandomGaps = generateTextRandomGaps.GenerateTextWithRandomGaps();
            var quantityOfHashTags = textWithRandomGaps.Count(c => c == '#');

            //Assert
            Assert.AreEqual(18, quantityOfHashTags);
        }

        #endregion

        #region [ Should calculate quantity of words removed for Medium difficulty ]

        /// <summary>
        /// Rules:
        /// Should calculate the amount of words to be removed from the given text
        /// Medium difficulty setted
        /// </summary>
        [TestMethod]
        public void ShouldCalculateQuantityOfWordsToRemoveMediumDifficulty()
        {
            //Arrange
            var generateTextRandomGaps = new GenerateTextRandomGaps(this.ItalianText, 2);

            //Act
            var textWithRandomGaps = generateTextRandomGaps.GenerateTextWithRandomGaps();
            var quantityOfHashTags = textWithRandomGaps.Count(c => c == '#');

            //Assert
            Assert.AreEqual(27, quantityOfHashTags);
        }

        #endregion

        #region [ Should calculate quantity of words removed for Hard difficulty ]

        /// <summary>
        /// Rules:
        /// Should calculate the amount of words to be removed from the given text
        /// Hard difficulty setted
        /// </summary>
        [TestMethod]
        public void ShouldCalculateQuantityOfWordsToRemoveHardDifficulty()
        {
            //Arrange
            var generateTextRandomGaps = new GenerateTextRandomGaps(this.ItalianText, 3);

            //Act
            var textWithRandomGaps = generateTextRandomGaps.GenerateTextWithRandomGaps();
            var quantityOfHashTags = textWithRandomGaps.Count(c => c == '#');

            //Assert
            Assert.AreEqual(37, quantityOfHashTags);
        }

        #endregion

        #region [ Should calculate quantity of words removed for Very Hard difficulty ]

        /// <summary>
        /// Rules:
        /// Should calculate the amount of words to be removed from the given text
        /// Very Hard difficulty setted
        /// </summary>
        [TestMethod]
        public void ShouldCalculateQuantityOfWordsToRemoveVeryHardDifficulty()
        {
            //Arrange
            var generateTextRandomGaps = new GenerateTextRandomGaps(this.ItalianText, 4);

            //Act
            var textWithRandomGaps = generateTextRandomGaps.GenerateTextWithRandomGaps();
            var quantityOfHashTags = textWithRandomGaps.Count(c => c == '#');

            //Assert
            Assert.AreEqual(46, quantityOfHashTags);
        }

        #endregion

        #region [ Methods ]

        #region [ Count words in the text ]

        /// <summary>
        /// Count the words in the given text
        /// </summary>
        /// <returns></returns>
        private int CountTextWords(string text)
        {
            char[] delimiters = new char[] { ' ', ',', '.', '!', '?', '(', ')' };

#if DEBUG

            var debugPorpouse = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

#endif

            return text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        #endregion

        #endregion
    }
}
