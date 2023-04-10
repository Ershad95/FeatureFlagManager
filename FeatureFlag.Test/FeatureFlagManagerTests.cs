using FeatureFlag.Core;
using Moq;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace FeatureFlag.Test
{
    public class FeatureFlagManagerTests
    {
        private readonly FeatureFagItem _testFeatureFagItem;
        private readonly FeatureFlagManager _sut;

        public FeatureFlagManagerTests()
        {
            _testFeatureFagItem = new FeatureFagItem
            {
                Name = "TestFeatureFlag",
                Enabled = true
            };
            var jsonConvertorMock = new Mock<IJsonConvertor>();
            jsonConvertorMock.Setup(x => x.GetFeatureFagItems(It.IsAny<string>())).Returns(new List<FeatureFagItem>
            {
                _testFeatureFagItem
            });
            _sut = new FeatureFlagManager("dummyPath", jsonConvertorMock.Object);
        }

        [Fact]
        public void IsActiveFeatureWithName_ShouldThrowInvalidDataException_WhenNameOfFeatureIsNull()
        {
            // Arrange
            string? nameOfFeature = null;

            // Act & Assert
            Assert.Throws<InvalidDataException>(() => _sut.IsActiveFeatureWithName(nameOfFeature));
        }

        [Fact]
        public void IsActiveFeatureWithName_ShouldThrowInvalidDataException_WhenNameOfFeatureIsEmpty()
        {
            // Arrange
            var nameOfFeature = "";

            // Act & Assert
            Assert.Throws<InvalidDataException>(() => _sut.IsActiveFeatureWithName(nameOfFeature));
        }

        [Fact]
        public void IsActiveFeatureWithName_ShouldThrowInvalidDataException_WhenNoFeatureFlagMatchesName()
        {
            // Arrange
            var nameOfFeature = "NonExistentFeatureFlag";

            // Act & Assert
            Assert.Throws<InvalidDataException>(() => _sut.IsActiveFeatureWithName(nameOfFeature));
        }

        [Fact]
        public void IsActiveFeatureWithName_ShouldReturnTrue_WhenFeatureFlagExistsAndIsEnabled()
        {
            // Arrange
            var nameOfFeature = "TestFeatureFlag";

            // Act
            var result = _sut.IsActiveFeatureWithName(nameOfFeature);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void GetFeatureFlagInfoWithName_ShouldThrowInvalidDataException_WhenNameOfFeatureIsNull()
        {
            // Arrange
            string? nameOfFeature = null;

            // Act & Assert
            Assert.Throws<InvalidDataException>(() => _sut.GetFeatureFlagInfoWithName(nameOfFeature));
        }

        [Fact]
        public void GetFeatureFlagInfoWithName_ShouldThrowInvalidDataException_WhenNameOfFeatureIsEmpty()
        {
            // Arrange
            const string nameOfFeature = "";

            // Act & Assert
            Assert.Throws<InvalidDataException>(() => _sut.GetFeatureFlagInfoWithName(nameOfFeature));
        }

        [Fact]
        public void GetFeatureFlagInfoWithName_ShouldThrowInvalidDataException_WhenNoFeatureFlagMatchesName()
        {
            // Arrange
            const string nameOfFeature = "NonExistentFeatureFlag";

            // Act & Assert
            Assert.Throws<InvalidDataException>(() => _sut.GetFeatureFlagInfoWithName(nameOfFeature));
        }

        [Fact]
        public void GetFeatureFlagInfoWithName_ShouldReturnFeatureFlag_WhenFeatureFlagExists()
        {
            // Arrange
            const string nameOfFeature = "TestFeatureFlag";

            // Act
            var result = _sut.GetFeatureFlagInfoWithName(nameOfFeature);

            // Assert
            Assert.That(result, Is.EqualTo(_testFeatureFagItem));
        }
    }
}
