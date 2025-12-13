using ChatApp;
using ChatApp.Services;
using Microsoft.Extensions;
using Microsoft.Extensions.VectorData;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Xunit;


namespace ChatApp.Services.UnitTests;

public class IngestedChunkTests
{
    /// <summary>
    /// Ensures that the Vector property returns the exact same string instance as the Text property,
    /// validating reference equality. Tests with various string contents including empty, whitespace,
    /// special characters, and a very long string.
    /// Expected: Vector is the same instance as Text for all inputs.
    /// </summary>
    /// <param name="input">The string assigned to Text.</param>
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("   ")]
    [InlineData("\t")]
    [InlineData("\n")]
    [InlineData("Hello, World!")]
    [InlineData("特殊字符!@#$%^&*()_+-=[]{};':\",.<>/?|`~")]
    [InlineData("Line1\r\nLine2\r\nLine3")]
    [InlineData("A")]
    [InlineData("Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.")]
    public void Vector_ReturnsSameInstanceAsText_ForVariousInputs(string input)
    {
        // Arrange
        var chunk = new IngestedChunk
        {
            Key = Guid.NewGuid(),
            DocumentId = "doc-1",
            Text = input,
            Context = "ctx"
        };

        // Act
        var vector = chunk.Vector;

        // Assert
        Assert.Same(chunk.Text, vector);
    }

    /// <summary>
    /// Verifies that updating the Text property subsequently reflects in the Vector property,
    /// ensuring the getter returns the current Text value.
    /// Expected: Vector changes to match the latest Text assignment.
    /// </summary>
    [Fact]
    public void Vector_ReflectsLatestText_AfterUpdates()
    {
        // Arrange
        var first = "first value";
        var second = "second value";
        var chunk = new IngestedChunk
        {
            Key = Guid.NewGuid(),
            DocumentId = "doc-2",
            Text = first,
            Context = null
        };

        // Act
        var vector1 = chunk.Vector;
        chunk.Text = second;
        var vector2 = chunk.Vector;

        // Assert
        Assert.Same(first, vector1);
        Assert.Same(second, vector2);
        Assert.NotSame(vector1, vector2);
    }
}