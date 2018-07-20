using MakeYourGaps.Entities.Domains;
using System;

namespace MakeYourGaps.Entities.BusinessEntities
{
    public class GenerateTextRandomGaps
    {
        #region [ Private ]

        /// <summary>
        /// Words of the text
        /// </summary>
        private string[] Words;

        #endregion

        #region [ Public ]

        /// <summary>
        /// Text
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Difficulty
        /// </summary>
        public DifficultyEnum Difficulty { get; }

        #endregion

        #region [ Constructor ]

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="text"></param>
        /// <param name="difficulty"></param>
        public GenerateTextRandomGaps(string text, int difficulty)
        {
            this.Text = text;
            this.Difficulty = (DifficultyEnum)difficulty;

            //TODO: Put the delimiters in the DB
            char[] delimiters = new char[] { ' ' };
            this.Words = this.Text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        }

        #endregion

        #region [ Private Methods ]

        #region [ Count words in the text ]

        /// <summary>
        /// Count the words in the Text
        /// </summary>
        /// <returns></returns>
        private int CountTextWords()
        {
            return this.Words.Length;
        }

        #endregion

        #region [ Get the difficulty percentage ]

        /// <summary>
        /// Get percentage of the difficulty
        /// </summary>
        /// <param name="difficultyEnum"></param>
        /// <returns></returns>
        private decimal GetDifficultyPercentage()
        {
            switch (this.Difficulty)
            {
                case DifficultyEnum.Easy:
                    return DifficultyPercentage.Easy;

                case DifficultyEnum.Medium:
                    return DifficultyPercentage.Medium;

                case DifficultyEnum.Hard:
                    return DifficultyPercentage.Hard;

                case DifficultyEnum.VeryHard:
                    return DifficultyPercentage.VeryHard;

                default:
                    return DifficultyPercentage.Easy;
            }
        }

        #endregion

        #region [ Calculate quantity of words to be removed ]

        /// <summary>
        /// Count the amount of words to be removed from the Text
        /// </summary>
        /// <returns></returns>
        private int CountWordsToBeRemoved()
        {
            var quantityOfWords = this.CountTextWords();
            var quantityOfWordsToBeRemoved = Decimal.Floor(quantityOfWords * this.GetDifficultyPercentage());

            return Decimal.ToInt32(quantityOfWordsToBeRemoved);
        }

        #endregion

        #region [ Validate the gap position ]

        /// <summary>
        /// Valdiate the gap position generated
        /// </summary>
        /// <param name="gap"></param>
        /// <returns></returns>
        private bool ValidateGapPosition(int gap)
        {
            var lastPosition = this.CountTextWords() - 1;

            if (gap == 0 && this.Words[gap] == "#")
                return false;

            else if (gap == lastPosition && this.Words[gap] == "#")
                return false;

            else if ((gap != 0 && gap != lastPosition) &&
                     (this.Words[gap] == "#" || this.Words[gap - 1] == "#" || this.Words[gap + 1] == "#"))
                return false;

            else
                return true;
        }

        #endregion

        #endregion

        #region [ Public methods ]

        #region [ Get text with random gaps ]

        /// <summary>
        /// Generate the text with the random gaps
        /// </summary>
        /// <returns></returns>
        public string GenerateTextWithRandomGaps()
        {
            Random randomNumberGenerator = new Random();
            var quantityOfWordsToBeRemoved = this.CountWordsToBeRemoved();

            var wordsRemoved = 0;
            while (wordsRemoved < quantityOfWordsToBeRemoved)
            {
                int gap = randomNumberGenerator.Next(0, this.CountTextWords());
                if (ValidateGapPosition(gap))
                {
                    this.Words[gap] = "#";
                    wordsRemoved++;
                }
            }

            return String.Join(" ", this.Words);
        }

        #endregion

        #endregion
    }
}
