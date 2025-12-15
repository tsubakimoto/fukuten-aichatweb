using System;
using Xunit;


namespace ChatConsole.UnitTests
{
    /// <summary>
    /// Tests for the ChatConfig constructor ensuring proper assignment and exception handling.
    /// </summary>
    public class ChatConfigTests
    {
        /// <summary>
        /// Ensures constructor throws ArgumentNullException when key is null.
        /// Input: key = null, uri and model are valid non-null strings.
        /// Expected: ArgumentNullException with ParamName = "key".
        /// </summary>
        [Fact]
        public void ChatConfig_NullKey_ThrowsArgumentNullException()
        {
            // Arrange
            string? key = null;
            string uri = "https://api.example.com";
            string model = "gpt-4o";

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new ChatConfig(key!, uri, model));

            // Assert
            Assert.Equal("key", ex.ParamName);
        }

        /// <summary>
        /// Ensures constructor throws ArgumentNullException when uri is null.
        /// Input: uri = null, key and model are valid non-null strings.
        /// Expected: ArgumentNullException with ParamName = "uri".
        /// </summary>
        [Fact]
        public void ChatConfig_NullUri_ThrowsArgumentNullException()
        {
            // Arrange
            string key = "key123";
            string? uri = null;
            string model = "gpt-4o";

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new ChatConfig(key, uri!, model));

            // Assert
            Assert.Equal("uri", ex.ParamName);
        }

        /// <summary>
        /// Ensures constructor throws ArgumentNullException when model is null.
        /// Input: model = null, key and uri are valid non-null strings.
        /// Expected: ArgumentNullException with ParamName = "model".
        /// </summary>
        [Fact]
        public void ChatConfig_NullModel_ThrowsArgumentNullException()
        {
            // Arrange
            string key = "key123";
            string uri = "https://api.example.com";
            string? model = null;

            // Act
            var ex = Assert.Throws<ArgumentNullException>(() => new ChatConfig(key, uri, model!));

            // Assert
            Assert.Equal("model", ex.ParamName);
        }
    }
}