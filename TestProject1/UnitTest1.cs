namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.ThrowsAsync<ArgumentException>(() => throw new ArgumentException());
            Assert.ThrowsAsync<IndexOutOfRangeException>(() => throw new IndexOutOfRangeException());
        }

        //DoesNowValidateIfMinLenghtSmallerThanMaxLengthInInitialize_UnitTestShouldFail

        //ReturnsAlwaysOneError_UnitTestShouldFail

        //DoesNotValidateIfPasswordContainCapitalLetters_UnitTestShouldFail

        //DoesNotValidateIfNotEmpty_UnitTestShouldFail

        //DoesNotValidateIfLongEnough_UnitTestShouldFail

        //ValidateIfPasswordContainCapitalLettersWhenNotNeeded_UnitTestShouldFail

        //DoesNotValidateIfPasswordContainDigits_UnitTestShouldFail

        //DoesNotValidateIfNotTooLong_UnitTestShouldFail

        //ErrorsCollectionIsNull_UnitTestShouldFail

        //Returns2ErrorsWhenThereAre3_UnitTestShouldFail

        //DoesNotValidateMaxLengthInInitialize_UnitTestShouldFail

        //ValidateIfPasswordContainDigitsWhenNotNeeded_UnitTestShouldFail

        //ValidateIfPasswordContainDigitsWhenNotNeeded_UnitTestShouldFail

        //DoesNotValidateMinLengthInInitialize_UnitTestShouldFail

        //ErrorsCollectionIsNotEmptyForCorrectPassword_UnitTestShouldFail

        //DoesNotCheckIfPasswordIsNull_UnitTestShouldFail
    }
}